using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    //Reference for snapzone collider in use
    public GameObject PickUps;

    //Reference the game object that the snapped game object will become part of
    public GameObject basket;

    public bool grabbed;

    public bool Korijuttuja;


    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from OVRGrabbable script
        
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;

        /*
        //Set objectSnapped equal to the Snapped boolean from Snaplocation
        objectSnapped = SnapLocation.GetComponent<SnapToLocation>().Snapped;
        */

        /*
        Sets object Rigidibody to be kinematic after it has been snapped into position
        Sets object to be a parent of the Basket object after it has been snapped
        Sets isSnapped variable true to alert some scripts (not in use atm)
       
        if (objectSnapped == true)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.SetParent(basket.transform);
            //isSnapped = true;
        }
        */

        //Makes sure that the object can still be grabbed by OVRGrabbable 
        
        if (grabbed == true)
        {
            transform.SetParent(PickUps.transform);
            Korijuttuja = false;
        }
        
    }
}
