using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTank : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject playerTank;
    public Vector3 playerTankVector;
    //public Quaternion wantedRotation;
    //public float rotationSpeed = 10f;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        playerTank = GameObject.FindGameObjectWithTag("PlayerTank");

    }

    // Update is called once per frame
    void Update()
    {

        //wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed * rotationInput * Time.deltaTime));

        if (playerTank != null)
        {
            playerTankVector = playerTank.transform.position;

            agent.SetDestination(playerTankVector);
        }
        
        
    }
}
