using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCoords : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public Transform localLeft;
    public Transform localRight;
    public Transform localForward;
    public Transform localBack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        enemy.GetComponent<Enemy>().playerMoving = false;
        player.GetComponent<VoiceController>().Left = localLeft;
        player.GetComponent<VoiceController>().Right = localRight;
        player.GetComponent<VoiceController>().Forward = localForward;
        player.GetComponent<VoiceController>().Back = localBack;
    }

    private void OnTriggerExit(Collider other)
    {
        enemy.GetComponent<Enemy>().playerMoving = true;
    }

}
