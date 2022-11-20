using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Alarm), typeof(MotionSensor))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private const string IsAlarm = "Alarm";
    private Alarm _alarm;
    private MotionSensor _motionSensor;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
        _motionSensor = GetComponent<MotionSensor>();
        _audioSource.volume = _audioSource.minDistance;
    }

    private void Update()
    {
        StartCoroutine(_alarm.ChangeVolume(_audioSource));

        if (_audioSource.volume == _audioSource.minDistance)
        {
            _audioSource.Stop();
            _animator.SetBool(IsAlarm, false);
            StopCoroutine(_alarm.ChangeVolume(_audioSource));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _alarm.PlayAlarm();
        _audioSource.Play();
        _animator.SetBool(IsAlarm, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.StopAlarm();
        _audioSource.volume = 1;
    }
}
