using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUp_Checker : MonoBehaviour
{
    //boolean variable to check if the player is inside it or not
    public bool insideFireZone;

    public GameObject Player;

    //Detects when Player has entered SparkZone radius
    private void OnTriggerEnter(Collider other)
    {
        //Makes player the other gameobject that collided
        Player = other.gameObject;

        if (Player.GetComponent<CharacterController>() != null)
        {
            insideFireZone = true;
        }
    }

    //Detects when Player has exited SparkZone radius
    private void OnTriggerExit(Collider other)
    {
        if (Player.GetComponent<CharacterController>() != null)
        {
            insideFireZone = false;
        }
    }
}
