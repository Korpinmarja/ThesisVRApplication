using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Climber_Hand : MonoBehaviour
{
    
    /* 
    this is just a code from tutorial and tried to use it, it's not working
    player gameobject has some other gravitymodifiers so player won't go up at all
    here is links for used video tutorials 
    Part 1 https://youtu.be/XGdWIeyKmZE?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    Part 2 https://youtu.be/qmlMUoN_t2I?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    */
    
    
    public Climber climber = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;

    public Vector3 Delta {private set; get; } = Vector3.zero;

    private Vector3 lastPosition = Vector3.zero;

    private GameObject currentPoint = null;
    public List<GameObject> contactPoints = new List<GameObject>();

    //public GameObject CharacterControllerProblem;  // these are my tries to disable gravity from character controller, these didn't work
    //public GameObject CharacterControllerGravity;
    

    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, controller))
            GrapPoint();

        if (OVRInput.GetUp(OVRInput.Button.One, controller))
            ReleasePoint();
    }

    void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        Delta = lastPosition - transform.position;
    }

    private void GrapPoint()
    {
        currentPoint = ClimberUtility.GetNearest(transform.position, contactPoints);

        if(currentPoint)
        {
            climber.SetHand(this);
        }
    }
    
    public void ReleasePoint()
    {
        if(currentPoint)
        {
            climber.ClearHand();
        }

        currentPoint = null;

        //charactercontroller/gravity enable
        
        /*
        bool isEmpty = !contactPoints.Any();
        if(isEmpty) {
            CharacterControllerGravity.GetComponent<OVRPlayerController>().GravityModifier = 1;
            //CharacterControllerProblem.GetComponent<CharacterController>().enabled = enabled;
        } */
    }

    private void OnTriggerEnter(Collider other)
    {
        AddPoint(other.gameObject);
    }
    
    private void OnTriggerExit(Collider other)
    {
        RemovePoint(other.gameObject);
    }
    
    private void AddPoint(GameObject newObject)
    {

		//CharacterControllerProblem.GetComponent<CharacterController>().enabled = false;
        //CharacterControllerGravity.GetComponent<OVRPlayerController>().GravityModifier = 0;

        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Add(newObject);
            
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimbPoint"))
            contactPoints.Remove(newObject);
    }

}
