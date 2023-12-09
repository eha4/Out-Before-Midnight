using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bookSpots : Interactable
{
    public GameObject manager;
    public int bookrequired;
    [SerializeField] private Image crosshair = null;
    public GameObject book;
    public Text interact;
    // Start is called before the first frame update
    void Start()
    {
      


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnFocus()
    {
        crosshair.color = Color.red;
        interact.enabled = true;
    }
    public override void OnInteract()
    {
        if(bookrequired == player.bookNum)
        {
            if (bookrequired == 0 && player.Bookpickedup == true)
            {
                manager.GetComponent<bookManager>().book1 = true;
                player.Bookpickedup = false;
                book.SetActive(true);
                interact.enabled = false;
            }
            else if (bookrequired == 1 && player.Bookpickedup == true)
            {
                manager.GetComponent<bookManager>().book2 = true;
                player.Bookpickedup = false;
                book.SetActive(true);
                interact.enabled = false;
            }
            else if (bookrequired == 2 && player.Bookpickedup == true)
            {
                manager.GetComponent<bookManager>().book3 = true;
                player.Bookpickedup = false;
                book.SetActive(true);
                interact.enabled = false;
            }
            else
                Debug.Log("no book");
        }
    }
    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        interact.enabled = false;
    }
}
