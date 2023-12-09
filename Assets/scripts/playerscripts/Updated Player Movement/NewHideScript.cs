using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewHideScript : Interactable
{
    public GameObject cam;
    public GameObject playerObj;
    public GameObject SecondHideScript;
    public bool hidden;

    [SerializeField] private Image crosshair = null;

    public AudioSource audioSource;
    public AudioClip wardrobeEnter;

    public Text interact;
    public bool interactbool = false;
    private void Start()
    {
        cam.SetActive(false);
        hidden = false;
    }

    public override void OnFocus()
    {
        crosshair.color = Color.red;
        if (interactbool == false)
        {
            interact.enabled = true;
        }
    }

    public override void OnInteract()
    {
        if (hidden == false)
        {
            playerNothidden();
        }
        /*
        else if(hidden == true)
        {
            Playerhidden();

        }*/
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;

        interact.enabled = false;
    }
    /*
    public void Playerhidden()
    {
        //audioSource.PlayOneShot(wardrobeEnter, 0.5f);
        cam.SetActive(false);
        playerObj.SetActive(true);
        hidden = false;
    }
    */
    public void playerNothidden()
    {
        audioSource.PlayOneShot(wardrobeEnter, 0.5f);
        cam.SetActive(true);
        playerObj.SetActive(false);
        hidden = true;
        SecondHideScript.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(player.useKey) && hidden == true)
        {
            playerNothidden();
            hidden = false;
        }
    }
}
