using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tempAI : MonoBehaviour
{
    public Transform[] points;
    private int destPoint;
    private NavMeshAgent agent;
    public Transform playerTrans;
    public Camera aicamera;
    private bool playerseen;
    public int rayLength;
    private float timer;
    private int timemax = 5;
    public GameObject aienemy;
    public bool playernear;
    public bool doonce = true;
    private Rigidbody rigidbody;
    private bool ismoving;
    private AudioSource walking;
    private NavMeshAgent duke;
    public Animator anim;
    private float distance;
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        duke = gameObject.GetComponent<NavMeshAgent>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        walking = gameObject.GetComponent<AudioSource>();
        doonce = true;
        agent = GetComponent<NavMeshAgent>();
        timer = 0;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        if (playernear)
        {
            GotoNextPoint();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("enemy collied");
        if(collision.gameObject.tag == "Player")
        {
            player.health -= 1;
        }
    }
   
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        if (!playerseen)
        {
            agent.SetDestination(points[destPoint].position);

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
        }
        else if (playerseen)
        {
            Debug.Log("playerbeingchased");
            agent.SetDestination(playerTrans.position);

        }
    }
    void playerTakeDamge()
    {
       
    }
    /*
     * 
     * floats whole house range 
     * 
     * float playerseen last point 
     * 
     * float area of looking for player 
     * 
     * random.range
     * 
     * 
     * playseen 5s 
     * 
     * 
     *
     */
    void Update()
    {
        distance = Vector3.Distance(gameObject.transform.position, playerTrans.transform.position);
        if ( duke.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
            ismoving = true;
        }
        else
            ismoving = false;
        if (ismoving == true && !walking.isPlaying)
        {
            walking.Play();

        }
        else if(ismoving == false)
        {
            walking.Stop();
            //anim.SetBool("isWalking", false);
        }
        if( distance < 2)
        {
            //anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", true);
        }

        if (playernear && doonce)
        {
            GotoNextPoint();
            doonce = false;
        }
        playerTakeDamge();
        RaycastHit hit;
        Vector3 fwd = aienemy.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(aienemy.transform.position, fwd, Color.red);


        int mask = 1 << 10;
        mask = ~mask;
        if (Physics.Raycast(aienemy.transform.position, fwd, out hit, rayLength, mask))
        {
            //Debug.Log("raycast running");
            //Debug.Log(hit.collider.tag);

            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("hitplayerwithenemyraycast");
                playerseen = true;
                timer = 0;
            
            }
        }
        if (playerseen && timer < timemax)
        {
            timer += Time.deltaTime;
        }
        else
        {
            //Debug.Log("playersighthasbeenlost");
            playerseen = false;
            timer = 0;
        }
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && doonce == false)
        {
            GotoNextPoint();
        }
        else if (playerseen)
        {
            GotoNextPoint();
        }
    }
}
