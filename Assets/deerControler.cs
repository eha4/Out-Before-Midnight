using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deerControler : MonoBehaviour
{
    public GameObject fragment;
    public int x;
    public bool doonce;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (player.DeerAntlers == x)
            if (!doonce)
            {
                fragment.SetActive(true);
                doonce = true;
            }
            
    }
}
