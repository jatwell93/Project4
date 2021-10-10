using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    public PlayerController playerControllerScript;

    private Vector3 spawnPosX = new Vector3(25, 0, 0);
    private float spawnDelay = 2;
    private float repeatRate = 2;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", spawnDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePrefabs, spawnPosX, obstaclePrefabs.transform.rotation);
        }
       
    }
}