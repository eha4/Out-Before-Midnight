using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class textupdater : MonoBehaviour
{

    
    public int index;

    private void OnTriggerEnter(Collider other)
    {
        journel.addNewTxt(index);
        
    }
}
