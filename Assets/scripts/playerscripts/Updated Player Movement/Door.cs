using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Interactable
{
    public static bool islocked = true;
    public bool isOpen = false;
    public bool permaLocked;
    private bool canBeInteractedWith = true;
    private Animator anim;

    public ObjectController objController;

    [SerializeField] private Image crosshair = null;

    public AudioSource audioSource;
    public AudioClip doorOpening;
    public AudioClip doorClosing;
    public AudioClip doorLocked;

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
        if (islocked == true)
        {
            objController.ShowExtraInfo();
            audioSource.PlayOneShot(doorLocked);
        }
        if (islocked != true && permaLocked == false)
        {
            if (canBeInteractedWith)
            {
                isOpen = !isOpen;

                Vector3 doorTransformDirection = transform.TransformDirection(Vector3.down);
                Vector3 playerTransformDirection = FirstPersonController.instance.transform.position - transform.position;
                float dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

                anim.SetFloat("dot", dot);
                anim.SetBool("isOpen", isOpen);

                if (isOpen == true)
                {
                    audioSource.PlayOneShot(doorOpening, 0.7f);
                }
                else if (isOpen == false)
                {
                    audioSource.PlayOneShot(doorClosing, 0.7f);
                }

                StartCoroutine(AutoClose());
            }
        }
        if (permaLocked == true)
        {
            objController.ShowExtraInfo();
            audioSource.PlayOneShot(doorLocked, 0.7f);
        }
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
    }

    private IEnumerator AutoClose()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(2);

            if(Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) > 5 && isOpen == true)
            {
                isOpen = false;
                anim.SetFloat("dot", 0);
                anim.SetBool("isOpen", isOpen);
                audioSource.PlayOneShot(doorClosing, 0.7f);
            }
        }
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
