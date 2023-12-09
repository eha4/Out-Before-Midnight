using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PhotoCapture : MonoBehaviour
{
    public GameObject playerObj;
    [Header("Photo Taker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    //[SerializeField] private GameObject cameraUI;

    [Header("Flash Effect")]
    [SerializeField] private GameObject cameraFlash;
    [SerializeField] private float flashTime;
    public AudioClip camFlash;
    public AudioClip camStun;
    private AudioSource audioSource;

    [Header("Photo Fader Effect")]
    [SerializeField] private Animator fadingAnimation;
    private float time;
    public bool phototaken;
    private Texture2D screenCapture;
    private bool viewingPhoto;
    private int i = 0;
    public GameObject journels;
    private Sprite[] photoSprite = new Sprite[16] {null,null,null,null,null,null,null,null, null, null, null, null, null, null, null, null };
    private int count = 0;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (phototaken == true)
        {
            time += Time.deltaTime;
        }
        if (time >= 4)
        {
            RemovePhoto();
            phototaken = false;
            time = 0;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            time = 5;
            RemovePhoto();
        }
        if (Input.GetMouseButtonDown(0) && playerObj.GetComponent<player>().cameraActive == true && phototaken == false)
        {
            audioSource.PlayOneShot(camFlash);
            Debug.Log("this should be playing");
            phototaken =  true;
            if (!viewingPhoto)
            {
                StartCoroutine(CapturePhoto());

            
            }
            else
            {
                RemovePhoto();
            }
        }
    }

    IEnumerator CameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);
    }
    private Sprite spritecreator()
    {
        return Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
      
    }
    IEnumerator CapturePhoto()
    {
        playerObj.GetComponent<player>().camUiState();
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        viewingPhoto = true;

        yield return new WaitForEndOfFrame();

        Rect regionToRead = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRead, 0, 0, false);
        screenCapture.Apply();

        byte[] byteArray = screenCapture.EncodeToPNG();
        if (!Directory.Exists(Application.persistentDataPath + "/" + "tempscreenshots"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + "tempscreenshots");
        }
        if (i == 16)
        {
            i = 0;
        }
        if(i == 0)
        {
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/tempscreenshots/CameraScreenshot.png", byteArray);
            i++;
        }
        else
        {
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/tempscreenshots/CameraScreenshot" + i.ToString() + ".png", byteArray);
            i++;
        }

        ShowPhoto();
    }

    void ShowPhoto()
    {

        photoSprite[count] = spritecreator(); 
        photoDisplayArea.sprite = photoSprite[count];
         journel.addnewsprite(photoSprite[count]);
        photoFrame.SetActive(true);
        StartCoroutine(CameraFlashEffect());

        fadingAnimation.Play("PhotoFade");
        if (count < 16) 
            count++;
        else 
            count = 0;
       
    }

    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
        playerObj.GetComponent<player>().camUiState();
    }


}
