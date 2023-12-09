using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class corner1 : MonoBehaviour
{
    [SerializeField] private int rayLength = 5; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null;
    [SerializeField] private Image crosshair = null; //the crosshair image
    public bool turning;
    private bool isCrosshairActive;
    private bool doOnce;
    private const string interactableTag = "corner1";
    private const string interactableTag2 = "corner2";
    private const string interactableTag3 = "corner3";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!threeCornerspuzzle.corner1touched && !threeCornerspuzzle.corner2touched && !threeCornerspuzzle.corner3touched)
        {
            turning = false;
        }
       
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //looks for object with the layer name and excludes other specific layers

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) //shoots raycast forward checking layers
        {
            Debug.Log("raycast running");
            Debug.Log(hit.collider.tag);
            if (hit.collider.CompareTag(interactableTag)) //if it hits the object with the layer name
            {
                
                if (Input.GetKeyDown(player.useKey) && !turning)
                {
                    
                    threeCornerspuzzle.corner1touched = true;
                    turning = true;
                }
                if (!doOnce)
                {
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;
            }
            if (hit.collider.CompareTag(interactableTag2)) //if it hits the object with the layer name
            {
               

                if (Input.GetKeyDown(player.useKey) && !turning)
                {
                    threeCornerspuzzle.corner2touched = true;
                    turning = true;
                }
                if (!doOnce)
                {
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;
            }
            if (hit.collider.CompareTag(interactableTag3)) //if it hits the object with the layer name
            {
              

                if (Input.GetKeyDown(player.useKey) && !turning)
                {
                    threeCornerspuzzle.corner3touched = true;
                    turning = true;
                }
                if (!doOnce)
                {
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;
            }

        }
        else
        {
            if (isCrosshairActive) //if not looking at the correct layer object set crosshair color to white
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }

        void CrosshairChange(bool on)
        {
            if (on && !doOnce)
            {
                crosshair.color = Color.red;
            }
            else
            {
                crosshair.color = Color.white;
                isCrosshairActive = false;
            }
        }

    }

}
