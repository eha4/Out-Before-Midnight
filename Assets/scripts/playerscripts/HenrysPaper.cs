using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HenrysPaper : MonoBehaviour
{
    public int paper = 0;
    public Text textUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PaperNumber();
    }

    void PaperNumber()
    {
        switch (paper)
        {
            case 1:
                textUI.text = "apple";
                break;
            case 2:
                textUI.text = "banana";
                break;
            default:
                textUI.text = "";
                break;
        }
    }
}
