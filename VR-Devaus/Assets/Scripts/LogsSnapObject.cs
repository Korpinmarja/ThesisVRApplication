using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogsSnapObject : MonoBehaviour
{
    //Reference for snapzone collider in use
    public GameObject Logs_PickUps;

    //Reference the game object (Campfire-stuff/Logs) that the snapped game object (log) will become part of
    public GameObject Logs;

    //Check if the object is grabbed by OVRGrabbvable
    public bool log_grabbed;

    //Check if the object is in basket
    public bool Campfire_Checker;

    // Start is called before the first frame update
    void Start()
    {
        //
    }

    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from OVRGrabbable script
        log_grabbed = GetComponent<OVRGrabbable>().isGrabbed;

        //Makes sure that the object can still be grabbed by OVRGrabbable 
        if (log_grabbed == true)
        {
            transform.SetParent(Logs_PickUps.transform);
            Campfire_Checker = false;
        }
    }
}
