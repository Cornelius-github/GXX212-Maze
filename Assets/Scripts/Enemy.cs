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

    public Animator enemyAnim;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerStart = player.position;
        enemyStart = enemy.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerMoving == true)
        {
            enemyAnim.SetBool("moving", true);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            enemyAnim.SetBool("moving", false);
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
