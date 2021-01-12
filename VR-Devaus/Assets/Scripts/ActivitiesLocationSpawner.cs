using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesLocationSpawner : MonoBehaviour
{
    
    // Gameobject for player able to move it around
    public GameObject Player;
    
    //Spawnpoint to Acorn pick up
    public GameObject AcornPickUpSpawnPoint;

    //Spawnpoint to Campfire starting
    public GameObject CampfireSpawnPoint;

    //Spawnpoint to wall climbing //not needed atm
    public GameObject WallClimbingSpawnPoint;

    //Gameobject for pausemenu, so we cant turn the pause off once player has been spawned
    public GameObject PauseMenu;

    //Future ideas
    // - Fadeout for teleporting, so it wont feel as wierd

    //Player spawn code for Acorns pick up
    public void AcornSpawner()
    {
        Player.transform.position = AcornPickUpSpawnPoint.transform.position;
        Player.transform.rotation = AcornPickUpSpawnPoint.transform.rotation;

        PauseMenu.GetComponent<PauseGameScript>().Resume();
    }

    //Player spawn code for Campfire 
    public void CampfireSpawner()
    {
        Player.transform.position = CampfireSpawnPoint.transform.position;
        Player.transform.rotation = CampfireSpawnPoint.transform.rotation;

        PauseMenu.GetComponent<PauseGameScript>().Resume();
    }

    //Player spawn code for wall climbing
    public void WallClimbingSpawner()
    {
        Player.transform.position = WallClimbingSpawnPoint.transform.position;
        Player.transform.rotation = WallClimbingSpawnPoint.transform.rotation;

        PauseMenu.GetComponent<PauseGameScript>().Resume();
    }

}
