using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Vector3[] playerSpawnPoints;
    public Vector3[] enemySpawnPoints;

    public GameObject[] playerPrefabs;
    public GameObject[] enemyPrefabs;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        for (int i = 0; i < playerSpawnPoints.Length; i++)
        {
            playerSpawnPoints[i] = GameObject.Find("Player Spawn " + i).transform.position;
            enemySpawnPoints[i] = GameObject.Find("Enemy Spawn " + i).transform.position;
        }

        //InvokeRepeating("SpawnEnemies", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnPlayerUnits(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnPlayerUnits(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnPlayerUnits(2);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        //int randomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);
        int randomSpawnPoint = 1;

        Instantiate(enemyPrefabs[randomEnemy], enemySpawnPoints[randomSpawnPoint], transform.rotation);
    }

    public void SpawnPlayerUnits(int unit)
    {
        int playerZone = playerController.currentZone;

        if (playerZone != 0)
        {
            Instantiate(playerPrefabs[unit], playerSpawnPoints[playerZone - 1], transform.rotation);
        }
    }
}
