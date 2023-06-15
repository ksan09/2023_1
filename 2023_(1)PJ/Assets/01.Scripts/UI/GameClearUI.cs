using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearUI : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> texts = new List<TextMeshProUGUI>();

    [SerializeField]
    private TextMeshProUGUI _selectArrow;

    private int _currentIndex = 1;
    private readonly Color _defaultColor = Color.black;
    private readonly Color _selectColor = Color.yellow;

    private readonly float _defaultFontSize = 80;
    private readonly float _selectFontSize = 128;

    void Update()
    {
        SelectUI();
    }

    private void SelectUI()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveUI(-1);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveUI(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentIndex == 0)
                SceneManager.LoadScene(0);
            else if (_currentIndex == 1)
                StageManager.Instance.LoadNextStage();
        }
    }

    private void MoveUI(int x)
    {
        int temp = _currentIndex;
        _currentIndex += x;
        if(_currentIndex > texts.Count - 1 || _currentIndex < 0)
        {
            _currentIndex = temp;
            return;
        }    

        foreach(TextMeshProUGUI text in texts)
        {
            text.color = _defaultColor;
            text.fontSize = _defaultFontSize;
        }

        texts[_currentIndex].color = _selectColor;
        texts[_currentIndex].fontSize = _selectFontSize;

        _selectArrow.rectTransform.position = texts[_currentIndex].rectTransform.position;
        _selectArrow.rectTransform.position += Vector3.up * 180;
    }
}
