using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    public float gravity = 45.0f;
    public float sensitivity = 45.0f;

    private Climber_Hand currentHand = null;
    private CharacterController controller = null;
    
    
    
    private void CalculateMovement()
    {
        // kuinka pistän ovr player controllerin gravityn pois päältä tässä koodissa

        Vector3 movement = Vector3.zero;

        if (currentHand)
            movement += currentHand.Delta * sensitivity;
        
        if (movement == Vector3.zero)
            movement.y -= gravity * Time.deltaTime;

        controller.Move(movement * Time.deltaTime);
    }

    public void SetHand(Climber_Hand hand)
    {
        if(currentHand)
            currentHand.ReleasePoint();
        
        currentHand = hand;
    }

    public void ClearHand()
    {
        currentHand = null;
    }
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }
}
