using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AlarmVolume), typeof(MotionSensor))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private const string IsAlarm = "Alarm";
    private AlarmVolume _alarm;
    private Coroutine _coroutine;
    private MotionSensor _motionSensor;

    private void Start()
    {
        _alarm = GetComponent<AlarmVolume>();
        _motionSensor = GetComponent<MotionSensor>();
        _audioSource.volume = _audioSource.minDistance;
    }

    private void Update()
    {
        if (_motionSensor.Command == "0")
        {
            StopCoroutine(_alarm.ChangeVolume(_audioSource, _motionSensor.Command));
        }
        else if (_motionSensor.Command == "1" || _motionSensor.Command == "2")
        {
            Play();
        }
    }

    public void Play()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
        StartCoroutine(_alarm.ChangeVolume(_audioSource, _motionSensor.Command));
        _animator.SetBool(IsAlarm, true);

        if (_audioSource.volume == _audioSource.minDistance)
        {
            _audioSource.Stop();
            _animator.SetBool(IsAlarm, false);
            _motionSensor.SetCommandZero();
        }
    }
}
