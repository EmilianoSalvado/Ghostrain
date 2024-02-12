using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _weirdVoiceOneShot;
    [SerializeField][Range(-2f,2f)] float _minPitch, _maxPitch;

    public static SoundManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void TalkingCharacter(AudioSource AS)
    {
        AS.pitch = Random.Range(_minPitch, _maxPitch);
        AS.PlayOneShot(_weirdVoiceOneShot);
    }
}
