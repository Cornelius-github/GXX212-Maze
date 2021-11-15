using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    private Dictionary<string, Action> commandActions = new Dictionary<string, Action>();
    private KeywordRecognizer commandRecognizer;

    Rigidbody playerBody;

    // Start is called before the first frame update
    void Start()
    {
        commandActions.Add("turn left", TurnLeft);
        commandActions.Add("turn right", TurnRight);
        commandActions.Add("move forward", MoveForward);
        commandActions.Add("go back", Backwards);

        commandRecognizer = new KeywordRecognizer(commandActions.Keys.ToArray());
        commandRecognizer.OnPhraseRecognized += OnKeywordsRecognised;
        commandRecognizer.Start();

        playerBody = GetComponent<Rigidbody>();
    }

    private void TurnLeft()
    {
        transform.Rotate(0f, -90f, 0f);
    }

    private void TurnRight()
    {
        transform.Rotate(0f, 90f, 0f);
    }

    private void MoveForward()
    {
        //playerBody.AddForce(5f, 0, 0, ForceMode.Impulse);
        playerBody.velocity = transform.forward * 25f;
    }

    private void Backwards()
    {
        //playerBody.AddForce(-5f, 0, 0, ForceMode.Impulse);
        playerBody.velocity = transform.forward * -25f;
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
        }
        if (collider.tag == "Wall Left")
        {
            playerBody.velocity = transform.forward * 0f;
            TurnLeft();
        }
        if (collider.tag == "Wall Back")
        {
            playerBody.velocity = transform.forward * 0f;
            transform.Rotate(0f, 180f, 0f);
        }
        if (collider.tag == "Enemy")
        {
            //the player loses
        }
    }


    private void OnKeywordsRecognised(PhraseRecognizedEventArgs args)
    {
        commandActions[args.text].Invoke();
    }
}
