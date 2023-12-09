using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dukeAI : MonoBehaviour
{
    // Moving duke point from point
    NavMeshAgent agent;
    public Transform[] hallwayA;
    public Transform[] trophyRoom;
    public Transform[] firstFloorStorageRoom;
    public Transform[] hallwayB;
    public Transform[] ballroom;
    public Transform[] kitchen;
    public Transform[] diningRoom;
    public Transform[] masterBedroom;
    public Transform[] bathroom;
    public Transform[] hallwayC;
    public Transform[] study;
    public Transform[] secondFloorStorageRoom;
    public Transform[] closet;
    private Transform[][] routes = new Transform[13][];
    public double distToPoint = 2.0;
    private int index;
    private int routeIndex;
    public int destIndex;
    public int routeLoop = 3;
    public int routeLoopIndex;
    private Vector3 target;
    public float speed;

    // Animation
    public Animator animation;
    public float animationSpeed = 2f;
    //public bool attackIsOver;
    public bool hasAttacked;
    //public bool midAttack;
    //private float timeOutVar = 1.5f;
    //private float timeOut;
    public int animationNum = 0;
    public bool walkingThroughDoor;

    // Field of View
    public GameObject player;
    private bool allStop;
    public bool canSeePlayer;

    // Player
    //public bool playerCanMove;

    // Door
    private float interactionDistance = default;
    private Door currentInteractable;
    private LayerMask interactionLayer = default;
    private bool doorOpen;

    // Stun enemy
    public bool stunEnemy;
    public float stunTime;
    private float stunTimer;

    //Sounds
    [SerializeField] GameObject mainCam;
    private AudioSource audioSource;
    public AudioClip[] Awareness;
    private AudioSource heartBeat;
    private bool isDone;
    private bool isSeen;
    float timer = 0;
    bool timerReached = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LOOK HERE --------------------------------------------- START");

        /*
             0: Hallway A
             1: Trophy Room
             2: First Floor Storage Room
             3: Hallway B
             4: Ballroom
             5: Kitchen
             6: Dining Room
             7: Master Bedroom
             8: Bathroom
             9: Hallway C
            10: Study
            11: Second Floor Storage Room
            12: Closet
        */
        routes[0] = hallwayA;
        routes[1] = trophyRoom;
        routes[2] = firstFloorStorageRoom;
        routes[3] = hallwayB;
        routes[4] = ballroom;
        routes[5] = kitchen;
        routes[6] = diningRoom;
        routes[7] = masterBedroom;
        routes[8] = bathroom;
        routes[9] = hallwayC;
        routes[10] = study;
        routes[11] = secondFloorStorageRoom;
        routes[12] = closet;
        routeIndex = 0;
        destIndex = 0;
        routeLoopIndex = 0;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        GotoNextPoint();
        
        animationNum = 0;
        SetDukeAnimation(animationNum);
        animation.SetFloat("animationSpeed", animationSpeed);
        //midAttack = GameObject.Find("DukeNewUVFinal").GetComponent<dukeAnimation>().midAttack;
        //attackIsOver = GameObject.Find("DukeNewUVFinal").GetComponent<dukeAnimation>().attackIsOver;
        hasAttacked = false;
        walkingThroughDoor = false;
        doorOpen = false;
        isDone = false;

        canSeePlayer = gameObject.GetComponent<FieldOfView>().canSeeObject;
        allStop = false;

        audioSource = GetComponent<AudioSource>();
        heartBeat = mainCam.GetComponent<AudioSource>();

        //playerCanMove = GameObject.Find("James").GetComponent<FirstPersonController>().CanMove;

        stunEnemy = GameObject.Find("Flashlight").GetComponent<flashlight>().stunEnemy;
        stunTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Door.islocked != true)
        //{
            agent.speed = speed;
            animation.SetFloat("animationSpeed", animationSpeed);
            //midAttack = GameObject.Find("DukeNewUVFinal").GetComponent<dukeAnimation>().midAttack;
            //attackIsOver = GameObject.Find("DukeNewUVFinal").GetComponent<dukeAnimation>().attackIsOver;

            canSeePlayer = gameObject.GetComponent<FieldOfView>().canSeeObject;

            //playerCanMove = GameObject.Find("James").GetComponent<FirstPersonController>().CanMove;

            stunEnemy = player.GetComponent<Photoflash>().stunned;

            if (stunEnemy)
            {
                Debug.Log("LOOK HERE --------------------------------------------- STUN ENEMY");
                stunTimer = stunTime;
                animationNum = 4;
                SetDukeAnimation(animationNum);
                StartCoroutine(StunTime());
                audioSource.PlayOneShot(Awareness[Random.Range(2, 4)]);
            }
            else if (stunTimer > 0)
            {
                stunTimer -= Time.deltaTime;
            }
            else 
            {

                if (walkingThroughDoor)
                {
                    animationNum = 2;
                    HandleInteractionCheck();
                    HandleInteractionInput();
                }

                SetDukeAnimation(animationNum);

                // Chasing player
                if (canSeePlayer && !allStop)
                {
                    Debug.Log("LOOK HERE --------------------------------------------- CHASING");
                    agent.isStopped = true;
                    agent.ResetPath();
                    allStop = true;
                }
                else if (canSeePlayer)
                {
                    if(isDone == false)
                    {
                    audioSource.PlayOneShot(Awareness[0]);
                    audioSource.PlayOneShot(Awareness[2]);
                    heartBeat.volume = 0.75f;
                    isDone = true;
                    isSeen = true;
                    }
                
                    // Caught player
                    if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 2.4)
                    {
                        Debug.Log("LOOK HERE --------------------------------------------- CAUGHT "+Vector3.Distance(gameObject.transform.position, player.transform.position));
                        agent.isStopped = true;
                        hasAttacked = true;

                        if (!walkingThroughDoor)
                        {
                            animationNum = 1;
                        }

                        /*
                        GameObject.Find("James").GetComponent<FirstPersonController>().setCanMove(false);

                        if (midAttack)
                        {
                            GameObject.Find("James").GetComponent<FirstPersonController>().isHit = true;
                        }

                        GameObject.Find("DukeNewUVFinal").GetComponent<dukeAnimation>().midAttack = false;
                        */
                    }
                    else
                    {
                        // Reset animation after attacking player
                        if (hasAttacked)
                        {
                           // Debug.Log("LOOK HERE --------------------------------------------- CHASING 2");
                            //timeOut -= Time.deltaTime;
                            agent.isStopped = true;
                            agent.ResetPath();
                            if (!walkingThroughDoor)
                            {
                                animationNum = 0;
                            }
                            target = player.transform.position;
                            agent.SetDestination(target);
                            hasAttacked = false;
                            //timeOut = timeOutVar;

                            /*
                            // Chase player only after animation is finished or timeOut is reached (timeOut varies on speed of animation)
                            if (attackIsOver || timeOut <= 0)
                            {
                                target = player.transform.position;
                                agent.SetDestination(target);
                                hasAttacked = false;
                                timeOut = timeOutVar;
                            }
                            */
                        }

                        // Can see player and is chasing them
                        else
                        {
                            if (!walkingThroughDoor)
                            {
                                animationNum = 0;
                            }

                          //  Debug.Log("LOOK HERE --------------------------------------------- CHASING 3");
                            agent.isStopped = true;
                            agent.ResetPath();
                            target = player.transform.position;
                            agent.SetDestination(target);
                        }
                    }
                }

                // Cycle through path
                else if (!canSeePlayer && allStop)
                {
                   // Debug.Log("LOOK HERE --------------------------------------------- WALKING");
                    agent.isStopped = true;
                    animationNum = 0;
                    agent.ResetPath();
                    FindNearestIndex();
                    GotoNextPoint();
                    allStop = false;
                    isDone = false;
                    isSeen = false;
                    StartCoroutine(decayBeat());
                }
                else
                {
                    animationNum = 0;

                   // Debug.Log("LOOK HERE --------------------------------------------- WALKING 2 "+target+" "+ Vector3.Distance(gameObject.transform.position, target));
                    if (Vector3.Distance(gameObject.transform.position, target) < distToPoint)
                    {
                        if(isSeen == false)
                        {
                            timer += Time.deltaTime;
                            if (!timerReached && timer > 0.07f)
                            {
                                Debug.Log("Done waiting for timer");
                                audioSource.PlayOneShot(Awareness[1]);
                                timerReached = true;
                            }
                            else if (timerReached)
                            {
                            Debug.Log("the timer will now reset");
                                timerReached = false;
                                timer = 0;
                            }
                        
                        Debug.Log("James isn't seen");
                        }
                        
                        IterateIndex();
                        GotoNextPoint();
                    }
                }

            }
        //}
    }

    void GotoNextPoint()
    {
        //Debug.Log("LOOK HERE --------------------------------------------- GOTO "+routes[routeIndex][index]);

        if (routeIndex == destIndex && routeLoopIndex >= routeLoop)
        {
            // Set new destination

            int num = -1;

            while (num < 0)
            {
                num = Random.Range(0, 13);

                if (num != routeIndex && routes[num].Length > 0)
                {
                    routeIndex = num;
                    destIndex = num;
                    routeLoopIndex = 0;
                    index = 0;
                }
                else 
                {
                    num = -1;
                }
            }

            // routeLoopIndex = 1;
        }
        
        /*
        if (routeIndex != destIndex && routeLoopIndex == 1)
        {
            // Move one closer to destination

            Debug.Log("LOOK HERE --------------------------------------------- HERE ");

            routeLoopIndex = 0;

            if (routeIndex < destIndex)
            {
                routeIndex++;
            }
            else
            {
                routeIndex--;
            }
        }
        */
        
        //Debug.Log("LOOK HERE --------------------------------------------- GOTO "+routes[routeIndex][index]);
        target = routes[routeIndex][index].position;
        agent.SetDestination(target);
        
        /*
        if (routeLoopIndex >= routeLoop && routeIndex == destIndex)
        {

        }
        else if (routeLoopIndex >= routeLoop)
        {
            //routeLoopIndex = 
        }
        else
        {
            target = routes[routeIndex][index].position;
            agent.SetDestination(target);
        }
        */
    }

    void IterateIndex()
    {
        index++;
        if (index == routes[routeIndex].Length)
        {
            index = 0;
            routeLoopIndex++;
        }
    }

    void FindNearestIndex()
    {
        float smallestDistance = Vector3.Distance(gameObject.transform.position, routes[routeIndex][0].position);
        int smallestIndex = 0;

        for (int i = 1; i < routes[routeIndex].Length; i++)
        {
            if (Vector3.Distance(gameObject.transform.position, routes[routeIndex][i].position) < smallestDistance)
            {
                smallestDistance = Vector3.Distance(gameObject.transform.position, routes[routeIndex][i].position);
                smallestIndex = i;
            }
        }

        index = smallestIndex;
    }

    void SetDukeAnimation(int num)
    {
        switch (num)
        {
            // Walking animation
            case 0:
                Debug.Log("LOOK HERE --------------------------------------------- WALK ANIM ");
                animation.SetBool("isStandingStill", false);
                animation.SetBool("isAttacking", false);
                animation.SetBool("isCrouching", false);
                animation.SetBool("isStunned", false);
                animation.SetBool("isWalking", true);
                break;
            
            // Attacking animation
            case 1:
                Debug.Log("LOOK HERE --------------------------------------------- ATTACK ANIM ");
                animation.SetBool("isStandingStill", false);
                animation.SetBool("isWalking", false);
                animation.SetBool("isCrouching", false);
                animation.SetBool("isStunned", false);
                animation.SetBool("isAttacking", true);
                break;
            
            // Crouching animation
            case 2:
                animation.SetBool("isStandingStill", false);
                animation.SetBool("isWalking", false);
                animation.SetBool("isAttacking", false);
                animation.SetBool("isStunned", false);
                animation.SetBool("isCrouching", true);
                break;

            // Idle animation
            case 3:
                animation.SetBool("isAttacking", false);
                animation.SetBool("isCrouching", false);
                animation.SetBool("isWalking", false);
                animation.SetBool("isStunned", false);
                animation.SetBool("isStandingStill", true);
                break;

            // Stun animation
            case 4:
                Debug.Log("LOOK HERE --------------------------------------------- STUN ANIM ");
                animation.SetBool("isAttacking", false);
                animation.SetBool("isCrouching", false);
                animation.SetBool("isWalking", false);
                animation.SetBool("isStandingStill", false);
                animation.SetBool("isStunned", true);
                break;
        }
    }

    private void HandleInteractionCheck()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
       
        //Debug.DrawRay(ray.origin, ray.direction * 10);

        if (Physics.Raycast(ray, out hitData))
        { 
            Debug.Log("LOOK HERE --------------------------------------------------- HIT "+hitData.collider.tag);
            hitData.collider.TryGetComponent<Door>(out currentInteractable);
            
            if (currentInteractable && !currentInteractable.isOpen)
            {
                Debug.Log("LOOK HERE --------------------------------------------------- DOOR");
                currentInteractable.OnFocus();
                doorOpen = true;
            }
            else if (currentInteractable && currentInteractable.isOpen)
            {
                currentInteractable.OnLoseFocus();
                currentInteractable = null;
            }
        }
    }

    private void HandleInteractionInput()
    {
        if (currentInteractable && !currentInteractable.isOpen)
        {
            currentInteractable.OnInteract();
        }
    }
    IEnumerator StunTime()
    {
        yield return new WaitForSeconds(1);
    }
    IEnumerator decayBeat()
    {
        yield return new WaitForSeconds(5);
        heartBeat.volume = 0.5f;
        yield return new WaitForSeconds(3);
        heartBeat.volume = 0.25f;
        yield return new WaitForSeconds(1);
        heartBeat.volume = 0f;
    }
}
