using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threeCornerspuzzle : MonoBehaviour
{
    public GameObject[] corners;
    public GameObject obloisk;
    public float[] zrot = new float[3];
    public int Randomnum1;
    public int randomnum2;
    public static bool corner1touched;
    public static bool corner2touched;
    public static bool corner3touched;
    public int correctpos1;
    private float zcorner1;
    private float zcorner2;
    private float zcorner3;
    private float currentz1;
    private float currentz2;
    private float currentz3;
    private bool roated1;
    private bool roated2;
    private bool roated3;
    private bool run;
    private float x;
    private Animator anim;
    public GameObject fragment;
    public quest y;
    // Start is called before the first frame update
    void Start()
    {
        anim = obloisk.gameObject.GetComponent<Animator>();
        //sets starting corner pos
        // zcorner1 = 300.0f;
        //  zcorner2 = 180.0f;
        // zcorner3 = 0.0f;
        //shuffles the starting rotation of all the bojects
        //Shuffle(corners[0]);
        // Shuffle(corners[1]);
        // Shuffle(corners[2]);
    }

    // Update is called once per frame
    void Update()
    {
       
        if(x >= 500)
        {
            run = true;

        }
        /*   // sets the absolutevalue of the current corners
           currentz1 = corners[0].transform.localRotation.eulerAngles.z;
           currentz2 = corners[1].transform.localRotation.eulerAngles.y;
           currentz3 = corners[2].transform.localRotation.eulerAngles.z;
           Debug.Log(currentz3);
           Debug.Log(zcorner3);
           Debug.Log(currentz1 == zcorner1);
           Debug.Log(currentz2 == zcorner2);
           Debug.Log(currentz2 == zcorner3);
          */

        // when everything rotated do this
        if (roated1 == true && roated2 == true && roated3 == true && run == false)
        {
            Door.islocked = false;
            anim.SetBool("run", true);
            y.x = "\"Find The Ichor Fragments\"";

        }
   
        //checks if one of the corners is being interacted with then roates them if it is
        if (corner1touched == true)
        {
            Rotate(corners[0], corners[1]);
            corner1touched = false;
            roated1 = !roated1;
        }
        if (corner2touched == true)
        {
            Rotate(corners[1], corners[2]);
            corner2touched = false;
            roated2 = !roated2;
        }
        if(corner3touched == true)
        {
            Rotate(corners[2], corners[0]);
            corner3touched = false;
            roated3 = !roated3;
        }
    }
    
    private void Rotate(GameObject rotated1, GameObject rotated2)//rotate function
    {
        Debug.Log("running rotate");
        rotated1.GetComponent<AudioSource>().Play();
       // rotated2.GetComponent<AudioSource>().Play();
        rotated1.transform.Rotate(0, 0, 120);
        //rotated2.transform.Rotate(0, 0, 60);
        //rotated3.transform.Rotate(0, 0, 30);
    }
}
