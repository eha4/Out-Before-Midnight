using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthtxt : MonoBehaviour
{
    public Image[] healthimg;
    public Image flashlightImg;
    public Image indicatorLight;
   // Coroutine currentflashRoutine = null;
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.health == 3)
        {
            healthimg[0].enabled = true;
            healthimg[1].enabled = true;
            healthimg[2].enabled = true;
        }
        if (player.health == 2)
        {
            healthimg[0].enabled = true;
            healthimg[1].enabled = true;
            healthimg[2].enabled = false;
        }
        if (player.health == 1)
        {
            healthimg[0].enabled = true;
            healthimg[1].enabled = false;
            healthimg[2].enabled = false;
        }
        if (player.health == 0)
        {
            healthimg[0].enabled = false;
            healthimg[1].enabled = false;
            healthimg[2].enabled = false;
        }
        flashlightImg.GetComponent<Image>().fillAmount = flashlight.powerCur/100;
        if(flashlight.powerCur <= 25)
        {

          
        }
    }
   /* private void Startflash(float secondsForFlash, Color newColor)
    {
        indicatorLight.GetComponent<Image>().color = newColor;
        if(currentflashRoutine != null)
        {
            StopCoroutine(currentflashRoutine);
        }
        currentflashRoutine = StartCoroutine(flashfunc(secondsForFlash));
    }
    IEnumerator flashfunc(float secondsForOneFlash)
    {
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t+= Time.deltaTime)
        {
            Color colorThisFrame = indicatorLight.GetComponent<Image>().color;
            colorThisFrame.a
        }
    }*/
}
