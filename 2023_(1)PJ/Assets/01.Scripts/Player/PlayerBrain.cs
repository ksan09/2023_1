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
    public Vector3 PlayerWarpPos { get; set; } = Vector3.zero;
    private bool groundedPlayer;
    private bool isHold = false;
    public bool IsHold => isHold;

    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;

    [SerializeField]
    private AudioSource _jumpSource;

    private Camera cam;
    private InputManager inputManager;
    private PlayerSkill playerSkill;
    private Transform cameraTransform;

    private HoldBlock holdObject = null;
    public Transform HoldObject => holdObject.transform;

    private PlayerWeaponState playerWeaponState = PlayerWeaponState.RopeMode;

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerSkill = gameObject.GetComponent<PlayerSkill>();
        cam = Camera.main;
        cameraTransform = cam.transform;
    }

    private void Start()
    {
        inputManager = InputManager.Instance;
    }

    void Update()
    {
        if(GameManager.Instance.IsGameStop) return;

        PlayerMove();
        Skill();
        Hold();
    }

    private void LateUpdate()
    {
        Teleport();
    }
    public void ResetPlayer()
    {
        UnHold();
        playerSkill.DeleteRope();
    }
    private void Teleport()
    {
        if(PlayerWarpPos != Vector3.zero)
        {
            controller.enabled = false;
            transform.position = PlayerWarpPos;
            PlayerWarpPos = Vector3.zero;
            controller.enabled = true;
        }    
    }

    private void Hold()
    {
        if(isHold)
        {
            Vector3 pos = transform.position;
            pos.y -= 0.15f;
            Vector3 viewDir = cam.transform.forward;
            viewDir.y = 0f;
            pos += viewDir.normalized * 1f;
            HoldObject.position = pos;
        }
    }
    public void DoHold(HoldBlock obj)
    {
        isHold = true;
        holdObject = obj;
    }
    public void UnHold()
    {
        if (holdObject != null)
            holdObject.Holding(false);

        isHold = false;
        holdObject = null;
    }

    private void Skill()
    {
        if(playerWeaponState == PlayerWeaponState.RopeMode)
        {
            RopemodeSkill();
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
            AudioManager.Instance.PlayAudio("PlayerJump", _jumpSource);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
