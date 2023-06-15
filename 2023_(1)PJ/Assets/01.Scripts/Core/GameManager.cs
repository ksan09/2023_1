using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    #region Game's var
    private bool isGameClear = false;

    public Transform PlayerTransform { get; private set; }
    public PlayerBrain PlayerBrain { get; private set; }
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
    private Transform _canvas;

    #endregion
    #region SoundManager's var

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

        PlayerTransform = GameObject.Find("Player").transform;
        PlayerBrain = PlayerTransform.GetComponent<PlayerBrain>();

        // 매니저 생성
        PoolManager.Instance    = new PoolManager(transform);
        UIManager.Instance      = new UIManager(_canvas);
        SoundManager.Instance   = new SoundManager();
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

    private void Update()
    {
        Restart();
        ReturnMenu();
    }


    #region GamaManager

    public void GameClear()
    {
        isGameClear = true;
        UIManager.Instance.ShowClearPanel();
    }
    private void ReturnMenu()
    {
        if (isGameClear) return;

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(1);
    }
    private void Restart()
    {
        if (isGameClear) return;

        if(Input.GetKeyDown(KeyCode.R))
            StageManager.Instance.ReloadStage();
    }
    public void DelayInvoke(Action action, float delay)
    {
        StartCoroutine(DelayCo(action, delay));
    }
    public void TeleportPlayer(Vector3 pos)
    {
        PlayerBrain.PlayerWarpPos = pos;
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
    #region CameraManager_Method
    #endregion
    #region TimeManager_Method
    #endregion

}
