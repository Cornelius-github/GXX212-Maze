using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public Transform entersMaze;
    public Transform enemy;
    public GameObject enemySpawnpoint;

    bool isCreated = false;


    private void OnTriggerEnter(Collider other)
    {
        if (isCreated == false)
        {
           if (other.tag == "Player")
            {
                enemy.position = enemySpawnpoint.transform.position;
                isCreated = true;
                Destroy(enemySpawnpoint);
            }
        }
    }
}
