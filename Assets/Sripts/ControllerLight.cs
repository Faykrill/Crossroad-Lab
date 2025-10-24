using UnityEngine;
using System;

public class ControllerLight : MonoBehaviour
{
    public Light lightComponent;
    public float changeIntervalRed = 20f;
    private float changeInterval;
    public float changeIntervalYellow = 1f;
    public float changeIntervalGreen = 15f;
    private float timer = 0f;

    void Start()
    {
        lightComponent.GetComponent<Light>().color = Color.red;
        changeInterval = changeIntervalRed;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            timer = 0f;
            if (lightComponent.GetComponent<Light>().color == Color.red)
            {
                Debug.Log("Red to Yellow");
                lightComponent.GetComponent<Light>().color = Color.yellow;
                changeInterval = changeIntervalYellow;
            }
            else if (lightComponent.GetComponent<Light>().color == Color.yellow)
            {
                Debug.Log("Yellow to Green");
                lightComponent.GetComponent<Light>().color = Color.green;
                changeInterval = changeIntervalGreen;
            }
            else
            {
                Debug.Log("Green to Red");
                lightComponent.GetComponent<Light>().color = Color.red;
                changeInterval = changeIntervalRed;
            }
            
        }
    }
}
