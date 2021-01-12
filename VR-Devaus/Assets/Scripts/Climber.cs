using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climber : MonoBehaviour
{
    
    /* 
    this is just a code from tutorial and tried to use it, it's not working
    player gameobject has some other gravitymodifiers so player won't go up at all
    here is links for used video tutorials 
    Part 1 https://youtu.be/XGdWIeyKmZE?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    Part 2 https://youtu.be/qmlMUoN_t2I?list=PLmU65k4oXBWWIPpFNTmsxPESQ71BFMoAY
    */
    
    public float gravity = 45.0f;
    public float sensitivity = 45.0f;

    private Climber_Hand currentHand = null;
    private CharacterController controller = null;
    
    private void CalculateMovement()
    {

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
