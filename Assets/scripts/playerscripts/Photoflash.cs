using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Photoflash : MonoBehaviour
{
   
    public GameObject flashlight;
    public bool cameraActive;
    public bool flashdone;
    public bool stunned;
    public GameObject cameraFlash;
    public AudioClip camStun;
    private AudioSource aS;

    public float flashtimer = 0.25f;
    public float cdtimer = 0f;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned == true)
        {
            flashdone = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && gameObject.GetComponent<player>().cameraActive == true && flashdone == false)
        {
            aS.volume = 0.5f;
            aS.PlayOneShot(camStun);
            flashdone = true;
            CameraFlashEffect();
        }
        if (flashdone == true && flashlight.GetComponent<FieldOfView>().canSeeObject == true)
        {
            stunned = true;
        }
        if (active == true)
        {
            flashtimer += Time.deltaTime;
        }
        if (flashtimer >= 0.25)
        {
            CameraFlashEffect();
            flashtimer = 0;
            active = false;
            flashdone = false;
        }
        else
        {
            stunned = false;
        }
    }

    private void CameraFlashEffect()
    {
        if (flashtimer == 0)
        {
            cameraFlash.SetActive(true);
            active = true;
        }
        else
        {
            cameraFlash.SetActive(false);
            active = false;
        }
    }
}
