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
    [Header("PoolManager ��")]

    [SerializeField]
    private List<PoolableMono> _poolingList;
    
    #endregion
    #region UIManager's var
    [Header("UIManager ��")]

    [SerializeField]
    private Canvas _canvas;

    #endregion
    #region SoundManager's var

    #endregion
    #region StageManager's var
    [Header("StageManager ��")]

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

        // �Ŵ��� ����
        PoolManager.Instance    = new PoolManager(transform);
        UIManager.Instance      = new UIManager();
        SoundManager.Instance   = new SoundManager();
        StageManager.Instance   = new StageManager();
        CameraManager.Instance  = new CameraManager();
        TimeManager.Instance    = new TimeManager();

        // �Ŵ��� �� ����
        foreach (PoolableMono p in _poolingList)
        {
            PoolManager.Instance.CreatePool(p, 20);
        }
    }

    #region GamaManager
    

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
