using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Col_DMG_Player : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.health--;
        }
    }
}