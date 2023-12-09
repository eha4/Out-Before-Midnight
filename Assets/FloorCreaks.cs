using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCreaks : MonoBehaviour
{
    [SerializeField] private AudioClip[] Creaks;
    [SerializeField] AudioSource audioSource;
    float timer = 0;
    public int minTime;
    public int maxTime;
    bool timerReached = false;

    void Update()
    {
        timer += Time.deltaTime;
        int time = Random.Range(minTime, maxTime);
        if (!timerReached && timer > time)
        {
            Debug.Log("Done waiting");
            startCreaks();

            //Set to false so that we don't run this again
            timerReached = true;
        }
        else if (timerReached)
        {
            timerReached = false;
            timer = 0;
        }
    }
    public void startCreaks()
    {
        int clip = Random.Range(0, 3);
        if (!timerReached)
        {
            audioSource.PlayOneShot(Creaks[Random.Range(0, Creaks.Length - 1)]);
            Debug.Log("this is played");
        }
    }
}
