using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IntroUISelector : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField]
    private int _index;

    private TextMeshProUGUI _thisBtn;
    [SerializeField]
    private string _thisText;

    [SerializeField]
    private TextMeshProUGUI _playBtn;
    private readonly string _playText = "Play";

    [SerializeField]
    private TextMeshProUGUI _settingBtn;
    private readonly string _settingText = "Setting";

    [SerializeField]
    private TextMeshProUGUI _exitBtn;
    private readonly string _exitText = "Exit";

    private readonly Color _defaultColor = Color.white;
    private readonly Color _overColor = Color.yellow;

    private readonly float _defaultFontSize = 80;
    private readonly float _overFontSize = 96;

    public UnityEvent _btnEvent;

    private void Awake()
    {
        _thisBtn = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SelectBtn();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ClickEvent();
    }

    public void SelectBtn()
    {
        IntroUIManager.Instance.SetCurrentIndex(_index);
        ResetBtn();
        _thisBtn.text = $" > {_thisText}";
        _thisBtn.color = _overColor;
        _thisBtn.fontSize = _overFontSize;
    }
    public void ClickEvent()
    {
        _btnEvent?.Invoke();
    }
    private void ResetBtn()
    {
        _playBtn.text = _playText;
        _playBtn.color = _defaultColor;
        _playBtn.fontSize = _defaultFontSize;
        _settingBtn.text = _settingText;
        _settingBtn.color = _defaultColor;
        _settingBtn.fontSize = _defaultFontSize;
        _exitBtn.text = _exitText;
        _exitBtn.color = _defaultColor;
        _settingBtn.fontSize = _defaultFontSize;
    }
}
