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

        InvokeRepeating("SpawnEnemies", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int spawnUnit = 0;

            CheckSpawnUnit(spawnUnit);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int spawnUnit = 1;

            CheckSpawnUnit(spawnUnit);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int spawnUnit = 2;

            CheckSpawnUnit(spawnUnit);
        }
        //else if(Input.GetKeyDown(KeyCode.Alpha9)) // used for testing
        //{
        //    SpawnEnemies();
        //}
    }

    void CheckSpawnUnit(int spawnUnit)
    {
        if (playerController.credits - playerPrefabs[spawnUnit].GetComponent<PlayerUnit>().cost >= 0)
        {

            SpawnPlayerUnits(spawnUnit);
            ChargeUnitCost(spawnUnit);
        }
        else
        {
            Debug.Log("Not Enough Cash!");
        }
    }

    void SpawnEnemies()
    {
        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        int randomSpawnPoint = Random.Range(0, enemySpawnPoints.Length);

        //Instantiate(enemyPrefabs[randomEnemy], enemySpawnPoints[1], transform.rotation); // TESTING
        Instantiate(enemyPrefabs[randomEnemy], enemySpawnPoints[randomSpawnPoint], transform.rotation);

    }

    public void SpawnPlayerUnits(int unit)
    {
        int playerZone = playerController.currentZone;

        if (playerZone != 0)
        {
            Instantiate(playerPrefabs[unit], playerSpawnPoints[playerZone - 1], transform.rotation);
            //playerController.credits -= playerPrefabs[unit].GetComponent<Unit>().cost;
        }

    }

    private void ChargeUnitCost(int unit)
    {
        int cost = playerPrefabs[unit].GetComponent<PlayerUnit>().cost;

        Debug.Log("Instantiated a " + playerPrefabs[unit].name + " costing " + cost);
        playerController.credits -= cost;
    }
}
