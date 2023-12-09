using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class journeladder : MonoBehaviour
{
    public GameObject canvas;
    public int arraynum;
    private AudioSource sound;
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
    
        sound.Play();
        Destroy(gameObject);
    }
}
