using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerModel _playerModel;
    float _horAxis, _verAxis;
    float _mouseX, _mouseY;
    void Update()
    {
        _horAxis = Input.GetAxis("Horizontal");
        _verAxis = Input.GetAxis("Vertical");

        if (_horAxis != 0 || _verAxis != 0)
            _playerModel.Move(_horAxis, _verAxis);

        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        if (_mouseX != 0 || _verAxis != 0)
            _playerModel.SetCameraRotation(_mouseX, _mouseY);
    }
}
