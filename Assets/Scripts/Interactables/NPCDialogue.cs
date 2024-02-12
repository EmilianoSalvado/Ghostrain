using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : Interactable
{
    [SerializeField] string _textToDisplay;
    [SerializeField] AudioSource _audioSource;
    public override void Interact()
    {
        SubtitlesManager.Instance.DisplayText(_textToDisplay, _audioSource);
    }
}