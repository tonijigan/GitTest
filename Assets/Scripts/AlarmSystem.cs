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

    private void Start()
    {
        _audioSource.volume = _audioSource.minDistance;
    }

    public void WorkSignal(string command)
    {
        StartCoroutine(ChangeVolume(command));
    }

    private IEnumerator ChangeVolume(string command)
    {
        float _changeVolume = 0.2f;
        int maxVolume = 1;

        if (command == CommandTurnUpVolume)
        {
            _audioSource.Play();
            _animator.SetBool(IsAlarm, true);

            while (_audioSource.volume != maxVolume)
            {
                _audioSource.volume += _changeVolume * Time.deltaTime;
                yield return null;
            }
        }
        else if (command == CommandTurnDownVolume)
        {
            float minVolume = 0.01f;

            while (_audioSource.volume != _audioSource.minDistance)
            {
                _audioSource.volume -= _changeVolume * Time.deltaTime;

                if (_audioSource.volume < minVolume)
                {
                    _animator.SetBool(IsAlarm, false);
                    _audioSource.Stop();
                }
                yield return null;
            }
        }
    }
}
