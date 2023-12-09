using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fragment : MonoBehaviour
{
    //public GameObject pickupablefrag;
    public static bool pickedup;
  
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
        Debug.Log("pickedup" + pickedup.ToString());
        Debug.Log("trigger enterd");
        if (pickedup && Input.GetKeyDown(player.useKey))
        {
            //player.numpickedup++;
            animplayed = true;
            Debug.Log("interacted");
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            anim.SetBool("true", true);
            gameObject.GetComponent<AudioSource>().Play();
            player.placed[0] = true;

        }
        objectController = objectController.gameObject.GetComponent<ObjectController>();
        objectController.ShowExtraInfo();
        //Destroy(GetComponent<ObjectController>());
    }
    
}
