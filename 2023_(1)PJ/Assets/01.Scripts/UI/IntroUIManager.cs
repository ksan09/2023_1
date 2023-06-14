using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIManager : MonoBehaviour
{
    public static IntroUIManager Instance { get; private set; }

    private int _currentIndex = 0;
    public int SetCurrentIndex(int index) => _currentIndex = index;
    [SerializeField]
    private List<IntroUISelector> _uiSelector = new List<IntroUISelector>();
    [SerializeField]
    private GameObject _settingPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Many IntroUiManager!");
    }

    private void Update()
    {
        if (_settingPanel.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            _settingPanel.SetActive(false);
            return;
        }

        if (_settingPanel.activeSelf == true) return;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_currentIndex == 0) return;
            _uiSelector[--_currentIndex].SelectBtn();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (_currentIndex == _uiSelector.Count - 1) return;
            _uiSelector[++_currentIndex].SelectBtn();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            _uiSelector[_currentIndex].ClickEvent();
        }
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ShowSettingUI()
    {
        _settingPanel.SetActive(true);
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
