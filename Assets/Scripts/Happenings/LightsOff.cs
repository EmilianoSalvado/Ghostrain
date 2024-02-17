using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOff : Happening
{
    [SerializeField] Light[] _lights;

    public override void Happen()
    {
        foreach (Light light in _lights)
        {
            light.enabled = false;
        }
        SoundManager.instance.PowerOff();
    }
}
