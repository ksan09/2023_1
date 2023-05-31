using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            return instance;
        }
    }

    private PlayerControls playerControls;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
            instance = this;

        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return playerControls.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return playerControls.Player.Jump.triggered;
    }
    public bool PlayerShotRope()
    {
        return playerControls.Player.LeftMouse.triggered;
    }
    public bool PlayerDeleteRope()
    {
        return playerControls.Player.RightMouse.triggered;
    }
    public bool PlayerPushShot()
    {
        return playerControls.Player.LeftMouse.IsPressed();
    }
    public bool PlayerPullShot()
    {
        return playerControls.Player.RightMouse.IsPressed();
    }


    public bool WeaponChange()
    {
        return playerControls.Player.WeaponChange.triggered;
    }
}
