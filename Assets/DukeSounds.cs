using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] Movements;
    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playWalk()
    {
        audioSource.PlayOneShot(Movements[Random.Range(0, 2)]);
    }
    public void playSwing()
    {
        audioSource.PlayOneShot(Movements[Random.Range(3,4)]);
    }
}
