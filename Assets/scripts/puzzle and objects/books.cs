using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class books : Interactable
{
    [SerializeField] private Image crosshair = null;

    public int bookNum = 0;
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
        if (player.Bookpickedup != true)
        {

            player.bookNum = this.bookNum;
            player.Bookpickedup = true;
            Destroy(gameObject);
            crosshair.color = Color.white;
            interact.enabled = false;
        }
        else
            Debug.Log("already have book");
    }
    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        interact.enabled = false;
    }

}
