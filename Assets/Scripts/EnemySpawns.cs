using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public Transform entersMaze;
    public GameObject enemy;
    public Transform enemySpawnpoint;

    bool isCreated = false;

    // Update is called once per frame
    void Update()
    {
        if (isCreated == false)
        {
            if (player.position.x > entersMaze.position.x || player.position.z > entersMaze.position.z)
            {
                Instantiate(enemy, enemySpawnpoint.position, Quaternion.identity);
                isCreated = true;
            }
        }
        
    }
}
