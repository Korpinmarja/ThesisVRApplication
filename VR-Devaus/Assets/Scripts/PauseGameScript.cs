using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameScript : MonoBehaviour
{
    
    //boolean value to pause and resume the game
    public static bool GameIsPaused = false;

    // Gameobject to hide and show pause menu screen
    public GameObject PauseMenuUI;

    
    // Pauses the game, pause made by stopping the time
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Return to game
    public void Resume() 
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    
    // Reload the scene
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().CampfireDemo);
    }

    //  Going back to StartScene
    public void GoToStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().StartScene);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    void Update() 
    {
        // Checks if the right Oculus button is pressed to pause or resume the game
        if (OVRInput.GetDown(OVRInput.Button.Start));
        {
            if (GameIsPaused == false)
            {
                Resume();
            }
            else //if (GameIsPaused == true) for my clarification
            {
                Pause();
            }
        }
    }

}
