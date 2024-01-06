using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Kitchen_Level");
    }

    public void PlayTutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
