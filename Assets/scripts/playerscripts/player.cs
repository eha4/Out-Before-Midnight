using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text fragnumTxt;
    public static int numpickedup;
    public static int DeerAntlers;
    public static int bookNum;
    public static bool Bookpickedup;
    public static KeyCode useKey = KeyCode.E;
    public static float health;
    public static KeyCode journel = KeyCode.J;
    public GameObject journelcan;
    public GameObject maincan;
    public GameObject camcan;
    private bool journelon;
    public static bool[] placed = new bool[3] { false, false, false };
    public GameObject particle;
    //public screenshotscriptNewURP screenshotScript;
    public GameObject cameracanvas;
    public bool cameraActive;

    public GameObject pauseMenuUI;
    private bool pausemenuOn;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(bookNum);
        Debug.Log(Bookpickedup);
        health = 3;   
    }

    // Update is called once per frame
    void Update()
    {
        fragnumTxt.text = numpickedup + "/3 fragments";
        if (placed[0] == true && placed[1] == true&& placed[2] == true)
        {
            particle.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.C) && !pausemenuOn)
        {
            camUiState();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pausemenuOn == false)
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            GetComponent<FirstPersonController>().enabled = false;
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            pausemenuOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pausemenuOn)
        {
            gameObject.GetComponent<CharacterController>().enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<FirstPersonController>().enabled = true;
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            pausemenuOn = false;
        }
        // Debug.Log(player.health);
        if (Input.GetKeyDown(journel) && journelon == false && !pausemenuOn)
        {
            gameObject.GetComponent<CharacterController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            GetComponent<FirstPersonController>().enabled = false;
            journelcan.SetActive(true);
            maincan.SetActive(false);
            journelon = true;
            //screenshotScript.enabled = false;
        }
        else if(Input.GetKeyDown(journel) && journelon == true && !pausemenuOn)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameObject.GetComponent<CharacterController>().enabled = true;
            GetComponent<FirstPersonController>().enabled = true;
            journelcan.SetActive(false);
            maincan.SetActive(true);
            journelon = false;
            //screenshotScript.enabled = true;
        }
        if(health <= 0)
        {
            Death();
        }
    }
    public void camUiState()
    {
        cameracanvas.SetActive(!cameracanvas.active);
        cameraActive = !cameraActive;
    }
    public void ResumeGame()
    {
        gameObject.GetComponent<CharacterController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GetComponent<FirstPersonController>().enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausemenuOn = false;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Death()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
