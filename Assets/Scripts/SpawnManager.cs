using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    private PlayerController playerControllerScript;

    public GameObject[] groundPrefabs;
    public GameObject[] airPrefabs;
    public GameObject[] powerupPrefabs;

    //ground obsticle spawn ranges

    public float spawnRangeGroundObsticelsX = 22f;
    public float spawnRangeGroundObsticelsY = -2.5f;
    public float startDelay = 1;
    public float spawnInterval = 2;

    //air obsticle spawn ranges
    public float spawnRangeAirObsticelsX = 22;
    public float spawnRangeAirObsticelsY = 2;
    public float startDelayAir = 5;
    public float spawnIntervalAir = 5;

    // power up spawn ranges
    public float spawnRangePowerupsX = 22;
    public float spawnRangePowerupsY = 4;
    public float startDelayPowerups = 10;
    public float spawnIntervalPowerups = 15;

    private Buttons buttonScript;
    
        
    // Start is called before the first frame update
    void Start()
    {
        GameStartManager();
        



    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            StopAllCoroutines();
        }
    }

    void SpawnRandomGroundObsticel()

    {
        if (playerControllerScript.gameOver == false)
        {
            int groundPrefablIndex = Random.Range(0, groundPrefabs.Length);
            Vector2 spawnPos = new Vector2(Random.Range(spawnRangeGroundObsticelsX, 21), spawnRangeGroundObsticelsY);

            Instantiate(groundPrefabs[groundPrefablIndex], spawnPos, groundPrefabs[groundPrefablIndex].transform.rotation);
        }
            
        
    }

    void SpawnRandomAirObsticel()
    {
        if (playerControllerScript.gameOver == false)
        {
            int airPrefablIndex = Random.Range(0, airPrefabs.Length);
            Vector2 spawnPos = new Vector2(Random.Range(spawnRangeAirObsticelsX, 21), Random.Range(-spawnRangeAirObsticelsY, spawnRangeAirObsticelsY));

            Instantiate(airPrefabs[airPrefablIndex], spawnPos, airPrefabs[airPrefablIndex].transform.rotation);

        }

    }

    void SpawnRandomPowerup()
    {
        if (playerControllerScript.gameOver == false)
        {
            int powerupPrefablIndex = Random.Range(0, powerupPrefabs.Length);
            Vector2 spawnPos = new Vector2(Random.Range(0, spawnRangePowerupsX), Random.Range(-2, spawnRangePowerupsY));

            Instantiate(powerupPrefabs[powerupPrefablIndex], spawnPos, powerupPrefabs[powerupPrefablIndex].transform.rotation);
        }
            
        
    }

    public void GameStartManager()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        if (playerControllerScript.gameOver == false)
        {
            InvokeRepeating("SpawnRandomGroundObsticel", startDelay, spawnInterval);
            InvokeRepeating("SpawnRandomAirObsticel", startDelayAir, spawnIntervalAir);
            InvokeRepeating("SpawnRandomPowerup", startDelayPowerups, spawnIntervalPowerups);
        }
        
    }
}
