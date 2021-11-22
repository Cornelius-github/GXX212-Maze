using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCoords : MonoBehaviour
{
    public GameObject player;

    public Transform localLeft;
    public Transform localRight;
    public Transform localForward;
    public Transform localBack;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<VoiceController>().Left = localLeft;
        player.GetComponent<VoiceController>().Right = localRight;
        player.GetComponent<VoiceController>().Forward = localForward;
        player.GetComponent<VoiceController>().Back = localBack;
    }

}
