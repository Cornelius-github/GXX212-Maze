using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //variables
    private NavMeshAgent agent;

    public Transform player;
    public Transform torch;
    public Transform enemy;

    Vector3 playerStart;
    public Vector3 playerLocation;
    Vector3 enemyStart;
    public Vector3 enemyLocation;

    Rigidbody enemyBody;

    public bool playerMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStart = player.position;
        enemyStart = enemy.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        //using x or z value as the player cannot jump

        float xplayerDistance = playerLocation.x - playerStart.x;
        float zplayerDistance = playerLocation.z - playerStart.z;

        float xenemyDistance = enemyLocation.x - enemyStart.x;
        float zenemyDistance = enemyLocation.z - enemyStart.z;

        if (xplayerDistance > xenemyDistance || zplayerDistance > zenemyDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.Stop();
            playerStart = player.position;
        }

        if (playerLocation != playerStart)
        {
            //agent.SetDestination(player.position);
            StartCoroutine(EnemyChase());
        }
        */
        /*
        agent.SetDestination(player.position);

        float playerMoveDistance = Vector3.Distance(playerStart, playerLocation);
        if (Vector3.Distance(playerStart, enemyStart) > playerMoveDistance)
        {
            agent.Stop();
            playerLocation = player.position;
            enemyLocation = enemy.position;
        }
        */
        //float playerMoveDistance = Vector3.Distance(playerStart, playerLocation);
        if (playerMoving == true)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Wall Right")
        {
            enemyBody.velocity = transform.forward * 0f;
            transform.Rotate(0f, 90f, 0f);
        }
        if (collider.tag == "Wall Left")
        {
            enemyBody.velocity = transform.forward * 0f;
            transform.Rotate(0f, -90f, 0f);
        }
        if (collider.tag == "Wall Back")
        {
            enemyBody.velocity = transform.forward * 0f;
            transform.Rotate(0f, 180f, 0f);
        }
        if (collider.tag == "Stop")
        {
            enemyBody.velocity = transform.forward * 0f;
        }
    }

    IEnumerator EnemyChase()
    {
        agent.SetDestination(player.position);

        yield return new WaitForSeconds(2);

        agent.Stop();
        playerStart = player.position;
    }
}
