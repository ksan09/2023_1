using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public bool _useMove { get; private set; }
    public bool _onGround { get; private set; }
    private bool _isDash = false;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpPower = 10.0f;
    private Vector3 _moveDir;
    public Vector3 MoveDir { get { return _moveDir; } set { _moveDir = value; } }

    private Rigidbody _rigidbody;
    private PlayerSkill _pSkill;

    [SerializeField]
    private float dist = 0.7f;
    [SerializeField]
    private LayerMask ground;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _pSkill = GetComponent<PlayerSkill>();
        _useMove = true;
        _onGround = true;
    }

    private void Update()
    {
        PropertyCheck();
    }

    private void PropertyCheck()
    {
        _onGround = Physics.Raycast(transform.position, Vector3.down, dist, ground);

        if(_isDash) return;
        _useMove = ((_pSkill.IsUseSkill && _onGround) || !_pSkill.IsUseSkill);

        Debug.Log(_useMove);
        
    }

    public void Jump()
    {
        if (_useMove == false) return;

        _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
    }
    public void Move()
    {
        if (_useMove == false) return;

        _rigidbody.velocity = _moveDir.normalized * _speed + new Vector3(0, _rigidbody.velocity.y, 0);
    }
    public void Rotate(Vector3 rotation)
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
    public void UseMovement(bool useMovement)
    {
        _useMove = useMovement;
    }

    public void Dash(Vector3 dir, float power, float delay)
    {
        if (_isDash == false)
            StartCoroutine(DashCo(dir, power, delay));
    }
    IEnumerator DashCo(Vector3 dir, float power, float delay)
    {
        _isDash = true;
        _useMove = false;
        Stop();
        _rigidbody.AddForce(dir.normalized * power, ForceMode.Impulse);
        yield return new WaitForSeconds(delay);
        _isDash = false;
        _useMove = true;
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }
}
