using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    private const string CommandStartSignal = "1";
    private const string CommandStopSignal = "2";
    public string Command { get; private set; }

    public void SetCommandZero()
    {
        const string CommandZero = "0";
        Command = CommandZero;
    }

    private void Start()
    {
        SetCommandZero();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Command = CommandStartSignal;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Command = CommandStopSignal;
    }
}
