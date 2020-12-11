using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesLocationSpawner : MonoBehaviour
{
    
    // Gameobject for player to move it
    public GameObject Player;
    
    //Spawnpoint to Acorn pick up
    public GameObject AcornPickUpSpawnPoint;

    //Spawnpoint to Campfire starting
    public GameObject CampfireSpawnPoint;

    //Spawnpoint to wall climbing
    public GameObject WallClimbingSpawnPoint;

    //Gameobject for pausemenu
    public GameObject PauseMenu;

    //public bool PauseMenuisOn

    // kuinka kutsun resumen spawnin jälkeen, koska pause jää teleporttauksen jälkeen päälle
    // also kuinka teen fade outin, voiko käyttää oculuksen koodia ja muokata siitä oma versio


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

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
