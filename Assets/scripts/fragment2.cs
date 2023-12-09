using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fragment2 : MonoBehaviour
{
    //public GameObject pickupablefrag;
    public static bool pickedup2;

    private Animator anim;
    public ObjectController objectController;
    private float timer;
    private bool animplayed;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("pickedup" + pickedup2.ToString());
        Debug.Log("trigger enterd");
        if (pickedup2 && Input.GetKeyDown(player.useKey))
        {
          //  player.numpickedup++;
            animplayed = true;
            Debug.Log("interacted");
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            anim.SetBool("true", true);
            gameObject.GetComponent<AudioSource>().Play();
            player.placed[1] = true;

        }
        objectController = objectController.gameObject.GetComponent<ObjectController>();
        objectController.ShowExtraInfo();
       // Destroy(GetComponent<ObjectController>());
    }

}
