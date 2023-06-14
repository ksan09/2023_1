using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager
{
    public static UIManager Instance;

    private Transform _ingamePanel;
    private TextMeshProUGUI _errorText;
    private readonly float _textShowTime = 0.1f;
    private bool _showed = false;

    public UIManager(Transform _canvas)
    {
        _ingamePanel = _canvas.Find("IngamePanel").transform;
        _errorText = _ingamePanel.Find("ErrorText").GetComponent<TextMeshProUGUI>();
    }

    public void ErrorMessage(string text)
    {
        if (_showed == true) return;
        _errorText.text = text;
        GameManager.Instance.StartCoroutine(ShowErrorMsgCo());
    }

    IEnumerator ShowErrorMsgCo()
    {
        _showed = true;
        float currentTime = 0f;
        while(currentTime < _textShowTime)
        {
            currentTime += Time.deltaTime;
            _errorText.color = new Color(1, 0, 0, Mathf.Lerp(0.0f, 1.0f, currentTime / _textShowTime));
            yield return new WaitForEndOfFrame();
        }
        _errorText.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        _errorText.text = "";
        _showed = false;
    }
}
