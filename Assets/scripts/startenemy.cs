using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startenemy : MonoBehaviour
{
    public tempAI tempii;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        tempii = enemy.GetComponent<tempAI>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("rantrigger");
            tempii.playernear = true;
      
    }
}