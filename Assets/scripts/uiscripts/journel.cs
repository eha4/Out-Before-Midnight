using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class journel : MonoBehaviour
{ 
    
    //all the text in the game

    public static string[] alltxts = { "This place doesn’t look inhabited on the outside, however inside there are lit candles. Perhaps the groundskeeper is inside?", 
        "There is a lot of interesting and valuable items here, I wonder why none of them have been stolen or destroyed over the years.",
        "There appears to be a ball room in this manor, I hear whispers and chatter when I enter this room, as if the guests who danced here haven’t left.", 
        "There appears to be some sort of Study where this monster must have housed his books and research."
            , "My god, there’s a huge vampiric monster here that is adorned in torn Victorian clothing. I can’t write this down fast enough, I need a picture of this beast for the paper!",
        "The smell from the kitchen is unbearable. There is rot and flies throughout the room. " };
    //pages for the journel
    public static string[,] pages = new string[1, 6];
    
    //public int[,] pagesfull = new int[4, 1];
    // tracks if text has been added to a page
    public static int[,] pagesaddtxts = new int[1, 6] { { 0, 0, 0, 0, 0, 0 } };
    // Start is called before the first frame update
    public static Sprite[,] sprtpages = new Sprite[4,4] { { null, null, null, null }, { null, null, null, null }, { null, null, null, null }, { null, null, null, null } };
    public static int[,] pagesaddsprt = new int[4, 4] { { 0, 0, 0, 0}, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }};
   
    private bool full;
    public Image images;
    public Image images1;
    public Image images2;
    public Image images3;
    public int pagenum = 0;
    public int pagenumtxts = 0;
    public GameObject cameramanager;
    public GameObject playerObj;
    public Text[] texts = new Text[6];
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(player.journel))
        {
            textpage();
        }
    }
  /*  public void pageadder()
    {
        if(pagenum < 4|| pagenumtxts < texts.Length)
        {
        pagenum += 1;
        pagenumtxts += 1;
        }
    }
     */   
    public static void addnewsprite(Sprite currentsprite)
    {

        Sprite addersprite =  currentsprite;

            int currentpagex = -1;
            int currentpagez = -1;
            int z;
            int i;
            for (i = 0; i < 4; i++)
            {

                Debug.Log(i + "i equals");
                for (z = 0; z < 4; z++)
                {
                    Debug.Log(z + "z equals");
                    if (pagesaddsprt[i, z] == 0)
                    {
                        currentpagex = i;
                        currentpagez = z;
                       
                        break;

                    }
                    else if (pagesaddsprt[3,3] == 1)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            for (int m = 0; m < 6; m++)
                            {
                                pagesaddsprt[y, m] = 0;
                            }
                        }
                        currentpagex = 0;
                        currentpagez = 0;
                        break;
                    }

                }
                if (currentpagex == i && currentpagez == z)
                {
                    break;
                }


            }
             Debug.Log(pagesaddsprt);
            Debug.Log(sprtpages[currentpagex, currentpagez]);
            pagesaddsprt[currentpagex, currentpagez] = 1;
           
            Debug.Log(pagesaddsprt);
            sprtpages[currentpagex, currentpagez] = addersprite;
              Debug.Log(sprtpages[currentpagex, currentpagez]);
            Debug.Log(sprtpages[currentpagex, currentpagez].GetInstanceID());
        




    }
    public void jounelpageimg()
    {
       
        for(int i = 0; i < 4; ++i)
        {
            Sprite temp = sprtpages[pagenum, i];
            Debug.Log(sprtpages[pagenum, i].GetInstanceID());
           
            if (i == 0)
            {
                Debug.Log(sprtpages[pagenum, i] == sprtpages[pagenum, i + 1]);
                Debug.Log(sprtpages[pagenum, i] == temp);
                images.sprite = temp;
            }
            if (i == 1)
            {
                Debug.Log(sprtpages[pagenum, i] == sprtpages[pagenum, i + 1]);
                Debug.Log(sprtpages[pagenum, i] == temp);
                images1.sprite = temp;
            }
            if (i == 2)
            {
                Debug.Log(sprtpages[pagenum, i] == sprtpages[pagenum, i + 1]);
                Debug.Log(sprtpages[pagenum, i] == temp);
                images2.sprite = temp;
            }
            if (i == 3)
            {
                Debug.Log(sprtpages[pagenum, i] == temp);
                images3.sprite = temp;
            }

        }
    }
    public void textpage()
    {
        for(int i = 0; i < texts.Length; i++)
        {
            texts[i].text = pages[pagenumtxts, i];
        }
    }
    public static void addNewTxt(int index)
    {
        int z;
        int i;
        //saves location
        int currentpagei = -1;
        int currentpagez = -1;
        //nested loop to go through pages and check if there is text there yet
        for( i = 0; i < pages.Length; i++)
        {
            for( z = 0; z < pages.GetUpperBound(0)+1; z++)
            {
                if (pagesaddtxts[i, z] == 0)
                {
                    currentpagei = i;
                    currentpagez = z;
                    break;
                }
                else
                    continue;
            }
            if (currentpagei == i && currentpagez == z)
            {
                break;
            }
        }
        //for(int y)
        // addes text to current pages
        pages[currentpagei, currentpagez] = alltxts[index];
        //informs that txt has been added
        pagesaddtxts[currentpagei, currentpagez] = 1;
    }
}
