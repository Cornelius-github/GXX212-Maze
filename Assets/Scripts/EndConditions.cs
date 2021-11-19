using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndConditions : MonoBehaviour
{

    public Transform player;
    public Transform enemy;
    public Transform mazeExit;

    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

        // Update is called once per frame
    void Update()
    {
        if (player.position == enemy.position)
        {
            //if they are on the same position then they would be on top of each other
            losePanel.SetActive(true);
        }
        else
        {
            //they aren't on top of each other, so the game continues
        }

        if (player.position == mazeExit.position)
        {
            //the player has reached the exit position
            winPanel.SetActive(true);
        }
        else
        {
            //the player hasn't reached the exit position yet
        }
    }
}
