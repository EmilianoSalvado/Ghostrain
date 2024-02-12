using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : Interactable
{
    [SerializeField] string _textToDisplay;
    public override void Interact()
    {
        SubtitlesManager.Instance.DisplayText(_textToDisplay);
    }
}