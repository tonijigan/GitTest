using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MotionSensor))]
public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;

    private Coroutine _currentCoroutine;
    private const string IsAlarm = "Alarm";
    private int _maxVolume = 1;

    public void TurnUpSignal()
    {
        WorkOfCoroutine(_maxVolume);
    }

    public void TurnDownSignal()
    {
        WorkOfCoroutine(_audioSource.minDistance);
    }
    private void Start()
    {
        _audioSource.volume = _audioSource.minDistance;
    }

    private void WorkOfCoroutine(float targetVolume)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        if (targetVolume == _maxVolume)
        {
            _audioSource.Play();
            _animator.SetBool(IsAlarm, true);
        }

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _speed * Time.deltaTime);
            yield return null;
        }

        if (targetVolume == _audioSource.minDistance)
        {
            _audioSource.Stop();
            _animator.SetBool(IsAlarm, false);
        }
    }
}
