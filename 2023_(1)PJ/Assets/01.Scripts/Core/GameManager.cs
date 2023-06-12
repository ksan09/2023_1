using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    #region Game's var
    #endregion

    #region Managers
    #region PoolManager's var
    [Header("PoolManager 값")]

    [SerializeField]
    private List<PoolableMono> _poolingList;
    
    #endregion
    #region UIManager's var
    [Header("UIManager 값")]

    [SerializeField]
    private Canvas _canvas;

    #endregion
    #region SoundManager's var

    #endregion
    #region StageManager's var
    [Header("StageManager 값")]

    [SerializeField]
    private int _maxChapter;
    [SerializeField]
    private int _maxStage;
    #endregion
    #region CameraManager's var
    #endregion
    #region TimeManager's var
    #endregion
    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("GameManager is not one");

        // 매니저 생성
        PoolManager.Instance    = new PoolManager(transform);
        UIManager.Instance      = new UIManager();
        SoundManager.Instance   = new SoundManager();
        StageManager.Instance   = new StageManager();
        CameraManager.Instance  = new CameraManager();
        TimeManager.Instance    = new TimeManager();

        // 매니저 값 생성
        foreach (PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 20);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    #region GamaManager
    
    public void DelayInvoke(Action action, float delay)
    {
        StartCoroutine(DelayCo(action, delay));
    }

    IEnumerator DelayCo(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
    #endregion
    #region PoolManager_Method

    #endregion
    #region UIManager_Method

    #endregion
    #region SoundManager_Method

    #endregion
    #region StageManager_Method

    #endregion
    #region CameraManager_Method
    #endregion
    #region TimeManager_Method
    #endregion

}
