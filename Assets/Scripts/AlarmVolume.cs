using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmVolume : MonoBehaviour
{
    private const string CommandStartSignal = "1";
    private const string CommandStopSignal = "2";
    private float _changeVolume = 0.001f;

    public IEnumerator TurnUpVolume(AudioSource audioSource)
    {
        int maxVolume = 1;

        while (audioSource.volume != maxVolume)
        {
            audioSource.volume += _changeVolume * Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator TurnDownVolume(AudioSource audioSource)
    {
        while (audioSource.volume != audioSource.minDistance)
        {
            audioSource.volume -= _changeVolume * Time.deltaTime;
            yield return null;
        }
    }
}
