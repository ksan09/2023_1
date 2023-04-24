using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private LineRenderer    _webLine;       // 거미줄 그려주기
    [SerializeField]
    private LayerMask       _shotAbleLayer; // 거미줄이 설치 가능한 레이어
    [SerializeField]
    private float           _webDist = 5;   // 거미줄 길이

    private Vector3         _hitPos;        // 레이캐스트 맞은 위치
    public bool             IsUseSkill { get; private set; }    // 스킬 사용중 상태

    private void Awake()
    {
        _webLine = GetComponent<LineRenderer>();
    }

    public void ShotWeb()
    {
        // 레이저를 쏴

        // 맞으면 Pos를 저장

        // 라인 렌더러 그리기 
    }

    public void PoolWeb()
    {
        // 라인 렌더러 지우기

        // hitPos 방향으로 AddForce
    }

    public void CancelWeb()
    {
        // 라인 렌더러 지우기
    }
}
