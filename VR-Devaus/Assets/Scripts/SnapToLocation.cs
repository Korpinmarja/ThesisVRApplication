using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToLocation : MonoBehaviour
{
    //boolean variable used to determine if the player holds the object
    private bool grabbed;
    
    //boolean variable used to hold the code back, so it wont run through too quickly
    private bool korissa;

    //returns true when the object is within the SnapZone radius
    private bool insideSnapZone;

    //returns true when the object had it's location updated
    public bool Snapped;

    //Spesific part what will snap
    public GameObject Acorn;

    //Numeric variable to detect acorn spot
    public int i;

    //Reference another object to set the rotation
    public GameObject SnapRotationReference;

    //Numeric variable to count score and scoretext
    public int Score;
    //public Text ScoreText;


    //Detects when the Acorn game object has entered snapzone radius
    private void OnTriggerEnter(Collider other)
    {
        //Gives Acorn the acorn tag
        Acorn = other.gameObject;

        if (Acorn.GetComponent<AcornTag>() != null)
        {
            insideSnapZone = true;
            //Call snap object script
            
        }
    }
    //Detects when the Acorn game object has left the snap zone radius
    private void OnTriggerExit(Collider other)
    {
        //Acorn = other.gameObject;
        if (Acorn.GetComponent<AcornTag>() != null)
        {
            insideSnapZone = false;
        }
    }

    /*
    Checks if the player has released the object and if the object is in
    SnapZone radius. If the both are true, sets the object location and
    rotation to desired coordinates. Sets the public boolen Snapped to
    true for reference by SnapObject script
    Changes acorns layer so player cant take them out of the basket, 
    without breaking the OVRGrabbable code
    */
    void SnapObject() {
    if(Acorn != null && Acorn.GetComponent<AcornTag>() != null) {
            if(grabbed == false && insideSnapZone == true && korissa == false) {
                
                korissa = true;
                i = transform.childCount - 3;

                if (i < 3)
                {
                    Acorn.transform.SetParent(transform);
                    Acorn.gameObject.transform.position = transform.GetChild(i).position;
                    Acorn.gameObject.transform.rotation = transform.GetChild(i).rotation;
                    Acorn.GetComponent<Rigidbody>().isKinematic = true;

                    Snapped = true;
                    Acorn.gameObject.layer = 14;
                }

                else
                // TODO muuta destroy yhteen spottiin
                // Adds all other acorns in one position
                {
                    Acorn.transform.SetParent(transform);
                    Acorn.gameObject.transform.position = transform.position;
                    Acorn.gameObject.transform.rotation = transform.rotation;
                    Acorn.GetComponent<Rigidbody>().isKinematic = true;

                    Snapped = true;
                    gameObject.layer = 14;
                }
                
                AddScore();
            }
        }
    }

    void AddScore()
    {
        //Adds one to score and changes the text value
        Score++;
        //ScoreText.text = Score.ToString();
    }

    void Start()
    {
        //position starts at 0
        i = 0;
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //set grabbed to equal the boolean valua "isGrabbed"  from OVRGrabbable script
        if (Acorn != null)
        {
            grabbed = Acorn.GetComponent<OVRGrabbable>().isGrabbed;
            korissa = Acorn.GetComponent<SnapObject>().Korijuttuja;
        }
        SnapObject();
    }
}


