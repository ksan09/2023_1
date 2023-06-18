using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    [SerializeField]
    private Vector3 MoveVec;

    private float value = 0;
    [SerializeField]
    private float speed = 0;
    private bool startToEnd = true;

    private Vector3 startPos;
    private Vector3 endPos;

    private void Awake()
    {
        startPos = transform.position;
        endPos = startPos + MoveVec;
    }

    private void Update()
    {
        MovingUI();    
    }

    private void MovingUI()
    {
        value += (startToEnd ? 1f : -1f) * speed * Time.deltaTime;
        if(value < 0f) startToEnd = true;
        else if(value > 1f) startToEnd = false;

        transform.position = Vector3.Lerp(startPos, endPos, value);
    }
}
