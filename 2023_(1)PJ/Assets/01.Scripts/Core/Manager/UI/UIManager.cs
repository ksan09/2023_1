using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager
{
    public static UIManager Instance;

    private Transform _ingamePanel;
    private TextMeshProUGUI _errorText;
    private readonly float _errorMsgFadeinTime = 0.1f;
    private readonly float _errorMsgShowTime = 0.4f;
    private readonly float _errorMsgFadeoutTime = 0.05f;
    private bool _errorTextShowed = false;

    private RectTransform _clearPanel;

    private TextMeshProUGUI _popupText;
    private bool _popupTextShowed = false;
    private readonly float _popupMsgFadeinTime = 1f;
    private readonly float _popupMsgshowTime = 1.5f;
    private readonly float _popupMsgFadeoutTime = 0.5f;

    public UIManager(Transform _canvas)
    {
        _ingamePanel = _canvas.Find("IngamePanel").transform;
        _errorText = _ingamePanel.Find("ErrorText").GetComponent<TextMeshProUGUI>();
        _popupText = _ingamePanel.Find("PopupText").GetComponent<TextMeshProUGUI>();

        _clearPanel = _canvas.Find("ClearPanel").GetComponent<RectTransform>();

    }

    public void ShowClearPanel()
    {
        _clearPanel.gameObject.SetActive(true);
    }
    public void PopupMessage(string text)
    {
        if (_popupTextShowed == true) return;
        _popupTextShowed = true;
        _popupText.text = text;
        GameManager.Instance.StartCoroutine(ShowMsgCo(_popupText, _popupMsgFadeinTime, _popupMsgshowTime, _popupMsgFadeoutTime, () =>
        {
            _popupText.text = "";
            _popupTextShowed = false;
        }));
    }
    public void ErrorMessage(string text)
    {
        if (_errorTextShowed == true) return;
        _errorTextShowed = true;
        _errorText.text = text;
        GameManager.Instance.StartCoroutine(ShowMsgCo(_errorText, _errorMsgFadeinTime, _errorMsgShowTime, _errorMsgFadeoutTime, () =>
        {
            _errorText.text = "";
            _errorTextShowed = false;
        }));
    }

    IEnumerator ShowMsgCo(TextMeshProUGUI textUI, float fadein, float showTime ,float fadeout, Action endFunc)
    {
        float currentTime = 0f;
        Color color = textUI.color;
        textUI.color = new Color(color.r, color.g, color.b, 0);
        while (currentTime < fadein)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            textUI.color = new Color(color.r, color.g, color.b, Mathf.Lerp(0, 1, currentTime / fadein));
        }
        textUI.color = new Color(color.r, color.g, color.b, 1);
        yield return new WaitForSeconds(showTime);
        while (currentTime < fadeout)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            textUI.color = new Color(color.r, color.g, color.b, Mathf.Lerp(1, 0, currentTime / fadeout));
        }
        textUI.color = new Color(color.r, color.g, color.b, 0);
        endFunc?.Invoke();
    }
}
