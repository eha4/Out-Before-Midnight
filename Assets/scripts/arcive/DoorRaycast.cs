using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with

    private MyDoorController raycastedObj;
    private doubledoorcontroler raycastedObj2;
    public float timer = 1.5f; 
    private GameObject door;

    //[SerializeField] private KeyCode openDoorKey = KeyCode.E; //can change which key/button to interact

    [SerializeField] private Image crosshair = null; //the crosshair image
    private bool isCrosshairActive;
    private bool doOnce;
    public bool animruning = false;
    private const string interactableTag = "door";

    private void Update()
    {
        if(timer <= 0)
        {
            animruning = false;
        }
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //looks for object with the layer name and excludes other specific layers

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask)) //shoots raycast forward checking layers
        {
            if (hit.collider.gameObject.tag == "door")
            {
                door = hit.collider.gameObject;
            }

            Debug.Log("door raycast running");
            if (hit.collider.CompareTag(interactableTag)) //if it hits the object with the layer name
            {
                if (!doOnce)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>();    //to change the color of the crosshair to red if looking at the correct layer object
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey) && !animruning)
                {
                    raycastedObj = hit.collider.gameObject.GetComponent<MyDoorController>(); //if press E finds the specific gameobject name and plays the animation (might not work for multiple doors)
                    raycastedObj.PlayAnimation();
                    animruning = true;
                    timer = 1.5f;
                }
            }

            if (hit.collider.CompareTag("doorDouble"))
            {
                if (!doOnce)
                {
                    raycastedObj2 = hit.collider.gameObject.GetComponent<doubledoorcontroler>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey) && !animruning)
                {
                    raycastedObj2 = hit.collider.gameObject.GetComponent<doubledoorcontroler>();
                    raycastedObj2.PlayAnimation2();

                    //raycastedObj2.PlayAnimation3();
                    animruning = true;
                    timer = 1.5f;
                }
            }
            if (hit.collider.CompareTag("doorDouble2"))
            {
                if (!doOnce)
                {
                    raycastedObj2 = hit.collider.gameObject.GetComponent<doubledoorcontroler>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey) && !animruning)
                {
                    raycastedObj2 = hit.collider.gameObject.GetComponent<doubledoorcontroler>();
                    raycastedObj2.PlayAnimation3();
                    animruning = true;
                    timer = 1.5f;
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
        if (animruning)
        {
            timer = count(timer);
        }
    }
    private float count(float time)
    {
        float x = time;
         x -= Time.deltaTime;
        return x;
    }
    void CrosshairChange(bool on)
    {
        //to change the color of the crosshair
        if(on && !doOnce)
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
