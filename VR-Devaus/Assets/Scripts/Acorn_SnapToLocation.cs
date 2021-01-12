using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acorn_SnapToLocation : MonoBehaviour
{
    //boolean variable used to determine if the player holds the object
    private bool grabbed;
    
    //boolean variable used to hold the code back, so it wont run through too quickly
    private bool inBasket;

    //returns true when the object is within the SnapZone radius
    private bool insideSnapZone;

    //returns true when the object had it's location updated
    public bool Snapped;

    //Spesific GameObject what will snap
    public GameObject Acorn;

    //Numeric variable to detect acorn spot
    public int i;

    //Reference another object to set the rotation
    public GameObject SnapRotationReference;

    //Numeric variable to count score and change scoretext
    public int Score;
    public Text ScoreText;


    //Detects when the Acorn game object has entered snapzone radius
    private void OnTriggerEnter(Collider other)
    {
        //Gives Acorn the acorn tag
        Acorn = other.gameObject;

        if (Acorn.GetComponent<AcornTag>() != null)
        {
            insideSnapZone = true;
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
    void acorn_SnapObject() 
    {
        if (Acorn != null && Acorn.GetComponent<AcornTag>() != null) 
        {
            //Checking other codes
            grabbed = Acorn.GetComponent<OVRGrabbable>().isGrabbed;
            inBasket = Acorn.GetComponent<Acorn_SnapObject>().Basket_Checker;

            if (grabbed == false && insideSnapZone == true && inBasket == false) 
            {
                inBasket = true;
                
                if (i < 3)
                {
                    Acorn.transform.SetParent(transform);
                    Acorn.gameObject.transform.position = transform.GetChild(i).position;
                    Acorn.gameObject.transform.rotation = transform.GetChild(i).rotation;
                    Acorn.GetComponent<Rigidbody>().isKinematic = true;

                    Snapped = true;
                    Acorn.gameObject.layer = 14; //Changing layer so player can't grap acorns from basket
                    AddScore();
                }

                else
                // Adds all other acorns in one position
                {
                    Acorn.transform.SetParent(transform);
                    Acorn.gameObject.transform.position = transform.GetChild(3).position;
                    Acorn.gameObject.transform.rotation = transform.GetChild(3).rotation;
                    Acorn.GetComponent<Rigidbody>().isKinematic = true;

                    Snapped = true;
                    Acorn.gameObject.layer = 14; //Changing layer so player can't grap acorns from basket
                    AddScore();
                }
            }
        }
    }

    void AddScore()
    {
        //Adds one to score and changes the text value
        //Score++;
        i = transform.childCount - 4;
        ScoreText.text = "Acorns in basket: " + i.ToString() /*Score.ToString()*/;
    }

    void Start()
    {
        //position starts at 0
        //i = 0;
        Score = 0;
        i = transform.childCount - 4;
    }

    // Update is called once per frame
    void Update()
    {
        acorn_SnapObject();
    }
}


