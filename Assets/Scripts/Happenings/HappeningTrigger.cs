using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappeningTrigger : MonoBehaviour
{
    [SerializeField] Happening[] _happenings;
    [SerializeField] bool _deactivateAfterTrigger;

    private void OnTriggerEnter(Collider other)
    {
        foreach (var happening in _happenings)
        {
            happening.Happen();
        }

        if (_deactivateAfterTrigger) Destroy(gameObject);
    }
}