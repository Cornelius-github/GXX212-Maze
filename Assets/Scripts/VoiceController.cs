using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class VoiceController : MonoBehaviour
{
    private Dictionary<string, Action> commandActions = new Dictionary<string, Action>();
    private KeywordRecognizer commandRecognizer;

    Rigidbody playerBody;

    public Transform player;
    public Transform enemy;

    public Transform Left;
    public Transform Right;
    public Transform Forward;
    public Transform Back;

    private NavMeshAgent Player;

    GameObject move;
    GameObject torch;

    [SerializeField] int batteries;

    public Transform canvas;
    public Transform controlCanvas;

    public GameObject tutorial;
    public GameObject firstGO;
    public GameObject secondGO;
    public GameObject thirdGO;
    public GameObject finalGO;

    AudioSource steps;

    // Start is called before the first frame update
    void Start()
    {
        //making the mouse invisable
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        steps = player.GetComponent<AudioSource>();

       
        //pausing the game
        commandActions.Add("pause", PauseMenu);
        commandActions.Add("pause menu", PauseMenu);
        commandActions.Add("pause game", PauseMenu);
        //unpausing the game
        commandActions.Add("resume", UnPause);
        commandActions.Add("play", UnPause);
        //opening controls
        commandActions.Add("controls", ControlsOpen);
        //back button (contorls)
        commandActions.Add("return", BackButton);
        //return to menu
        commandActions.Add("go to menu", ReturnToMenu);
        commandActions.Add("main menu", ReturnToMenu);
        commandActions.Add("main", ReturnToMenu);

        //movement commands
        //turning left
        commandActions.Add("turn left", TurnLeft);
        commandActions.Add("go left", TurnLeft);
        commandActions.Add("left", TurnLeft);
        commandActions.Add("rotate left", TurnLeft);
        commandActions.Add("rotate anti clockwise", TurnLeft);
        commandActions.Add("turn anti clockwise", TurnLeft);
        //turning right
        commandActions.Add("turn right", TurnRight);
        commandActions.Add("go right", TurnRight);
        commandActions.Add("right", TurnRight);
        commandActions.Add("rotate right", TurnRight);
        commandActions.Add("rotate clockwise", TurnRight);
        commandActions.Add("turn clockwise", TurnRight);
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
        //using the battery
        commandActions.Add("recharge", UseBattery);
        commandActions.Add("recharge battery", UseBattery);
        commandActions.Add("use battery", UseBattery);
        commandActions.Add("change battery", UseBattery);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();

        playerBody = GetComponent<Rigidbody>();

        move = GameObject.FindGameObjectWithTag("Enemy");
        torch = GameObject.FindGameObjectWithTag("Torch");

        Player = GetComponent<NavMeshAgent>();

        canvas.gameObject.SetActive(false);
        controlCanvas.gameObject.SetActive(false);

        firstGO.SetActive(true);
        secondGO.SetActive(false);
        thirdGO.SetActive(false);
        finalGO.SetActive(false);
    }

    private void TheMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }

    private void PauseMenu()
    {
        //SceneManager.LoadScene(sceneBuildIndex: 2);
        if (canvas.gameObject.activeInHierarchy == false)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void TurnLeft()
    {
        //transform.Rotate(0f, -90f, 0f);
        Player.SetDestination(Left.position);
        torch.GetComponent<TorchLife>().torchLife -= 20;
        steps.Play();
    }
    
    private void FullRotate()
    {
        transform.Rotate(0f, -180f, 0f);
    }

    private void TurnRight()
    {
        //transform.Rotate(0f, 90f, 0f);
        Player.SetDestination(Right.position);
        torch.GetComponent<TorchLife>().torchLife -= 20;
        steps.Play();
    }

    private void MoveForward()
    {
        //playerBody.AddForce(5f, 0, 0, ForceMode.Impulse);
        //playerBody.velocity = transform.forward * 25f;
        Player.SetDestination(Forward.position);
        move.GetComponent<Enemy>().playerMoving = true;
        torch.GetComponent<TorchLife>().torchLife -= 20;
        steps.Play();
    }

    private void Backwards()
    {
        //playerBody.AddForce(-5f, 0, 0, ForceMode.Impulse);
        //playerBody.velocity = transform.forward * -25f;
        Player.SetDestination(Back.position);
        move.GetComponent<Enemy>().playerMoving = true;
        torch.GetComponent<TorchLife>().torchLife -= 20;
        steps.Play();
    }

    private void UseBattery()
    {
        //for when they want to use a battery that they have picked up
        if (batteries > 0)
        {
            torch.GetComponent<TorchLife>().torchLife = 100;
        }
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
        if (collider.tag == "Batteries")
        {
            //the player has gone over a battery
            batteries++;
            //destroys the object that has been collided with, i believe this gets rid of the battery
            Destroy(collider);
        }

        //tutorial colliders
        if (collider.tag == "Tutorial 1")
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(false);
            finalGO.SetActive(false);
        }
        if (collider.tag == "Tutorial 2")
        {
            firstGO.SetActive(false);
            secondGO.SetActive(true);
            thirdGO.SetActive(false);
            finalGO.SetActive(false);
        }
        if (collider.tag == "Tutorial 3")
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(true);
            finalGO.SetActive(false);
        }
        if (collider.tag == "Tutorial 4")
        {
            firstGO.SetActive(false);
            secondGO.SetActive(false);
            thirdGO.SetActive(false);
            finalGO.SetActive(true);
        }
        steps.Stop();
    }

    private void ReturnToMenu()
    {
        Debug.Log("doin");
        if (canvas.gameObject.activeInHierarchy == true)
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            
        }        
    }

    private void UnPause()
    {
        Debug.Log("doin");
        if (canvas.gameObject.activeInHierarchy == true)        
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }            
    }

    private void ControlsOpen()
    {
        Debug.Log("doin");
        if (canvas.gameObject.activeInHierarchy == true)
        {
            canvas.gameObject.SetActive(false);
            controlCanvas.gameObject.SetActive(true);
        }        
    }

    private void BackButton()
    {
        Debug.Log("doin");
        if (controlCanvas.gameObject.activeInHierarchy == true) 
        {
            controlCanvas.gameObject.SetActive(false);
            canvas.gameObject.SetActive(true);
        }        
    }

    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
