using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //PlayerInputValue

    //이동 관련 입력
    public bool Forward => Input.GetKey(KeyCode.W);
    public bool Left    => Input.GetKey(KeyCode.A);
    public bool Back    => Input.GetKey(KeyCode.S);
    public bool Right   => Input.GetKey(KeyCode.D);

    public bool Jump    => Input.GetKeyDown(KeyCode.Space);

    //설정, UI 관련 입력
    public bool ESC     => Input.GetKeyDown(KeyCode.Escape);

    //공격, 특수 능력
    public bool ShotWeb => Input.GetMouseButtonDown(0);
    public bool PoolWeb => Input.GetMouseButtonDown(1);
}
