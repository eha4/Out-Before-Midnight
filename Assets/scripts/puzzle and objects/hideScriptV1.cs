using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideScriptV1 : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public GameObject cam;
    public GameObject playercam;
    public GameObject door_L;
    public GameObject door_R;
    public bool hiden;
    private HideRaycast raycas;
    public AudioSource audioSource;
    public AudioClip wardrobeEnter;

    void Start()
    {
        //turn.x = 180;
        cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (hiden == true)
        {
            if (Input.GetKeyDown(player.useKey))
            {
                Playerhidden();
                //cam.enabled = !cam.enabled;
                //raycas.playerCam.enabled = !raycas.playerCam.enabled;
            }
        }
    }
        public void Playerhidden()
        {
            //gameObject.GetComponent<AudioSource>().Play();
            audioSource.PlayOneShot(wardrobeEnter, 0.5f);
            cam.SetActive(false);
            playercam.SetActive(true);

        }
        public void playerNothidden()
        {
            //gameObject.GetComponent<AudioSource>().Play();
            audioSource.PlayOneShot(wardrobeEnter, 0.5f);
            cam.SetActive(true);
            playercam.SetActive(false);
            hiden = true;
        }
    }