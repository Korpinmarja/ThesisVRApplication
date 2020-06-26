using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    //Reference for snapzone collider in use
    public GameObject SnapLocation;

    //Reference the game object that the snapped game object will become part of
    public GameObject basket;

    //Cretes a variable that can be used to trigger efects (not in use atm)
    public bool isSnapped;

    //boolean variable used to reference the "Snapped" boolean from SnapLocation script
    private bool objectSnapped;

    //boolean variable used to determine if the object is currently held by the player
    private bool grabbed;

    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from OVRGrabbable script
        grabbed = GetComponent<OVRGrabbable>().isGrabbed;

        //Set objectSnapped equal to the Snapped boolean from Snaplocation
        objectSnapped = SnapLocation.GetComponent<SnapLocation>().Snapped;

        /*
        Sets object Rigidibody to be kinematic after it has been snapped into position
        Sets object to be a parent of the Basket object after it has been snapped
        Sets isSnapped variable true to alert some scripts (not in use atm)
        */
        if (objectSnapped == true)
        {
            GetComponent<Rigidibody>().isKinematic = true;
            transform.SetParent(basket.transform);
            isSnapped = true;
        }

        //Makes sure that the object can still be grabbed by OVRGrabbable
        if (objectSnapped == false &&  grabbed == false)
        {
            GetComponent<Rigidibody>().isKinematic = false;
        }
    }
}
