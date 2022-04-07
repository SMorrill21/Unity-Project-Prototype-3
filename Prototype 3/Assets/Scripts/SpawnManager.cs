using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;

    private Vector3 spawnPos = new Vector3(30, 0, 0);
    private float spawnDelay = 1;
    private float spawnInterval = 2;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnObstacle()
    {
        GameObject obstacle = obstaclePrefab[Random.Range(0, obstaclePrefab.Length)];

        if (!playerControllerScript.gameOver)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
    }
}
