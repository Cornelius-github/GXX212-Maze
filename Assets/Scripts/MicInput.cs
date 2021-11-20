using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MicInput : MonoBehaviour
{
    //code from https://www.youtube.com/watch?v=GHc9RF258VA

    //Microphone Input
    public string selectedMic;

    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Microphone.devices.Length > 0)
        {
            selectedMic = Microphone.devices[0].ToString();
            textBox.text = selectedMic;
        }
        else
        {
            //it is not registering a microphone
            selectedMic = "Unknown";
            textBox.text = selectedMic;
        }
    }
}
