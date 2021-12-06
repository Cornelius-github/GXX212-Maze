using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawns : MonoBehaviour
{
    public Transform player;
    public GameObject entersMaze;
    public GameObject enemy;
    public GameObject enemySpawnpoint;

    [SerializeField] bool isCreated = false;

    public Canvas tutorial;


    private void OnTriggerEnter(Collider other)
    {
        if (isCreated == false)
        {
           if (other.tag == "Player")
            {
                //Instantiate(enemy, enemySpawnpoint.transform.position, Quaternion.identity);
                //enemy.GetComponent<NavMeshAgent>().ResetPath();
                enemy.GetComponent<NavMeshAgent>().enabled = false;
                enemy.transform.position = enemySpawnpoint.transform.position;
                enemy.GetComponent<NavMeshAgent>().enabled = true;
                //enemy.GetComponent<NavMeshAgent>().transform.position = enemySpawnpoint.transform.position;
                isCreated = true;
                //Destroy(entersMaze);
                entersMaze.GetComponent<BoxCollider>().enabled = false;

                tutorial.gameObject.SetActive(false);
            }
        }
    }
}
