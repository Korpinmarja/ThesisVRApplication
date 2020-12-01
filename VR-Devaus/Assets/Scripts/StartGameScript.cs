 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{

    public void StartGame()
    {
        StartCoroutine(LoadTheGame());
    }

    public void StartTutorial()
    {
        StartCoroutine(LoadTheTutorial());
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator LoadTheGame()
    {
        // Loads the Scene in the background as the current Scene still runs
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CampfireDemo");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadTheTutorial()
    {
        // Loads the Scene in the background as the current Scene still runs
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TutorialScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
