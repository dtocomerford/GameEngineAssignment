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
        spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        enemyTank = GameObject.FindGameObjectWithTag("Tank");

        
        
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManger.playerActive == false)
        {
            Debug.Log("CALLED");
            pointToSpawn = GetFurthestSpawn(spawnPoints);

            this.gameObject.transform.position = pointToSpawn.position;
            this.gameObject.SetActive(true);
            GameManger.playerActive = true;
        }
    }

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
