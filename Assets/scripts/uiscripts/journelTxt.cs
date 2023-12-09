using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class journelTxt : MonoBehaviour
{
    public Image page;
    public Sprite[] pages;
   
    public GameObject[] pickupable;
    public GameObject[] pickableImages;
    public static int toothpickedup;
    public Text toothtxt;
    //public static int textnum;
    public GameObject page2;
    public GameObject page1;
    public GameObject page3;
    public GameObject page4;
    // Start is called before the first frame update
    private AudioSource aS;
    void Start()
    {
        toothtxt.text = "Teeth collected 0/5";
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        toothtxt.text = "Teeth collected " + toothpickedup + "/5";
    }
   
    // Start is called before the first frame update
     
    public void button1()
    {
        page3.SetActive(false);
        page2.SetActive(false);
        page1.SetActive(true);
        page4.SetActive(false);
        page.sprite = pages[0];
        
    }
    public void button2()
    {
        page3.SetActive(false);
        page2.SetActive(true);
        page1.SetActive(false);
        page4.SetActive(false);
        page.sprite = pages[1];
      
    }
    public void button3()
    {
        page2.SetActive(false);
        page1.SetActive(false);
        page3.SetActive(true);
        page.sprite = pages[2];
        page4.SetActive(false);
    }
    public void button4()
    {
        page3.SetActive(false);
        page2.SetActive(false);
        page1.SetActive(false);
        page4.SetActive(true); 

        page.sprite = pages[3];
    }
}
