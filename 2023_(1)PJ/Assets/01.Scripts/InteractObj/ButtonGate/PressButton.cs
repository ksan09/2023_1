using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour
{
    private bool _isPressed = false; 
    public bool IsPressed => _isPressed;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        PressCheck();
    }

    private void PressCheck()
    {
        LayerMask layer = (-1) - (1 << LayerMask.NameToLayer("Default"));
        bool isPressed = Physics.CheckBox(_boxCollider.transform.position + _boxCollider.center, _boxCollider.size / 2, Quaternion.identity, layer);
        _isPressed = isPressed;
        if (isPressed)
            Debug.Log("´­¸²");
    }

    private void OnDrawGizmos()
    {
        _boxCollider = GetComponent<BoxCollider>();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_boxCollider.transform.position + _boxCollider.center, _boxCollider.size);
    }
}
