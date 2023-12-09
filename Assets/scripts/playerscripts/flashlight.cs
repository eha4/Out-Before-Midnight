using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight : MonoBehaviour
{
    public Light flashlightobj;
    public float powerMax;
    public static float powerCur;
    public  float powerCharge;
    public float dischargeRate;
    public KeyCode rechargerKey;
    public bool usable;
    public bool flashlightOn;
    public bool canSeeEnemy;
    public bool stunEnemy;
    private bool hasBeenOn;
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    float timer = 0;
    bool timerReached;
    public float Limit;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        flashlightOn = false;
        powerCur = powerMax;
        flashlightobj = gameObject.GetComponent<Light>();
        flashlightobj.enabled = false;

        canSeeEnemy = gameObject.GetComponent<FieldOfView>().canSeeObject;
        stunEnemy = false;
        hasBeenOn = false;
        
    }
   
    // Update is called once per frame
    void Update()
    {
        canSeeEnemy = gameObject.GetComponent<FieldOfView>().canSeeObject;

        if (powerCur > 0)
        {
            usable = true;
        }
        else if (powerCur > 100)
        {
            powerCur = 100;
        }

        if (Input.GetKeyDown(KeyCode.F) && usable)
        {
            audioSource.PlayOneShot(audioClips[0]);
            flashlightobj.enabled = !flashlightobj.enabled;
            flashlightOn = !flashlightOn; 

            if (!flashlightOn)
            {
                hasBeenOn = false;
            }
        }

        if( powerCur <= 0)
        {
            usable = false;
            flashlightobj.enabled = false;
        }

        if(flashlightobj.enabled == true)
        {
            Debug.Log("discharging");
            powerCur -= Time.deltaTime * dischargeRate;
        }

        if (Input.GetKey(rechargerKey) && powerCur < 100)
        {
            powerCur += powerCharge * Time.deltaTime;
            recharge();
        }

    }
    void recharge()
    {
        timer += Time.deltaTime;
        if (!timerReached && timer > 0)
        {
            Debug.Log("Done waiting for timer");
            audioSource.PlayOneShot(audioClips[1]);
            timerReached = true;
        }
        else if (timerReached && timer > Limit)
        {
            Debug.Log("the timer will now reset");
            timerReached = false;
            timer = 0;
        }
    }
}
