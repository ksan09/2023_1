using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //PlayerInputValue

    //�̵� ���� �Է�
    public bool Forward => Input.GetKey(KeyCode.W);
    public bool Left    => Input.GetKey(KeyCode.A);
    public bool Back    => Input.GetKey(KeyCode.S);
    public bool Right   => Input.GetKey(KeyCode.D);

    public bool Jump    => Input.GetKeyDown(KeyCode.Space);

    //����, UI ���� �Է�
    public bool ESC     => Input.GetKeyDown(KeyCode.Escape);

    //����, Ư�� �ɷ�
    public bool ShotWeb => Input.GetMouseButtonDown(0);
    public bool PoolWeb => Input.GetMouseButtonDown(1);
}
