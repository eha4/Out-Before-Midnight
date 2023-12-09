using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneloadings : MonoBehaviour
{
    public string Url;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void manorscene()
    {
        SceneManager.LoadScene("ManorTest");
    }

    public void endgame()
    {
        Application.Quit();
    }

    public void URL()
    {
        Application.OpenURL(Url);
    }

    public void titlescreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
