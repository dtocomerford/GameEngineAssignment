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
        if (playerTank != null)
        {
            playerTankVector = playerTank.transform.position;

            //Setting the target for the NavMesh to the vector3 position of the palyers tank
            agent.SetDestination(playerTankVector);
        }
        
        
    }
}
