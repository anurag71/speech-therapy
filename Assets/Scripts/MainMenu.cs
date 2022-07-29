using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetTrialSet()
    {
        ApplicationModel.set = 1;
        PlayGame();
    }

    public void SetPreTestingSet()
    {
        ApplicationModel.set = 2;
        PlayGame();
    }

    public void SetPracticeSet()
    {
        ApplicationModel.set = 3;
        PlayGame();
    }

    public void SetPostTestingSet()
    {
        ApplicationModel.set = 4;
        PlayGame();
    }

}
