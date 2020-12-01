using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameScript : MonoBehaviour
{
    
    //boolean value to pause and resume the game
    public static bool GameIsPaused = false;

    // Gameobject to show and hide pause menu screen
    public GameObject PauseMenuUI;

    //Gameobject to show locations menu screen
    public GameObject LocationsUI;

    //Gameobject to show hints menu screen
    public GameObject HintsUI;

    // Gameobject to give us a laser pointer
    public GameObject LaserPointer;

    // Gameobject to disable teleporting when game is paused
    public GameObject DisableTeleport;

    // Gameobject for player to know where we are when paused
    public GameObject FollowPlayer;

    
    // Pauses the game, pause made by stopping the time
    public void Pause()
    {
        DisableTeleport.SetActive(false);
        
        //Show all pause menu UI
        PauseMenuUI.SetActive(true);
        LocationsUI.SetActive(true);
        HintsUI.SetActive(true);
        
        PauseLocation();
        
        LaserPointer.SetActive(true);

        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    // Return to game and hide pause menu
    public void Resume() 
    {
        //Hide all pause menu UI
        PauseMenuUI.SetActive(false);
        LocationsUI.SetActive(false);
        HintsUI.SetActive(false);

        LaserPointer.SetActive(false);
        
        Time.timeScale = 1f;
        GameIsPaused = false;
        
        DisableTeleport.SetActive(true);
    }
    
    // Reload the Campfire scene
    /*
    public void ReloadCampfire()
    {
        StartCoroutine(ReloadTheGame());
    }
    // Reload the Campfire tutorial
    public void ReloadTotr()
    {
        StartCoroutine(ReloadTheGame());
    }
    */

    //  Going back to StartScene
    public void GoToStart()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadTheStart());
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    
    // Coroutine code for reloading the scene
    /* not working
    IEnumerator ReloadTheGame()
    {
        // Loads the Scene in the background as the current Scene still runs
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("CampfireDemo");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    } */

    // Coroutine code for going back to startscene
    IEnumerator LoadTheStart()
    {
        // Loads the Scene in the background as the current Scene still runs
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("StartScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Code for pausemenu to follow the player
    public void PauseLocation()
    {
        transform.position = FollowPlayer.transform.position;
        transform.rotation = FollowPlayer.transform.rotation;
    }


    void Update() 
    {
        // Checks if the right Oculus button is pressed to pause or resume the game
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (GameIsPaused == true)
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
