using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    //[SerializeField]
    //private LayerMask       _shotAbleLayer; // 거미줄이 설치 가능한 레이어
    //[SerializeField]
    //private float           _webDist = 5;   // 거미줄 길이

    //private RaycastHit  hit;
    //private Vector3     _hitPos;            // 레이캐스트 맞은 위치
    //[SerializeField]
    //private Transform   _webPos;            // 거미줄 발사 위치
    //public bool IsUseSkill { get; private set; }

    //private SpringJoint _joint;
    //private Movement _movement;

    //private void Awake()
    //{
    //    _webLine = GetComponent<LineRenderer>();
    //    _movement = GetComponent<Movement>();
    //    DrawWeb(false);
    //}

    //private void Update()
    //{
    //    RenderWeb();
    //}

    //private void RenderWeb()
    //{
    //    if (IsUseSkill == false) return;

    //    _webLine.SetPosition(0, _webPos.position);
    //    _webLine.SetPosition(1, _hitPos);
    //}

    //private void DrawWeb(bool isDraw)
    //{
    //    IsUseSkill = isDraw;
    //    _webLine.enabled = isDraw;
    //}

    //public void ShotWeb()
    //{
    //    CancelWeb();
    //    Debug.Log("레이저 발사");
    //    // 레이저를 쏴
    //    bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
    //        Define.MainCam.transform.forward, out hit, _webDist, _shotAbleLayer));

    //    // 맞으면 Pos를 저장
    //    if(isHit)
    //    {
    //        Debug.Log("목표 맞음");
    //        _hitPos = hit.point;

    //        // 라인 렌더러 그리기 
    //        DrawWeb(true);

    //        // 조인트 생성
    //        _joint = gameObject.AddComponent<SpringJoint>();
    //        _joint.autoConfigureConnectedAnchor = false;
    //        _joint.connectedAnchor = _hitPos;

    //        float dist = Vector3.Distance(transform.position, _hitPos);

    //        _joint.maxDistance = dist;
    //        _joint.minDistance = dist * 0.5f;
    //        _joint.spring = 5f;
    //        _joint.damper = 5f;
    //        _joint.massScale = 5f;
    //    }

        
    //}

    //public void PoolWeb()
    //{
    //    if (_joint == null) return;
    //    // 라인 렌더러 지우기
    //    CancelWeb();
    //    // hitPos 방향으로 AddForce
    //    Vector3 dir = _hitPos - transform.position;
    //    float dist = Vector3.Distance(transform.position, _hitPos);
    //    _movement.Dash(dir.normalized, dist * 1.8f, 0.55f);
    //}

    //public void CancelWeb()
    //{
    //    // 라인 렌더러 지우기
    //    DrawWeb(false);
    //    Destroy(_joint);
    //}
}
