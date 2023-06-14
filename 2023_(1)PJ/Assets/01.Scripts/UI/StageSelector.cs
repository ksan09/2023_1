using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _middle;

    [SerializeField]
    TextMeshProUGUI _left1;
    [SerializeField]
    TextMeshProUGUI _left2;
    [SerializeField]
    TextMeshProUGUI _right1;
    [SerializeField]
    TextMeshProUGUI _right2;

    private int currentNum = 0;

    [SerializeField]
    private int maxNumber = 0;
    [SerializeField]
    private int minNumber = 0;

    private void Awake()
    {
        currentNum = minNumber;
        SetShowUI();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftMoveUI();
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightMoveUI();
        }
    }


    private void LeftMoveUI()
    {
        if (currentNum == minNumber) return;
        currentNum--;
        SetShowUI();
    }
    private void RightMoveUI()
    {
        if (currentNum == maxNumber) return;
        currentNum++;
        SetShowUI();
    }

    private void SetShowUI()
    {
        _middle.text = currentNum.ToString();

        if(currentNum - 1 < minNumber)
        {
            _left1.gameObject.SetActive(false);
            _left2.gameObject.SetActive(false);
        }
        else if(currentNum - 2 < minNumber)
        {
            _left1.gameObject.SetActive(true);
            _left2.gameObject.SetActive(false);

            _left1.text = $"{currentNum-1} <";
        }
        else
        {
            _left2.gameObject.SetActive(true);
            _left1.text = $"{currentNum - 1} <";
            _left2.text = $"{currentNum - 2} <";
        }

        if(currentNum + 1 > maxNumber)
        {
            _right1.gameObject.SetActive(false);
            _right2.gameObject.SetActive(false);
        }
        else if (currentNum + 2 > maxNumber)
        {
            _right1.gameObject.SetActive(true);
            _right2.gameObject.SetActive(false);

            _right1.text = $"> {currentNum + 1}";
        }
        else
        {
            _right1.gameObject.SetActive(true);
            _right2.gameObject.SetActive(true);

            _right1.text = $"> {currentNum + 1}";
            _right2.text = $"> {currentNum + 2}";
        }
    }
}
