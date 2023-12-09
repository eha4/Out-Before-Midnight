using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubledoorcontroler : MonoBehaviour
{
    //public Animator doorAnim;
    public Animator doorAnim2;

    public AudioSource audioSource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;

    private bool doorOpen = false; //sets the door as closed

    private void Awake()
    {
        doorAnim2 = gameObject.GetComponent<Animator>(); //gets the gameobject's Animator
    }

    public void PlayAnimation2()
    {
        if (!doorOpen)
        {
            doorAnim2.Play("DoorOpenR", 0, 0.0f);
            audioSource.PlayOneShot(doorOpening, 0.7f);
            doorOpen = true;
        }
        else
        {
            doorAnim2.Play("DoorOpenRClose", 0, 0.0f);
            audioSource.PlayOneShot(doorClosing, 0.7f);
            doorOpen = false;
        }
    }

    public void PlayAnimation3()
    {
        if (!doorOpen)
        {
            doorAnim2.Play("DoorOpenL", 0, 0.0f);
            audioSource.PlayOneShot(doorOpening, 0.7f);
            doorOpen = true;
        }
        else
        {
            doorAnim2.Play("DoorOpenLClose", 0, 0.0f);
            audioSource.PlayOneShot(doorClosing, 0.7f);
            doorOpen = false;
        }
    }
}
