using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotionSensor))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private const string IsAlarm = "Alarm";
    private const string CommandTurnUpVolume = "1";
    private const string CommandTurnDownVolume = "2";

    public void TurnUpSignal()
    {
        StartCoroutine(ChangeVolume(CommandTurnUpVolume));
    }

    public void TurnDownSignal()
    {
        StartCoroutine(ChangeVolume(CommandTurnDownVolume));
    }

    private void Start()
    {
        _audioSource.volume = _audioSource.minDistance;
    }

    private IEnumerator ChangeVolume(string command)
    {
        if (command == CommandTurnUpVolume)
        {
            int maxVolume = 1;
            _audioSource.Play();
            _animator.SetBool(IsAlarm, true);

            while (_audioSource.volume != maxVolume)
            {
                ChangeVolume(maxVolume);
                yield return null;
            }
        }
        else if (command == CommandTurnDownVolume)
        {
            while (_audioSource.volume != _audioSource.minDistance)
            {
                ChangeVolume(_audioSource.minDistance);
                yield return null;
            }
            _animator.SetBool(IsAlarm, false);
            _audioSource.Stop();
        }
    }

    private void ChangeVolume(float targetVolume)
    {
        float changeVolume = 0.3f;
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, changeVolume * Time.deltaTime);
    }
}
