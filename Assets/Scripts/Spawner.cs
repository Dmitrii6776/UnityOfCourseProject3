using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;

    [SerializeField] private Vector3 spawnPos = new Vector3(25, 0, 0);

    [SerializeField] private int startDelay = 2;
    [SerializeField] private int repeatDelay;
    private CharacterMovement playerControlSc;

    // Start is called before the first frame update
    void Start()
    {
        playerControlSc = GameObject.Find("Player").GetComponent<CharacterMovement>();
        InvokeRepeating("SpawnObstacle", startDelay, repeatDelay);
    }

    private void SpawnObstacle()
    {
        if (playerControlSc.GameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
            spawnPos.x += 25;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
