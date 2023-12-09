using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toothscript : Interactable
{
    /*
    [SerializeField] private int rayLength = 2; //how far out the raycast goes
    [SerializeField] private LayerMask layerMaskInteract; //interact with this layer
    [SerializeField] private string excludeLayerName = null; //can exclude layers to not interact with

    private ObjectController raycastedObj2;

    [SerializeField] private KeyCode interactKey = KeyCode.E; //can change which key/button to interact
    */
    [SerializeField] private Image crosshair = null;
    //private bool isCrosshairActive;
    //private bool doOnce;

    public ObjectController objController;
    public GameObject JamesSounds;
    private AudioSource jAudioSource;
    private JamesSounds js;
    //private const string inspectableTag = "InspectableObject";

    // Start is called before the first frame update

    public Text interact;
    void Start()
    {
        jAudioSource = JamesSounds.GetComponent<AudioSource>();
        js = JamesSounds.GetComponent<JamesSounds>();
    }
    public override void OnFocus()
    {
        crosshair.color = Color.red;
        objController.ShowObjectName();
        interact.enabled = true;
    }

    public override void OnInteract()
    {
        jAudioSource.PlayOneShot(js.clips[Random.Range(0, 3)]);
        jAudioSource.PlayOneShot(js.clips[4]);
        journelTxt.toothpickedup += 1;
        objController.ShowExtraInfo();
        objController.HideObjectName();
        Destroy(gameObject);
        crosshair.color = Color.white;
        interact.enabled = false;
    }
    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        objController.HideObjectName();
        interact.enabled = false;
    }

    // Update is called once per frame
    /*void Update()
    {
        Debug.Log("toothscriptupdating");
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.up);
        Debug.DrawRay(transform.position, fwd, Color.red);
       

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength)) //shoots raycast forward checking layers
        {
            Debug.Log("toothscriptran");
            Debug.Log("inspector raycast running");
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("playerhittooth");
                if (Input.GetKeyDown(player.useKey))
                {
                    journelTxt.toothpickedup = true;
                    Destroy(gameObject);
                }
            }
        }
    */
}
