using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public Transform entersMaze;
    public GameObject enemy;
    public GameObject enemySpawnpoint;

    [SerializeField] bool isCreated = false;


    private void OnTriggerEnter(Collider other)
    {
        if (isCreated == false)
        {
           if (other.tag == "Player")
            {
                //Instantiate(enemy, enemySpawnpoint.transform.position, Quaternion.identity);
                //enemy.position = enemySpawnpoint.transform.position;
                enemy.SetActive(true);
                enemy.GetComponent<NavMeshAgent>().transform.position = enemySpawnpoint.transform.position;
                isCreated = true;
                Destroy(enemySpawnpoint);
            }
        }
    }
}
