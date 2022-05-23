using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSetup : MonoBehaviour
{
    public GameObject enemyTank;
    public GameObject[] spawnPoints;
    public Transform pointToSpawn;
    private void Start()
    {
        //Add all the spawn points in the game world to an array of gameobjects
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        //Get a reference to the enemy tank using a find with tag function
        enemyTank = GameObject.FindGameObjectWithTag("Tank");   
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManger.playerActive == false)
        {
            //Spawn point is returned from function
            pointToSpawn = GetFurthestSpawn(spawnPoints);

            //When the player tank has been destroyed the gameobject is deactivatd and has its position set to the new spawn point
            this.gameObject.transform.position = pointToSpawn.position;
            this.gameObject.SetActive(true);
            GameManger.playerActive = true;
        }
    }

    //Get the furthest spawn point from the player tank 
    Transform GetFurthestSpawn(GameObject[] spawnPoints)
    {
        Transform furthestSpawn = null;
        float minDist = 0;
        Vector3 enemyTankPosition = enemyTank.transform.position;
        foreach (GameObject point in spawnPoints)
        {
            float dist = Vector3.Distance(point.transform.position, enemyTankPosition);

            if (dist > minDist)
            {
                furthestSpawn = point.transform;
                minDist = dist;
            }
        }
        return furthestSpawn;
    }
}
