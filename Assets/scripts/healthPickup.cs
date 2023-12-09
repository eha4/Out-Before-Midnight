using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickup : Interactable
{
    public override void OnFocus()
    {

    }
    public override void OnInteract()
    {
        if (player.health < 3) {
            player.health += 1;
            Destroy(gameObject);
        }
    }
    public override void OnLoseFocus()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
