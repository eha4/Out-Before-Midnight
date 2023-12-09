using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with

    private ObjectController raycastedObj2;

    [SerializeField] private KeyCode interactKey = KeyCode.E; //can change which key/button to interact

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string inspectableTag = "InspectableObject";

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //looks for object with the layer name and excludes other specific layers

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) //shoots raycast forward checking layers
        {
            Debug.Log("inspector raycast running");
            if (hit.collider.CompareTag(inspectableTag))
            {
                if (!doOnce)
                {
                    raycastedObj2 = hit.collider.gameObject.GetComponent<ObjectController>(); //to change the color of the crosshair to red if looking at the correct layer object
                    raycastedObj2.ShowObjectName();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey))
                {
                    raycastedObj2.ShowExtraInfo();
                }
            }
        }
        else
        {
            if (isCrosshairActive) //if not looking at the correct layer object set crosshair color to white
            {
                raycastedObj2.HideObjectName();
                CrosshairChange(false);
                doOnce = false;
            }
        }

    }

    void CrosshairChange(bool on)
    {
        //to change the color of the crosshair
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
    void itempickedup()
    {


    }
}
