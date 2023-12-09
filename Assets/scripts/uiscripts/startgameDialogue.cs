using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startgameDialogue : MonoBehaviour
{
    public ObjectController objectController;

    // Start is called before the first frame update
    void Start()
    {
        //objectController = objectController.gameObject.GetComponent<ObjectController>();
        //objectController.ShowExtraInfo();
        OneTimeDialouge();
    }

    // Update is called once per frame
    void Update()
    {
        //objectController = objectController.gameObject.GetComponent<ObjectController>();
        //objectController.ShowExtraInfo();
    }

    public void OneTimeDialouge()
    {
        objectController = objectController.gameObject.GetComponent<ObjectController>();
        objectController.ShowExtraInfo();
    }
}
