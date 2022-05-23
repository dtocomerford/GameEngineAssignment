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
    void Start() // Upper case because in C# casing counts!
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = speed;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Wall")
        {
            currentSpeed = 5;
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        currentSpeed = speed;
    }

    void FixedUpdate()
    {

        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");


        Vector3 wantedPosition = transform.position + (transform.forward * movementInput * currentSpeed * Time.deltaTime);
        wantedPosition.y = 0.2f;
        rb.MovePosition(wantedPosition);

        wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed* rotationInput * Time.deltaTime));
        rb.MoveRotation(wantedRotation);

      
    }



}



