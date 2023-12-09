using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camerascreenshot : MonoBehaviour
{
    private static camerascreenshot instance;

    private Camera myCamera;
    private bool takeScreenshotOnNextFrame;
    public string[] xx;
    int picturecount;
    Image flashImage = null;
    public float timer = 1f;
    public bool flashing = false;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
        flashImage = GetComponent<Image>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/tempscreenshots/CameraScreenshot" + picturecount.ToString() + ".png", byteArray);
            picturecount += 1;
            Debug.Log("Saved CameraScreenshot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenshotOnNextFrame = true;
    }

    void Update()
    {
        /*if(timer <= 0)
        {
            flashing = false;
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            instance.TakeScreenshot(Screen.width, Screen.height);

            //flashing = true;
            //timer = 1;
        }
        /*if (flashing)
        {
            timer = count(timer);
        }*/
    }
    /*
    public void CameraFlash(float flashseconds, float maxAlpha, Color newColor)
    {
        flashImage.color = newColor;

        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        Color colorthisFrame = flashImage.color;
        colorthisFrame.a = Mathf.Lerp(0, maxAlpha, count(flashseconds));
    }

    public float count(float flashseconds)
    {
        float x = flashseconds;
        x -= Time.deltaTime;
        return x;
    }
    */
}