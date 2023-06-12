using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // 게이트 오픈 애니메이터
    private Animator _gateAnimator;
    private bool _isOpen = false;

    // 압력 버튼 두 개
    [SerializeField]
    private PressButton _pressBtn1;
    [SerializeField]
    private PressButton _pressBtn2;

    private void Awake()
    {
        _gateAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        GateOpen();
    }

    private void GateOpen()
    {
        if (!_isOpen && PressBtnCheck()) // two button all pressed
        {
            _gateAnimator.SetTrigger("Open"); // open
            _gateAnimator.SetBool("IsOpen", true);
            _isOpen = true;
        }
    }

    private bool PressBtnCheck() => _pressBtn1.IsPressed && _pressBtn2.IsPressed;

}
