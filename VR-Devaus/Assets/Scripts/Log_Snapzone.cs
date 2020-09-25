using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_Snapzone : MonoBehaviour
{
    /*
    TODO 
    - määrä x snaplocation paikkoja (jokaisessa paikassa oma snaplocation koodi)
        - yks kerralla vaan aktiivisena, loput disabloituna
    - kun tekee snaplocation koodin loppuun, disabloi itsensä ja avaa seuraavan aktiiviseksi
    */

    //returns true when the object is within the SnapZone radius
    public bool insideSnapZone_firepit;

    //The gameobjects that will snap
    public GameObject Logs;


    // TODO Acorn ja Logien collidereille omat systeemit/nimet etc.? 

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

    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
}
