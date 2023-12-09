using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomsound : MonoBehaviour
{
    private AudioSource sound;
    private int random;


    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        random = Random.Range(1, 10);
        if(random == 1)
        {
            sound.Play();
        }
    }
}
