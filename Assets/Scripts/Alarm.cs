using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _countIterations;

    private string _action—ommand;

    private void Start()
    {
        _audioSource.volume = _audioSource.minDistance;
    }

    private void Update()
    {
        StartCoroutine(ChangeVolume());

        if (_audioSource.volume == _audioSource.minDistance)
        {
            _animator.SetBool("Alarm", false);
            _audioSource.Stop();
            StopCoroutine(ChangeVolume());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string commandStartSignal = "1";
        _action—ommand = commandStartSignal;
        _animator.SetBool("Alarm", true);
        _audioSource.Play();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string commandStopSignal = "2";
        _action—ommand = commandStopSignal;
        _audioSource.volume = 1;
    }

    private IEnumerator ChangeVolume()
    {
        const string CommandStartSignal = "1";
        const string CommandStopSignal = "2";
        float changeVolume = 0.001f;

        if (_action—ommand == CommandStartSignal)
        {
            for (int i = 0; i < _countIterations; i++)
            {
                _audioSource.volume += changeVolume / _countIterations;
            }
        }
        else if (_action—ommand == CommandStopSignal)
        {
            for (int i = 0; i < _countIterations; i++)
            {
                _audioSource.volume -= changeVolume / _countIterations;
            }
        }
        yield return null;
    }
}
