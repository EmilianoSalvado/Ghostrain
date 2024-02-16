using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("PLAYER SOUNDS")]
    [SerializeField] AudioSource _playerFootstepsSource;
    public AudioSource PlayerFootstepsSource { get { return _playerFootstepsSource; } }
    [SerializeField] AudioSource _playerEffectsSource;
    [SerializeField] AudioClip _playerFlashlightSwitch;
    bool _hasPlayed;

    [Header("NPC DIALOGUE")]
    [SerializeField] AudioClip _weirdVoiceOneShot;
    [SerializeField][Range(-2f,2f)] float _minPitch, _maxPitch;

    public static SoundManager instance;

    private void Start()
    {
        instance = this;
    }

    public void TalkingCharacter(AudioSource AS)
    {
        AS.pitch = Random.Range(_minPitch, _maxPitch);
        AS.PlayOneShot(_weirdVoiceOneShot);
    }

    public void PlayerWalk(bool isWalking)
    {
        if (isWalking)
        {
            if (!_hasPlayed)
            { _playerFootstepsSource.Play(); _hasPlayed = true; return; }

            _playerFootstepsSource.UnPause();
            return;
        }
        _playerFootstepsSource.Pause();
    }

    public void PlayerFlashLight()
    {
        _playerEffectsSource.PlayOneShot(_playerFlashlightSwitch);
    }
}
