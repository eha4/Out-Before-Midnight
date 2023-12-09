using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryHideScript : MonoBehaviour
{
    public GameObject cam;
    public GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.useKey))
        {
            Playerhidden();
        }
    }

    public void Playerhidden()
    {
        //audioSource.PlayOneShot(wardrobeEnter, 0.5f);
        cam.SetActive(false);
        playerObj.SetActive(true);
        gameObject.SetActive(false);
    }
}
