using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MotionSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> _commandTurnUpVolume, _commandTurnDownVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        const string commandTurnUpVolume = "1";
        _commandTurnUpVolume.Invoke(commandTurnUpVolume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        const string commandTurnDownVolume = "2";
        _commandTurnDownVolume.Invoke(commandTurnDownVolume);
    }
}
