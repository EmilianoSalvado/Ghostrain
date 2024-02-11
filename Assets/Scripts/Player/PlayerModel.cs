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

    public void Move(float x, float y)
    {
        _dir = transform.right * x + transform.forward * y;
        if (_dir.sqrMagnitude > 1) _dir.Normalize();
        _dir *= (_speed * Time.deltaTime);
        _rb.MovePosition(transform.position + _dir);
    }
}