using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Snapzone : MonoBehaviour
{
    //returns true when the object is within the SnapZone radius
    public bool insideSnapZone_firepit;

    //The gameobjects that will snap
    public GameObject Logs;

    //Detects when the Log game object has entered snapzone radius
    private void OnTriggerEnter(Collider other)
    {
        //Makes logs the other game object that collided
        Logs = other.gameObject;

        if (Logs.GetComponent<LogTag>() != null)
        {
            insideSnapZone_firepit = true;
        }
    }
    //Detects when the Log game object has left the snap zone radius
    private void OnTriggerExit(Collider other)
    {
        //Log = other.gameObject;
        if (Logs.GetComponent<LogTag>() != null)
        {
            insideSnapZone_firepit = false;
        }
    }

}
