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

    //boolean variable used to determine if the player holds the object
    //private bool logs_grabbed;
    
    //boolean variable used to hold the code back, so it wont run through too quickly
    //private bool inFirepit;

    //returns true when the object is within the SnapZone radius
    public bool insideSnapZone_firepit;

    //returns true when the object had it's location updated
    //public bool log_Snapped;

    //The gameobjects that will snap
    public GameObject Logs;

    //Numeric variable to detect logs spot
    //public int j;

    //Reference another object to set the rotation
    // public GameObject SnapRotationReference_log;


    //Detects when the Log game object has entered snapzone radius
    // TODO Acorn ja Logien collidereille omat systeemit/nimet etc.? 
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

    /*
    Checks if the player has released the object and if the object is in
    SnapZone radius. If the both are true, sets the object location and
    rotation to desired coordinates. Sets the public boolen Snapped to
    true for reference by SnapObject script
    Changes Logs layer so player cant take them out of the basket, 
    without breaking the OVRGrabbable code
    */
    
    /*void logs_SnapObject() 
    {
        if (Log != null && Log.GetComponent<LogTag>() != null) 
        {
            logs_grabbed = Log.GetComponent<OVRGrabbable>().isGrabbed;
            inFirepit = Log.GetComponent<LogsSnapObject>().Campfire_Checker;

            if (logs_grabbed == false && insideSnapZone_firepit == true && inFirepit == false) 
            {
                inFirepit = true;
                

                if (j < 3)
                {
                    Log.transform.SetParent(transform);
                    Log.gameObject.transform.position = transform.GetChild(j).position;
                    Log.gameObject.transform.rotation = transform.GetChild(j).rotation;
                    Log.GetComponent<Rigidbody>().isKinematic = true;

                    log_Snapped = true;
                    Log.gameObject.layer = 15;
                }

                else
                // TODO ei anna laittaa enempää ku määrän x puita
                // Adds all other Logs in one position
                {
                    Log.transform.SetParent(transform);
                    Log.gameObject.transform.position = transform.GetChild(3).position;
                    Log.gameObject.transform.rotation = transform.GetChild(3).rotation;
                    Log.GetComponent<Rigidbody>().isKinematic = true;

                    log_Snapped = true;
                    Log.gameObject.layer = 15;
                }
            }
        }
    }
    */

    void Start()
    {
        //position starts at 0
        //j = 0;
        // j = transform.childCount - 4;
    }

    // Update is called once per frame
    void Update()
    {
        //logs_SnapObject();
    }
}
