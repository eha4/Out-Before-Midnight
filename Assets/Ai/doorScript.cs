using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    void OnTriggerEnter (Collider other)
    {
       // Debug.Log("----------------------------------- Duke entered the trigger");

        if (other.gameObject.name == "DukePrototype")
        {
            GameObject.Find("DukePrototype").GetComponent<Collider>().isTrigger = true;
            GameObject.Find("DukePrototype").GetComponent<dukeAI>().walkingThroughDoor = true;
        }
        //GameObject.Find("DukePrototype").GetComponent<dukeAI>().animation.SetBool("isAttacking", false);
        //GameObject.Find("DukePrototype").GetComponent<dukeAI>().animation.SetBool("isCrouching", true);
    }

    void OnTriggerStay (Collider other)
    {
        //Debug.Log("----------------------------------- Duke is within the trigger");
        if (other.gameObject.name == "DukePrototype")
        {
            GameObject.Find("DukePrototype").GetComponent<Collider>().isTrigger = true;
            GameObject.Find("DukePrototype").GetComponent<dukeAI>().walkingThroughDoor = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
       // Debug.Log("----------------------------------- Duke exited the trigger");
        if (other.gameObject.name == "DukePrototype")
        {
            GameObject.Find("DukePrototype").GetComponent<Collider>().isTrigger = false;
            GameObject.Find("DukePrototype").GetComponent<dukeAI>().walkingThroughDoor = false;
        }
    }
}
