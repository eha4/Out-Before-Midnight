using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneTimeDialouge : MonoBehaviour
{
    public ObjectController objectController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            objectController = objectController.gameObject.GetComponent<ObjectController>();
            objectController.ShowExtraInfo();
            Destroy(this);
        }
    }
}
