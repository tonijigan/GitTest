using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmVolume), typeof(MotionSensor))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private AlarmVolume _alarmVolume;
    private MotionSensor _motionSensor;
    private const string IsAlarm = "Alarm";
    private const string CommandTurnUpVolume = "1";
    private const string CommandTurnDownVolume = "2";

    private void Start()
    {
        _alarmVolume = GetComponent<AlarmVolume>();
        _motionSensor = GetComponent<MotionSensor>();
        _audioSource.volume = _audioSource.minDistance;
    }

    private void Update()
    {
        if (_motionSensor.Command != null)
        {
            WorkSignal(_motionSensor.Command);
        }
    }

    public void WorkSignal(string command)
    {
        PlayAudio();
        ChangeVolume(command);
    }

    private void PlayAudio()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    private void ChangeVolume(string command)
    {
        if (command == CommandTurnUpVolume)
        {
            StartCoroutine(_alarmVolume.TurnUpVolume(_audioSource));
            _animator.SetBool(IsAlarm, true);
        }
        else if (command == CommandTurnDownVolume)
        {
            float minVolume = 0.01f;
            StartCoroutine(_alarmVolume.TurnDownVolume(_audioSource));

            if (_audioSource.volume < minVolume)
            {
                _animator.SetBool(IsAlarm, false);
                _audioSource.Stop();
                _motionSensor.CommandSetNull();
            }
        }
    }
}
