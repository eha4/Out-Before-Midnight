using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDoubleDoor : MonoBehaviour
{
    public GameObject doorL;
    public GameObject doorR;

    // Start is called before the first frame update
    void Start()
    {
        //doorL.gameObject.tag = "door";
        //doorR.gameObject.tag = "door";
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        doorL.gameObject.tag = "doorDouble2";
        doorR.gameObject.tag = "doorDouble";
    }
}
