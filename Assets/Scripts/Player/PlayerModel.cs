using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody), typeof(PlayerController))]
public class PlayerModel : MonoBehaviour
{
    [Header("MOVEMENT")]
    [SerializeField] Rigidbody _rb;
    [SerializeField][Range(0f,10f)] float _speed;
    Vector3 _dir;

    [Header("CAMERA")]
    [SerializeField] Transform _cameraPivot;
    [SerializeField][Range(0f, 300f)] float _sensivity;
    [SerializeField][Range(-180f, 0f)] float _upperTop;
    [SerializeField][Range(-0f, 180f)] float _lowerTop;
    float _ver, _hor;

    public void Move(float x, float y)
    {
        _dir = transform.right * x + transform.forward * y;
        if (_dir.sqrMagnitude > 1) _dir.Normalize();
        _dir *= (_speed * Time.deltaTime);
        _rb.MovePosition(transform.position + _dir);
    }

    public void SetCameraRotation(float x, float y)
    {
        _ver = Mathf.Clamp(_ver + -y * (_sensivity * Time.deltaTime), _upperTop, _lowerTop);
        _hor += x * (_sensivity * Time.deltaTime);

        if (_hor == 360 || _hor == -360) _hor = 0;

        _cameraPivot.eulerAngles = Vector3.up * _hor + Vector3.right * _ver;

        transform.forward = new Vector3(_cameraPivot.forward.x, transform.forward.y, _cameraPivot.forward.z);
    }
}