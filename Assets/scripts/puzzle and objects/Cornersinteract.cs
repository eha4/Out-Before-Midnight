using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cornersinteract : Interactable
{
    public bool turning;
    public int cornernum;
    [SerializeField] private Image crosshair = null;

    public Text interact;
    public override void OnFocus()
    {
        crosshair.color = Color.red;
        interact.enabled = true;
    }

    public override void OnInteract()
    {
        if (cornernum == 3 && !turning)
        {
            threeCornerspuzzle.corner3touched = true;
            turning = true;
        }
        //-----------------------------------------------

        if (cornernum == 2 && !turning)
        {
            threeCornerspuzzle.corner2touched = true;
            turning = true;
        }

        //----------------------------------------------------------


        if (cornernum == 1 && !turning)
        {

            threeCornerspuzzle.corner1touched = true;
            turning = true;
        }
    }
    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        interact.enabled = false;
    }
    private void Update()
    {
        //setting turning false if non of the corners are turning
        if (!threeCornerspuzzle.corner1touched && !threeCornerspuzzle.corner2touched && !threeCornerspuzzle.corner3touched)
        {
            turning = false;
        }
    }
}
