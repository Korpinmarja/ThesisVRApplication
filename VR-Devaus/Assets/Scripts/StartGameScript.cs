 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().CampfireDemo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //public static void LoadScene(string CampfireDemo, SceneManagement.LoadSceneMode mode = LoadSceneMode.Single);
}
