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

    private PlayerInput _playerInput;   // 입력
    private PlayerSkill _playerSkill;   // 스킬
    private Movement _movement;         // 이동

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
        // 커서 안 보이게
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
        // 현재 플레이어 상황을 봐준다
        _state = State.None; // 상황 초기화

        if (_playerSkill.IsUseSkill) // 스킬 사용 상태 확인
            _state = State.SkillMove;
        else if(_movement.MoveDir != Vector3.zero) // 멈춰있지 않다면
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
        // 적어둬야 함
        return true;
    }
}
