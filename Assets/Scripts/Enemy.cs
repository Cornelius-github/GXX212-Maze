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
    Vector3 playerLocation;
    Vector3 enemyStart;
    Vector3 enemyLocation;

    Rigidbody enemyBody;

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
        playerLocation = player.position;
        enemyLocation = enemy.position;

        var playerMove = playerLocation - playerStart;
        var enemyMove = enemyLocation - enemyStart;

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

        */
        if (playerLocation != playerStart)
        {
            //agent.SetDestination(player.position);
            StartCoroutine(EnemyChase());
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
    }

    IEnumerator EnemyChase()
    {
        agent.SetDestination(player.position);

        yield return new WaitForSeconds(2);

        agent.Stop();
        playerStart = player.position;
    }
}
