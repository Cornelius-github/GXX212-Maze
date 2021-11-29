using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public Transform entersMaze;
    public Transform enemy;
    public Transform enemySpawnpoint;

    bool isCreated = false;

    private NavMeshAgent navEnemy;

    // Update is called once per frame
    void Update()
    {
        navEnemy = GetComponent<NavMeshAgent>();
        navEnemy.isStopped = true;
        if (isCreated == false)
        {
            navEnemy.isStopped = false;
            if (player.position.x > entersMaze.position.x || player.position.z > entersMaze.position.z)
            {
                enemy.position = enemySpawnpoint.position;
                isCreated = true;
            }
        }

        
    }
}
