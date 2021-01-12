using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn_SnapObject : MonoBehaviour
{
    //Reference for snapzone collider in use
    public GameObject PickUps;

    //Reference the game object that the snapped game object will become part of
    public GameObject basket;

    //Check if the object is grabbed by OVRGrabbvable
    public bool acorn_grabbed;

    //Check if the object is in basket
    public bool Basket_Checker;


    // Update is called once per frame
    void Update()
    {
        //Set grabbed to equal the boolean value "isGrabbed" from OVRGrabbable script
        acorn_grabbed = GetComponent<OVRGrabbable>().isGrabbed;

        /*
        Sets object Rigidibody to be kinematic after it has been snapped into position
        Sets object to be a parent of the Basket object after it has been snapped
        Sets isSnapped variable true to alert some scripts (not in use atm)
        */

        //Makes sure that the object can still be grabbed by OVRGrabbable 
        if (acorn_grabbed == true)
        {
            transform.SetParent(PickUps.transform);
            Basket_Checker = false;
        }
        
    }
}
