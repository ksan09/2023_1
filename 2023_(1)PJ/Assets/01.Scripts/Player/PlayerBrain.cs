using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerWeaponState
{
    None = 0,
    RopeMode,
    PushPoolMode,
}

[RequireComponent(typeof(CharacterController))]
public class PlayerBrain : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool isHold = false;
    public bool IsHold => isHold;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    private InputManager inputManager;
    private PlayerSkill playerSkill;
    private Transform cameraTransform;

    private Transform holdObject = null;
    public Transform HoldObject { get; set; }

    private PlayerWeaponState playerWeaponState = PlayerWeaponState.RopeMode;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerSkill = gameObject.GetComponent<PlayerSkill>();
        cameraTransform = Camera.main.transform;
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        PlayerMove();
        Skill();
        Hold();
    }

    private void Hold()
    {
        if(isHold)
        {
            Vector3 pos = transform.position;
            pos.y += 0.3f;
            Vector3 viewDir = Define.MainCam.transform.forward;
            viewDir.y = 0f;
            pos += viewDir.normalized * 1f;
            holdObject.position = pos;
        }
    }
    public void DoHold(Transform obj)
    {
        isHold = true;
        holdObject = obj;
    }
    public void UnHold()
    {
        isHold = false;
        holdObject = null;
    }

    private void Skill()
    {
        SkillChange();

        if(playerWeaponState == PlayerWeaponState.RopeMode)
        {
            RopemodeSkill();
        }
        else if(playerWeaponState == PlayerWeaponState.PushPoolMode)
        {
            PushPoolmodeSkill();
        }
    }

    private void PushPoolmodeSkill()
    {
        if (inputManager.PlayerPushShot())
        {
            playerSkill.PushShot();
        }
        else if (inputManager.PlayerPullShot())
        {
            playerSkill.PullShot();
        }
    }

    private void RopemodeSkill()
    {
        if (inputManager.PlayerShotRope())
        {
            playerSkill.ShotRope();
        }
        else if (inputManager.PlayerDeleteRope())
        {
            playerSkill.DeleteRope();
        }
    }

    private void SkillChange()
    {
        if (inputManager.WeaponChange())
            playerWeaponState = ((playerWeaponState == PlayerWeaponState.RopeMode) ? PlayerWeaponState.PushPoolMode : PlayerWeaponState.RopeMode);
    }

    private void PlayerMove()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
