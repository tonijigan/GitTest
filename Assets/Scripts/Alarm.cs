using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _countIterations;

    private const string CommandStartSignal = "1";
    private const string CommandStopSignal = "2";
    private string _command;

    public void PlayAlarm()
    {
        _command = CommandStartSignal;
    }

    public void StopAlarm()
    {
        _command = CommandStopSignal;
    }

    public IEnumerator ChangeVolume(AudioSource audioSource)
    {
        float changeVolume = 0.001f;

        if (_command == CommandStartSignal)
        {
            for (int i = 0; i < _countIterations; i++)
            {
                audioSource.volume += changeVolume / _countIterations;
            }
        }
        else if (_command == CommandStopSignal)
        {
            for (int i = 0; i < _countIterations; i++)
            {
                audioSource.volume -= changeVolume / _countIterations;
            }
        }
        yield return null;
    }
}
