using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public Transform spawnPointOne;
    public Transform spawnPointTwo;
    public GameObject playerGameObject;
    public GameObject enemyGameObject;
    public GameObject playerTankPrefab;
    public GameObject enemyTankPrefab;
    public static bool playerActive = true;
    public double timer = 0;
    public double respawnTimer = 4000;
    public List<GameObject> spawnPoints;
    public Transform pointToSpawn;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        playerGameObject = Instantiate(playerTankPrefab, spawnPointTwo.position, Quaternion.identity);
        enemyGameObject = Instantiate(enemyTankPrefab, spawnPointOne.position, Quaternion.identity);
        spawnPoints.Add(spawnPointOne.gameObject);
        spawnPoints.Add(spawnPointTwo.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P) && isPaused ==false)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        if (Input.GetKeyDown(KeyCode.P) && isPaused == true)
        {
            Time.timeScale = 1;
            isPaused = false;
        }




        if (Input.GetKeyDown(KeyCode.R) )
        {
            if (playerGameObject.activeSelf == false)
            {
                playerGameObject.SetActive(true);
            }
        }

        if (enemyGameObject.activeSelf == false)
        {
            timer += Time.deltaTime;
            pointToSpawn = GetFurthestSpawn(spawnPoints);
        }

        if (timer > respawnTimer && enemyGameObject.activeSelf == false || Input.GetKeyDown(KeyCode.R) && enemyGameObject.activeSelf == false)
        {
            timer = 0;
            enemyGameObject.transform.position = pointToSpawn.position;
            enemyGameObject.SetActive(true);
        }
    }

    Transform GetFurthestSpawn(List <GameObject> spawnPoints)
    {
        Transform furthestSpawn = null;
        float minDist = 0;
        Vector3 playerTankPosition = playerGameObject.transform.position;
        foreach (GameObject point in spawnPoints)
        {
            float dist = Vector3.Distance(point.transform.position, playerTankPosition);

            if (dist > minDist)
            {
                furthestSpawn = point.transform;
                minDist = dist;
            }
        }
        return furthestSpawn;
    }
}
