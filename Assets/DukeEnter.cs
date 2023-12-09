using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeEnter : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;
    public bool dukeEnter;
    private RoomEnter rE;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rE = GetComponentInParent<RoomEnter>();
        Debug.Log("this is the state of the " + dukeEnter);
    }
    private void Update()
    {
        dukeEnter = rE.hasEntered;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            if (dukeEnter)
            {
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
