using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscalatorOff : Happening
{
    [SerializeField] EscalatorTrigger _escalatorTrigger;
    [SerializeField] AudioSource _escalatorAudioSource;
    public override void Happen()
    {
        Destroy(_escalatorTrigger.gameObject);
        _escalatorAudioSource.Stop();
    }
}
