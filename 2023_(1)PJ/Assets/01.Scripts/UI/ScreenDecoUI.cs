using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDecoUI : MonoBehaviour
{
    private RectTransform rect;

    [SerializeField, Range(-1, 1)]
    private int dirX;

    [SerializeField]
    private float maxValue;
    private float value = 0;

    [SerializeField]
    private float speed = 0;

    private float startPosX = 0;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        startPosX = rect.position.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        value += speed * Time.deltaTime;
        if (value >= maxValue)
            value = 0;

        Vector3 pos = rect.position;
        pos.x = startPosX + value * dirX;
        rect.position = pos;
    }
}
