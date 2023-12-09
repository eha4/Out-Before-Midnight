using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fragmentpickup : Interactable
{
    [SerializeField] private int rayLength = 2; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with
  
    [SerializeField] private Image crosshair = null;
    public GameObject JSounds;
    private AudioSource aS;
    private JamesSounds jS;

    public GameObject obliskfrag;

    public ObjectController objController;

    public Text interact;
    // Start is called before the first frame update
    void Start()
    {
        aS = JSounds.GetComponent<AudioSource>();
        jS = JSounds.GetComponent<JamesSounds>();
    }
    public override void OnFocus()
    {
        crosshair.color = Color.red;
        objController.ShowObjectName();
        interact.enabled = true;
    }

    public override void OnInteract()
    {
        int x = Random.Range(0, 2);
        // b.PlayOneShot(clips[x]);
        if (fragment.pickedup == false)
        {
            player.numpickedup++;
            aS.PlayOneShot(jS.clips[Random.Range(0, 3)]);
            fragment.pickedup = true;
        }
        else if (fragment2.pickedup2 == false)
        {
            
            player.numpickedup++;
            aS.PlayOneShot(jS.clips[Random.Range(0, 3)]);
            fragment2.pickedup2 = true;
        }
        else if (fragment3.pickedup3 == false)
        {
            player.numpickedup++;
            aS.PlayOneShot(jS.clips[Random.Range(0, 3)]);
            fragment3.pickedup3 = true;
        }
        
        objController.ShowExtraInfo();
        objController.HideObjectName();
        crosshair.color = Color.white;
        gameObject.SetActive(false);
        interact.enabled = false;
    }
    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        objController.HideObjectName();
        interact.enabled = false;
    }
    // Update is called once per frame

}
