using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bookManager : MonoBehaviour
{
    public bool book1;
    public bool book2;
    public bool book3;
    private bool doonce;
    public GameObject fragment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (book1 == true && book2 == true && book3 == true)
        {
            if (!doonce)
            {
                fragment.SetActive(true);
                doonce = true;
            }
        }
    }
}
