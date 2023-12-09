using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotesScript : Interactable
{
    [SerializeField] private Image crosshair = null;
    public bool noteOpen = false;
    public bool textOpen = false;

    public GameObject note;
    public GameObject textUI;

    public int paper = 0;
    public Text text;

    private AudioSource aS;

    public Text interact;
    public bool interactbool = false;
    private void Start()
    {
        aS = GetComponent<AudioSource>();
    }
    public override void OnFocus()
    {
        crosshair.color = Color.red;
        if (interactbool == false)
        {
            interact.enabled = true;
        }
    }

    public override void OnInteract()
    {
        if (noteOpen == false)
        {
            noteOpen = true;
            textOpen = true;
            aS.Play();

            note.SetActive(true);
            textUI.SetActive(true);

            PaperNumber();

            interact.enabled = false;
            interactbool = true;
        }
        else if(noteOpen == true && textOpen == true && Input.GetKeyDown(player.useKey))
        {
            noteOpen = false;
            textOpen = false;

            note.SetActive(false);
            textUI.SetActive(false);

            interact.enabled = true;
            interactbool = false;
        }
    }

    public override void OnLoseFocus()
    {
        crosshair.color = Color.white;
        noteOpen = false;
        textOpen = false;

        note.SetActive(false);
        textUI.SetActive(false);

        interact.enabled = false;
        interactbool = false;
    }

    void PaperNumber()
    {
        switch (paper)
        {
            case 1:
                text.text = "Controls: \n WASD for movement.\n Q to recharge battery.\n E to interact with everything.\n Shift to run. C to pull up camera.\n When camera is up Left click to take  picture \n Right click to flash for stun.\n Control to crouch  ";
                break;
            case 2:
                text.text = "The beast that roams this manor was originally Arthour J Frontweurth. This is his trophy room, and he collected a bit of everything. When I first got to this manor, this was the one of the first rooms I visited, he likes to keep this room pristine as there is some bit of humanity left in him. I tried to take the sword out of its case however its bolted down so there is no use in using that. He almost caught me the first time in the room, however I hid in one of the wardrobes, I would suggest you do the same.";
                break;
            case 3:
                text.text = "James if you’re reading this, you are in grave danger. I know you would come look for me, so I have written notes and scattered them through this decrepit manor to help you understand what’s going on.";
                break;
            case 4:
                text.text = "This is the Obelisk; the paranormal press doesn’t know much about this.There is a being of pure malice that lies dormant within its Marble casing. You have to deactivate it by placing its fragments back into its spot, I was foolish enough to remove them to begin with, I know you will do me proud James” ";
                break;
            case 5:
                text.text = "This being is very dangerous, you have never dealt with something as powerful as this.Be vigilant James";
                break;
            case 6:
                text.text = " This is where I would hide and monitor him during the daytime. He is a nocturnal creature similar to bats. There is not much edible food in the house so I do what I can to get by. I’ve found articles of clothing in my investigation here indicating that there have been previous victims. I’ve noticed that there are no remains of any of the victims around the manor. Im still not sure what he truly does with them, maybe he eats everything?  ";
                break;
            case 7:
                text.text = " This is huge…James if you find this you have to warm the paranormal press about this. The Frontweurth family has know about this Obelisk for decades. It holds immense power and is incredibly evil. The Center piece in the middle of the parlor room needs to be shut down. You have to find the ichor fragments and place them back into place. I can hear the duke coming, I have to figure a way out of here. Stay vigilant and make sure that the press hears about this james. \n Henry signing off. ";
                break;
            default:
                text.text = "";
                break;
            
        }
    }
}
