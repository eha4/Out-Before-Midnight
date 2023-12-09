using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerRaycasts : MonoBehaviour
{
    [SerializeField] private int rayLength = 1; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool isCrosshairActive2;
    private bool doOnce;

    public Camera playerCam;
    private Camera hideCam;

    private hideScriptV1 hideScript;

    private const string hideTag = "HideObject";
    //-------------------------------------------------------------------------------------------------------------------------------------------
    [SerializeField] private int rayLength2 = 2; //how far out the raycast goes

    private ObjectController raycastedObj3;

    [SerializeField] private KeyCode interactKey = KeyCode.E; //can change which key/button to interact


    private const string inspectableTag = "InspectableObject";
    //--------------------------------------------------------------------------------------------------------------------------------------------
    [SerializeField] private int rayLength3 = 2; //how far out the raycast goes

    private MyDoorController raycastedObj;
    private doubledoorcontroler raycastedObj2;
    public float timer = 1.5f;
    private GameObject door;

    private bool doOnce2;
    public bool animruning = false;
    private const string interactableTag = "door";

    //--------------------------------------------------------------------------------------------------------------------------------------------
    public GameObject obliskfrag;
    private const string corner = "corner1";
    private const string corner2 = "corner2";
    private const string corner3 = "corner3";
    public bool turning;
    // Start is called before the first frame update
    void Start()
    {
        playerCam.enabled = true;
    }
    // Update is called once per frame
    private void Update()
    {
        //setting turning false if non of the corners are turning
        if (!threeCornerspuzzle.corner1touched && !threeCornerspuzzle.corner2touched && !threeCornerspuzzle.corner3touched)
        {
            turning = false;
        }
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value; //looks for object with the layer name and excludes other specific layers

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))  //shoots raycast forward checking layers
        {
            if (hit.collider.CompareTag(corner3))
            {
                if (Input.GetKeyDown(player.useKey) && !turning)
                {
                    threeCornerspuzzle.corner3touched = true;
                    turning = true;
                }
            }
            //-----------------------------------------------
            if (hit.collider.CompareTag(corner2) )
            {

                if (Input.GetKeyDown(player.useKey) && !turning)
                {
                    threeCornerspuzzle.corner2touched = true;
                    turning = true;
                }
            }
           //----------------------------------------------------------
            if (hit.collider.CompareTag(corner))
            {
                if (Input.GetKeyDown(player.useKey) && !turning)
                {

                    threeCornerspuzzle.corner1touched = true;
                    turning = true;
                }

            }
            //-------------------------------------------------------------------------------------------------------------------------
            if (hit.collider.CompareTag(hideTag))
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
            //-----------------------------------------------------------------------------------------------------------------------------
            if (timer <= 0)
            {
                animruning = false;
            }
            if (hit.collider.gameObject.tag == interactableTag)
            {
                door = hit.collider.gameObject;
            }

            //Debug.Log("door raycast running");
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
            //-----------------------------------------------------------------------------------------------------------------------------------------
            if (hit.collider.CompareTag(inspectableTag))
            {
                if (!doOnce)
                {
                    raycastedObj3 = hit.collider.gameObject.GetComponent<ObjectController>();
                    raycastedObj3.ShowObjectName();
                    CrosshairChange(true);
                }

                isCrosshairActive2 = true;
                //isCrosshairActive2 = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey))
                {
                    raycastedObj3.ShowExtraInfo();
                }
            }
            //-----------------------------------------------------------------------------------------------------------------------------------------
            if (hit.collider.CompareTag("lockedDoor"))
            {
                if (!doOnce)
                {
                    raycastedObj3 = hit.collider.gameObject.GetComponent<ObjectController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(player.useKey))
                {
                    raycastedObj3.ShowExtraInfo();
                }
            }
        }
        else if (isCrosshairActive2)
        {
            raycastedObj3.HideObjectName();
            CrosshairChange(false);
            doOnce = false;
        }
        else if (isCrosshairActive)
        {
            CrosshairChange(false);
            doOnce = false;
        }
        if (animruning)
        {
            timer = count(timer);
        }
    }
    //oblisk function 
    public void oblisk()
    {
        //to do
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
