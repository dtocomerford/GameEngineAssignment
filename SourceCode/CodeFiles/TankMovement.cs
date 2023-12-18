using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    
    public float currentSpeed;
    public int rotationSpeed = 10;
    private Rigidbody rb;
    private float movementInput;
    private float rotationInput;
    private float speed = 8f;
    public static Quaternion wantedRotation;
    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }


    private void OnCollisionEnter(Collision other)
    {
        //Due to collision detection issues I reduced the speed of the player tank when in contact with a wall
        if (other.gameObject.tag == "Wall")
        {
            currentSpeed = 5;
        } 
    }

    //Speed is rest once the tank is no longer touching the wall
    private void OnCollisionExit(Collision collision)
    {
        currentSpeed = speed;
    }

    void FixedUpdate()
    {
        //Takes input from the arrow keys
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        //The new position for the tank, either forwards or backwards * a speed and the Time.deltatime to keep game speeds consistant
        Vector3 wantedPosition = transform.position + (transform.forward * movementInput * currentSpeed * Time.deltaTime);

        //The Y position is fixed to 0.2
        wantedPosition.y = 0.2f;
        rb.MovePosition(wantedPosition);

        //The roration is done seperately
        //A new rotation is created using the current rotation * a rotation of the user input on the horizontal axis * Time.deltatime
        wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed* rotationInput * Time.deltaTime));
        rb.MoveRotation(wantedRotation);

      
    }



}



