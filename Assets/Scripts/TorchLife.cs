using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLife : MonoBehaviour
{
    public int torchLife = 100;
    public GameObject theTorch;
    public Light torchLight;

    // Start is called before the first frame update
    void Start()
    {
        theTorch = this.gameObject;
        torchLight = theTorch.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (torchLife >= 75 && torchLife <= 100)
        {
            torchLight.intensity = 2;
            torchLight.range = 9;
        }
        if (torchLife >= 50 && torchLife <= 74)
        {
            torchLight.intensity = 1.5f;
            torchLight.range = 8;
        }
        if (torchLife >= 25 && torchLife <= 49)
        {
            torchLight.intensity = 1;
            torchLight.range = 6;
        }
        if (torchLife >= 1 && torchLife <= 24)
        {
            torchLight.intensity = 0.5f;
            torchLight.range = 4;
        }
        if (torchLife <= 0)
        {
            torchLight.intensity = 0;
            torchLight.range = 1;
        }
    }
}
