using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmVolume : MonoBehaviour
{
    [SerializeField] private float _countIterations;

    private const string CommandStartSignal = "1";
    private const string CommandStopSignal = "2";
    private float _changeVolume = 0.001f;

    public IEnumerator ChangeVolume(AudioSource audioSource, string command)
    {
        if (command == CommandStartSignal)
        {
            TurnUpVolume(audioSource);
        }
        else if (command == CommandStopSignal)
        {
            TurnDownVolume(audioSource);
        }
        yield return null;
    }

    private void TurnUpVolume(AudioSource audioSource)
    {
        for (int i = 0; i < _countIterations; i++)
        {
            audioSource.volume += _changeVolume / _countIterations;
        }
    }

    private void TurnDownVolume(AudioSource audioSource)
    {
        for (int i = 0; i < _countIterations; i++)
        {
            audioSource.volume -= _changeVolume / _countIterations;
        }
    }
}
