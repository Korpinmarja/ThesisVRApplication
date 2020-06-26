using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToLocation : MonoBehaviour
{
    //boolean variable used to determine if the player holds the object
    private bool grapped;

    //returns true when the object is within the SnapZone radius
    private bool insideSnapZone;

    //returns true when the object had it's location updated
    public bool Snapped;

    //Spesific part where to snap
    public GameObject Basket;
    //Reference another object to set the rotation
    public GameObject SnapRotationReference;

    //Detects when the Acorn game object has entered snapzone radius
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == Acorn.name)
        {
            insideSnapZone = true;
        }
    }
    //Detects when the Acorn game object has left the snap zone radius
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == Acorn.name)
        {
            insideSnapZone = false;
        }
    }

    /*
    Checks if the player has released the object and if the object is in
    SnapZone radius. If the both are true, sets the object location and
    rotation to desired coordinates. Sets the public boolen Snapped to
    true for reference by SnapObject script
    */
    void SnapObject()
    {
        if(grabbed == false && insideSnapZone == true)
        {
            Acorn.gameObject.transform.position = transform.position;
            Acorn.gameObject.transform.position = SnapRotationReference.transform.rotation;
            Snapped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //set grabbed to equal the boolean valua "isGrabbed"  from OVRGrabbable script
        grabbed = Acorn.GetComponent<OVRGrabbable>().isGrabbed;
        //Call snap object script
        SnapObject();
    }
}
