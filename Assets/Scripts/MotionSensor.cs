using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MotionSensor : MonoBehaviour
{
    [SerializeField] private UnityEvent _commandTurnUpVolume, _commandTurnDownVolume;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _commandTurnUpVolume.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _commandTurnDownVolume.Invoke();
    }
}
