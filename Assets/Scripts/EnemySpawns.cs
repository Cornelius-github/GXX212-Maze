using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public Transform entersMaze;
    public GameObject enemy;
    public Transform enemySpawnpoint;


    // Update is called once per frame
    void Update()
    {
        if (player.position.x > entersMaze.position.x || player.position.z > entersMaze.position.z)
        {
            Instantiate(enemy, enemySpawnpoint.position, Quaternion.identity);
        }
    }
}
