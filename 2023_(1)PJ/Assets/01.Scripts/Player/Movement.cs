using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool _useMove { get; private set; }

    [SerializeField]
    private float _speed;
    private Vector3 _moveDir;
    public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        if (_useMove == false)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        _rigidbody.velocity = _moveDir.normalized * _speed;
    }
    public void Rotate(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
    public void UseMovement(bool useMovement)
    {
        _useMove = useMovement;
    }

}
