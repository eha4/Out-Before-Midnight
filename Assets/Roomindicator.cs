using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Roomindicator : MonoBehaviour
{
    public Text roomtxt;
    public string x;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roomtxt.text = x;
            roomtxt.CrossFadeAlpha(1.0f, 0.0f, false);
            roomtxt.CrossFadeAlpha(0.0f, 5f, false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
