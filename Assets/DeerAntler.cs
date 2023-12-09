using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeerAntler : Interactable
{
    public Animator anim;
    [SerializeField] private Image crosshair = null;
    private AudioSource audioSource;
    private bool animplayed = false;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    public override void OnFocus()
    {
        crosshair.color = Color.red;
    }

    public override void OnInteract()
    {
        if (!animplayed)
        {
            animplayed = true;
            player.DeerAntlers++;
            anim.Play("Anim");
            audioSource.Play();
        }
        
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
    }

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
