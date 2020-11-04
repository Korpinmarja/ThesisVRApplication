using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber_Hand : MonoBehaviour
{
    public Climber climber = null;
    public OVRInput.Controller controller = OVRInput.Controller.None;

    public Vector3 Delta {private set; get; } = Vector3.zero;

    private Vector3 lastPosition = Vector3.zero;

    private GameObject currentPoint = null;
    public List<GameObject> contactPoints = new List<GameObject>();
    

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
        currentPoint = Utility.GetNearest(transform.position, contactPoints);

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
        if (newObject.CompareTag("ClimberPoint"))
            contactPoints.Add(newObject);
    }

    private void RemovePoint(GameObject newObject)
    {
        if (newObject.CompareTag("ClimberPoint"))
            contactPoints.Remove(newObject);
    }

}
