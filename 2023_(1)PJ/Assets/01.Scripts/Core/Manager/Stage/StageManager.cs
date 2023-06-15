using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    private readonly int stageSceneNum = 2;
    private int currentStage = 0;
    public int CurrentStageNum => currentStage;
    private Map _stageMap = null;
    public Map Stage => _stageMap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            // 이미 인스턴스가 존재한다면 지운다.
            Destroy(gameObject);
        }
    }

    public void LoadNextStage()
    {
        LoadStage(currentStage + 1);
    }
    public void LoadStage(int stage)
    {
        StartCoroutine(LoadCo(stage));
    }
    public void ReloadStage()
    {
        GameManager.Instance.PlayerBrain.ResetPlayer();
        if (_stageMap != null)
            Destroy(_stageMap.gameObject);

        MapGenerate(currentStage);
    }

    IEnumerator LoadCo(int stage)
    {
        if(_stageMap != null)
            Destroy(_stageMap.gameObject);

        currentStage = stage;

        AsyncOperation oper = SceneManager.LoadSceneAsync(stageSceneNum);
        while (!oper.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        MapGenerate(stage);
    }

    private void MapGenerate(int num)
    {
        Map map = Resources.Load<Map>($"Stage{num}");
        if (map == null)
        {
            Debug.LogError("Stage Prefab is null");
            return;
        }

        _stageMap = Instantiate(map, transform.position, Quaternion.identity, transform);
        _stageMap.transform.position = Vector3.zero;

        if (_stageMap != null)
            Debug.Log("생성됨");

        GameManager.Instance.TeleportPlayer(map.StartPos);
        UIManager.Instance.PopupMessage($"Stage {num}");
    }
}
