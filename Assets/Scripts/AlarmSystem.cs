using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private Alarm _alarm;

    private void Start()
    {
        _alarm = GetComponent<Alarm>();
        _audioSource.volume = _audioSource.minDistance;
    }

    private void Update()
    {
        StartCoroutine(_alarm.ChangeVolume(_audioSource));

        if (_audioSource.volume == _audioSource.minDistance)
        {
            _animator.SetBool("Alarm", false);
            _audioSource.Stop();
            StopCoroutine(_alarm.ChangeVolume(_audioSource));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("Alarm", true);
        _audioSource.Play();
        _alarm.PlayAlarm();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _audioSource.volume = 1;
        _alarm.StopAlarm();
    }
}
