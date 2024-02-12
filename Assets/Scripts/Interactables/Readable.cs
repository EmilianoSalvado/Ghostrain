using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readable : Interactable
{
    [SerializeField] string _text;
    public override void Interact()
    {
        TextReader.instance.OpenTextReaderScreen(_text);
    }
}
