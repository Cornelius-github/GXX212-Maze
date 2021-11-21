using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnter : MonoBehaviour
{
    public Transform player;
    public Transform playerAnchor;
    public Transform cameraAnchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //transform.LookAt(camera);
    }

    private void OnTriggerEnter(Collider other)
    {
        Camera.main.GetComponent<CameraMovement>().target = cameraAnchor;
        player.position = playerAnchor.position;
    }
}
