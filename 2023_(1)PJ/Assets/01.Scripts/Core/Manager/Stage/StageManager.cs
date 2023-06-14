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

    public void LoadStage(int stage)
    {
        StartCoroutine(LoadCo(stage));
    }

    IEnumerator LoadCo(int stage)
    {
        currentStage = stage;

        AsyncOperation oper = SceneManager.LoadSceneAsync(stageSceneNum);
        while (!oper.isDone)
        {
            yield return new WaitForEndOfFrame();
        }

        Map map = Resources.Load<Map>($"Stage{stage}");
        if(map == null)
        {
            Debug.LogError("Stage Prefab is null");
            yield break;
        }

        _stageMap = Instantiate(map, transform.position, Quaternion.identity, transform);
        _stageMap.transform.position = Vector3.zero;

        if (_stageMap != null)
            Debug.Log("생성됨");

        GameManager.Instance.PlayerTransform.position = map.StartPos;
    }
}
