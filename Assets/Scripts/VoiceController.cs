using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;

public class VoiceController : MonoBehaviour
{
    private Dictionary<string, Action> commandActions = new Dictionary<string, Action>();
    private KeywordRecognizer commandRecognizer;

    Rigidbody playerBody;

    public Transform player;
    public Transform torch;
    public Transform enemy;

    GameObject move;

    // Start is called before the first frame update
    void Start()
    {
        //opening the menus
        commandActions.Add("main menu", TheMenu);
        //movement commands
        //turning left
        commandActions.Add("turn left", TurnLeft);
        commandActions.Add("go left", TurnLeft);
        commandActions.Add("left", TurnLeft);
        //turning right
        commandActions.Add("turn right", TurnRight);
        commandActions.Add("go right", TurnRight);
        commandActions.Add("right", TurnRight);
        //going forward
        commandActions.Add("move forward", MoveForward);
        commandActions.Add("go forward", MoveForward);
        commandActions.Add("forward", MoveForward);
        commandActions.Add("run", MoveForward);
        commandActions.Add("walk", MoveForward);
        //going back
        commandActions.Add("go back", Backwards);
        commandActions.Add("back", Backwards);
        commandActions.Add("run back", Backwards);
        //full rotation
        commandActions.Add("turn around", FullRotate);
        commandActions.Add("turn back", FullRotate);
        commandActions.Add("do a 180", FullRotate);
        commandActions.Add("u turn", FullRotate);
        commandActions.Add("look behind you", FullRotate);
        commandActions.Add("look behind", FullRotate);
        commandActions.Add("behind you", FullRotate);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();

        playerBody = GetComponent<Rigidbody>();

        move = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void TheMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    private void TurnLeft()
    {
        transform.Rotate(0f, -90f, 0f);
    }
    private void FullRotate()
    {
        transform.Rotate(0f, -180f, 0f);
    }

    private void TurnRight()
    {
        transform.Rotate(0f, 90f, 0f);
    }

    private void MoveForward()
    {
        //playerBody.AddForce(5f, 0, 0, ForceMode.Impulse);
        playerBody.velocity = transform.forward * 25f;
        move.GetComponent<Enemy>().playerMoving = true;
    }

    private void Backwards()
    {
        //playerBody.AddForce(-5f, 0, 0, ForceMode.Impulse);
        playerBody.velocity = transform.forward * -25f;
        move.GetComponent<Enemy>().playerMoving = true;
    }

    private void PickUp()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Wall Right")
        {
            playerBody.velocity = transform.forward * 0f;
            TurnRight();
            move.GetComponent<Enemy>().playerMoving = false;
            move.GetComponent<Enemy>().playerLocation = player.position;
            move.GetComponent<Enemy>().enemyLocation = enemy.position;
        }
        if (collider.tag == "Wall Left")
        {
            playerBody.velocity = transform.forward * 0f;
            TurnLeft();
            move.GetComponent<Enemy>().playerMoving = false;
            move.GetComponent<Enemy>().playerLocation = player.position;
            move.GetComponent<Enemy>().enemyLocation = enemy.position;
        }
        if (collider.tag == "Wall Back")
        {
            playerBody.velocity = transform.forward * 0f;
            transform.Rotate(0f, 180f, 0f);
            move.GetComponent<Enemy>().playerMoving = false;
            move.GetComponent<Enemy>().playerLocation = player.position;
            move.GetComponent<Enemy>().enemyLocation = enemy.position;
        }
        if (collider.tag == "Stop")
        {
            playerBody.velocity = transform.forward * 0f;
            playerBody.freezeRotation = true;
            move.GetComponent<Enemy>().playerMoving = false;
            move.GetComponent<Enemy>().playerLocation = player.position;
            move.GetComponent<Enemy>().enemyLocation = enemy.position;
        }
        if (collider.tag == "Enemy")
        {
            //the player loses
            move.GetComponent<Enemy>().playerMoving = false;
            move.GetComponent<Enemy>().playerLocation = player.position;
            move.GetComponent<Enemy>().enemyLocation = enemy.position;
        }
    }

    
    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
