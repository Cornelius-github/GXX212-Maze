using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;
    public GameObject torch;
    public GameObject enemy;

    Vector3 playerStart;
    Vector3 playerLocation;
    Vector3 enemyLocation;

    Rigidbody enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        //getting the starting value of player position
        playerStart = player.transform.position;
        //getting the current position
        playerLocation = player.transform.position;

        //getting enemies location at this moment
        enemyLocation = enemy.transform.position;
        enemyBody = GetComponent<Rigidbody>();

        //is the torch still active?

    }

    // Update is called once per frame
    void Update()
    {
        //check if current position is the same or different to the player position
        if (playerStart == playerLocation)
        {
            //the player hasn't moved yet
        }
        else
        {
            //the player has moved
            enemyBody.velocity = transform.forward * 25f;
            playerStart = playerLocation;
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
}
