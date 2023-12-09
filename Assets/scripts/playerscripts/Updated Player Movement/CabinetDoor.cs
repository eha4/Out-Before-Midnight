using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetDoor : Interactable
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    [SerializeField] private Animator anim;

    [SerializeField] private Image crosshair = null;
    //private bool isCrosshairActive;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public override void OnFocus()
    {
        crosshair.color = Color.red;
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;
            anim.SetBool("isOpen", isOpen);
        }
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
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
