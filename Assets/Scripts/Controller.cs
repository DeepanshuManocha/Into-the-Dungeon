using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject infoPannel;

    public void Play()
    {
        SceneManager.LoadScene("HelloAR_Portal");
    }
   
    public void doExitGame() 
    {
        Application.Quit();
    }

    public void openInfo()
    {
        infoPannel.SetActive(true);
    }

    public void closeInfo()
    {
        infoPannel.SetActive(false);
    }
}
