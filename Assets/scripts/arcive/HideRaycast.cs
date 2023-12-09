using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 1; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    public Camera playerCam;
    private Camera hideCam;

    private hideScriptV1 hideScript;

    private const string inspectableTag = "HideObject";

    private void Start()
    {
        playerCam.enabled = true;
        //hideCam.enabled = false;
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //looks for object with the layer name and excludes other specific layers

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) //shoots raycast forward checking layers
        {
            if (hit.collider.CompareTag(inspectableTag))
            {
                hideCam = hit.collider.GetComponent<Camera>();
                if (!doOnce)
                {
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey))
                {
                    hideScript = hit.collider.gameObject.GetComponent<hideScriptV1>();
                    hideScript.playerNothidden();
                }
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
}
