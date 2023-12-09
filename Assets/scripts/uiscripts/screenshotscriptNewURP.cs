using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class screenshotscriptNewURP : MonoBehaviour
{
    private bool TakeScreenshot;

    public GameObject picturePreview;

    public Texture2D texture;

    public AudioSource audioSource;
    public AudioClip pictureTake;

    public float timer = 1.5f;
    public bool soundrunning = false;

    private void OnEnable()
    {
        RenderPipelineManager.endCameraRendering += RenderPipelineManager_endCameraRendering;
    }

    private void OnDisable()
    {
        RenderPipelineManager.endCameraRendering -= RenderPipelineManager_endCameraRendering;
    }

    private void RenderPipelineManager_endCameraRendering(ScriptableRenderContext arg1, Camera arg2)
    {
        if (TakeScreenshot)
        {
            TakeScreenshot = false;

            int width = Screen.width;
            int height = Screen.height;

            Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, width, height);
            screenshotTexture.ReadPixels(rect, 0, 0);
            screenshotTexture.Apply();

            byte[] byteArray = screenshotTexture.EncodeToPNG();
            if (!Directory.Exists(Application.persistentDataPath + "/" + "tempscreenshots"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/" + "tempscreenshots");
            }
            System.IO.File.WriteAllBytes(Application.persistentDataPath + "/tempscreenshots/CameraScreenshot.png", byteArray);

            picturePreview.GetComponent<RawImage>().texture = screenshotTexture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            soundrunning = false;
        }

        if (Input.GetMouseButtonDown(0) && !soundrunning)
        {
            TakeScreenshot = true;
            soundrunning = true;
            audioSource.PlayOneShot(pictureTake, 0.2f);
            timer = 1.5f;
        }
        if (soundrunning)
        {
            timer = count(timer);
        }
        
    }

    private float count(float time)
    {
        float x = time;
        x -= Time.deltaTime;
        return x;
    }
}