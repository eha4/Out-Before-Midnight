using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactTableScript : Interactable
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip[] CaseSounds;
    private AudioSource audioSource;

    [SerializeField] private Image crosshair = null;
    //private bool isCrosshairActive;

    public Text interact;
    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnFocus()
    {
        crosshair.color = Color.red;
        interact.enabled = true;
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
            if(isOpen == true)
            {
                audioSource.PlayOneShot(CaseSounds[0]);
            }
            else if (isOpen == false)
            {
                audioSource.PlayOneShot(CaseSounds[1]);
            }
            interact.enabled = false;
        }
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        interact.enabled = false;
    }
    private void Animator_LockInteraction()
    {
        canBeInteractedWith = false;
    }

    private void Animator_UnlockInteraction()
    {
        canBeInteractedWith = true;
    }
}
