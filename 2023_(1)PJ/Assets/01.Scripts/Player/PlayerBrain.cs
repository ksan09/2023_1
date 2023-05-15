using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    public enum State
    {
        None,
        Move,
        Jump,
        SkillMove,
    }

    private PlayerInput _playerInput;   // �Է�
    private PlayerSkill _playerSkill;   // ��ų
    private Movement _movement;         // �̵�

    private State _state = State.None;

    private void Awake()
    {
        _playerInput    = GetComponent<PlayerInput>();
        _playerSkill    = GetComponent<PlayerSkill>();
        _movement       = GetComponent<Movement>();

    }

    private void Start()
    {
        InitPlayer();
    }

    private void Update()
    {
        MovePlayer();
        JumpPlayer();
        RotatePlayer();
        PlayerSkill();

        PlayerState();
        DebugPlayer();
    }


    private void InitPlayer()
    {
        // Ŀ�� �� ���̰�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

       
    }
    private void MovePlayer()
    {
        _movement.MoveDir = Vector3.zero;

        if (_playerInput.Forward)
            _movement.MoveDir += transform.forward;
        if (_playerInput.Left)
            _movement.MoveDir += -transform.right;
        if (_playerInput.Back)
            _movement.MoveDir += -transform.forward;
        if (_playerInput.Right)
            _movement.MoveDir += transform.right;

        _movement.Move();
    }
    private void JumpPlayer()
    {
        //
        if (_playerInput.Jump && GroundCheck())
            _movement.Jump();

    }
    private void RotatePlayer()
    {
        Vector3 rotate = Vector3.zero;
        rotate.y = Define.MainCam.transform.eulerAngles.y;

        _movement.Rotate(rotate);
    }
    private void PlayerSkill()
    {
        if(_playerInput.ShotWeb)
            _playerSkill.ShotWeb();
        else if(_playerInput.PoolWeb)
            _playerSkill.PoolWeb();
    }
    private void PlayerState()
    {
        // ���� �÷��̾� ��Ȳ�� ���ش�
        _state = State.None; // ��Ȳ �ʱ�ȭ

        if (_playerSkill.IsUseSkill) // ��ų ��� ���� Ȯ��
            _state = State.SkillMove;
        else if(_movement.MoveDir != Vector3.zero) // �������� �ʴٸ�
            _state = State.Move;
    }

    private void DebugPlayer()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }    
    }
    private bool GroundCheck()
    {
        // ����־� ��
        return true;
    }
}
