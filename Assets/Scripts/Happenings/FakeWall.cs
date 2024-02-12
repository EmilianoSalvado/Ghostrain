using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : Happening
{
    [SerializeField] GameObject[] _walls;

    public override void Happen()
    {
        _walls[0].SetActive(false);

        if (_walls.Length > 1 )
            _walls[1].SetActive(true);
    }
}
