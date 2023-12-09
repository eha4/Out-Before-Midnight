using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class quest : MonoBehaviour
{
    public string x;
    public Text questTxt;
    public bool doonce;
    public AudioSource b;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!doonce)
            {
                b.Play();
                doonce = true;
            }
            questTxt.text = x;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
