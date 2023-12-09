using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private Animator doorAnim2;

    public AudioSource audioSource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;

    private bool doorOpen = false; //sets the door as closed

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>(); //gets the gameobject's Animator
    }

    public void PlayAnimation()
    {
        if (!doorOpen)
        {
            doorAnim.Play("DoorOpen", 0, 0.0f); //plays the open door animation and sets the door as open
            audioSource.PlayOneShot(doorOpening, 0.7f);
            doorOpen = true;
        }
        else
        {
            doorAnim.Play("DoorClose", 0, 0.0f); //plays the close door animation and sets the door as closed
            audioSource.PlayOneShot(doorClosing, 0.7f);
            doorOpen = false;
        }
    }
}
