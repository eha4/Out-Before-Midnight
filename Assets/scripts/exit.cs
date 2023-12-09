using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class exit : Interactable
{
    [SerializeField] private Image crosshair = null;
    public static bool[] placed = new bool[3] { false, false, false };

    public override void OnFocus()
    {
        crosshair.color = Color.red;
    }

    public override void OnInteract()
    {
        
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (player.placed[0] == true && player.placed[1] == true && player.placed[2] == true)
        {
            player.placed[0] = false;
            player.placed[1] = false;
            player.placed[2] = false;
            SceneManager.LoadScene("WinScreen");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (player.placed[0] == true && player.placed[1] == true && player.placed[2] == true)
        {
            SceneManager.LoadScene("WinScreen");
        }
     */
    }
}
