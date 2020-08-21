using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log_SnapToLocation : MonoBehaviour
{

    //boolean variable used to determine if the player holds the object
    private bool logs_grabbed;
    
    //boolean variable used to hold the code back, so it wont run through too quickly
    private bool inFirepit;

    // Reference for Log_Snapzone code, gets information from collided object with LogTag
    public GameObject Snapzone;

    //Reference for Log_Snapzone code, checker if the object is inside snapzone
    public bool isInsideFirepit;


    //returns true when the object had it's location updated
    public bool log_Snapped;

    //The gameobject that will snap
    public GameObject Log;

    //Reference another object to set the rotation
    public GameObject SnapRotationReference_log;

    public GameObject NextHologramActivate;
    

    /*
    Checks if the player has released the object and if the object is in
    SnapZone radius. If the both are true, sets the object location and
    rotation to desired coordinates. Sets the public boolen Snapped to
    true for reference by SnapObject script
    Changes Logs layer so player cant take them out of the basket, 
    without breaking the OVRGrabbable code
    */
    void logs_SnapObject() 
    {
        Log = Snapzone.GetComponent<Log_Snapzone>().Logs;

        if (Log != null && Log.GetComponent<LogTag>() != null) 
        {
            logs_grabbed = Log.GetComponent<OVRGrabbable>().isGrabbed;
            inFirepit = Log.GetComponent<LogsSnapObject>().Campfire_Checker;
            isInsideFirepit = Snapzone.GetComponent<Log_Snapzone>().insideSnapZone_firepit;

            if (logs_grabbed == false && isInsideFirepit == true && inFirepit == false) 
            {
                inFirepit = true;
                Log.GetComponent<Collider>().enabled = false;
                Log.transform.SetParent(Snapzone.transform);
                Log.gameObject.transform.position = transform.position;
                Log.gameObject.transform.rotation = transform.rotation;
                Log.GetComponent<Rigidbody>().isKinematic = true;
                

                log_Snapped = true;
                Log.gameObject.layer = 17;

                Snapzone.GetComponent<Log_Snapzone>().Logs = null;

                NextHologramActivate.SetActive(true);
                transform.gameObject.SetActive(false);
            }
        }
    }

    void Start()
    {
        //position starts at 0
        //j = 0;
        // j = transform.childCount - 4
    }

    // Update is called once per frame
    void Update()
    {
        logs_SnapObject();
    }
}
