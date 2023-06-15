using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private LayerMask       _shotAbleLayer; // 거미줄이 설치 가능한 레이어
    [SerializeField]
    private float           _webDist = 5;   // 거미줄 길이
    private float           _power = 10;

    private Transform       _fireTrm;       // 총구 트랜스폼

    private RaycastHit      hit;
    private List<Vector3>   _hitPos     = new List<Vector3>();
    private List<Vector3>   _hitOffset  = new List<Vector3>();
    private List<Transform> _hitTrm     = new List<Transform>();  // 레이캐스트 맞은 오브젝트
    private int             _hitCount = 0;
    private int             _jointCount = 0;

    public bool                 IsUseSkill { get; private set; }
    private bool                _isPlayGunAnimation = false;
    private List<SpringJoint>   _joints = new List<SpringJoint>();
    private LineRenderer        _lineRenderer;

    [SerializeField]
    private Animator _gunAnimator;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawRope(false);
    }

    private void Update()
    {
        //if (_joint != null && _joint.massScale != 100f)
        //    _joint.massScale = 100f;

        RenderRope();
    }

    private void RenderRope()
    {
        if (IsUseSkill == false) return;
        if (_hitCount <= 1) return;

        _lineRenderer.positionCount = _hitCount;
        for(int i = 0; i < _hitCount; ++i)
            _lineRenderer.SetPosition(i, _hitTrm[i].position + _hitOffset[i]);
    }
    private void AddRope()
    {
        _hitCount++;
        _hitPos.Add(hit.point);
        _hitTrm.Add(hit.collider.gameObject.transform);
        _hitOffset.Add(hit.point - _hitTrm[_hitCount - 1].position );
    }
    private void DrawRope(bool isDraw)
    {
        IsUseSkill = isDraw;
        _lineRenderer.enabled = isDraw;
    }

    public void ShotRope()
    {
        if (_isPlayGunAnimation)
            return;

        Camera cam = Camera.main;
        // 레이저를 쏴
        bool isHit = (Physics.Raycast(cam.transform.position,
            cam.transform.forward, out hit, _webDist, _shotAbleLayer));

        _isPlayGunAnimation = true;
        _gunAnimator.SetTrigger("Shot");
        GameManager.Instance.DelayInvoke(() => { 
            _isPlayGunAnimation = false;
            _gunAnimator.ResetTrigger("Shot");
        }, 0.5f);

        // 맞으면 Pos를 저장
        if(isHit)
        {
            if (_hitCount >= 1 && _hitTrm.Contains(hit.transform)) return;
                

            AddRope();
            if(_hitCount >= 2)
            {
                // 라인 렌더러 그리기 
                DrawRope(true);

                // 조인트 생성, Rigidbody 연결
                SpringJoint tempJoint = _hitTrm[_hitCount - 2].gameObject.AddComponent<SpringJoint>();
                tempJoint.connectedBody = _hitTrm[_hitCount - 1].GetComponent<Rigidbody>();

                // 조인트 설정
                tempJoint.autoConfigureConnectedAnchor = false;

                tempJoint.connectedMassScale = 500f;
                tempJoint.massScale = 500f;

                // 오프셋 조정
                tempJoint.anchor = _hitOffset[_hitCount - 1];
                tempJoint.connectedAnchor = _hitOffset[_hitCount - 1];

                // 거리 조정
                float dist = Vector3.Distance(_hitPos[0], _hitPos[1]);

                tempJoint.maxDistance = dist;
                tempJoint.minDistance = 0f;
                tempJoint.spring = 1f;
                tempJoint.damper = 2f;
                tempJoint.massScale = 5f;

                tempJoint.massScale = 500f;

                _jointCount++;
                _joints.Add(tempJoint);
            }
        }
    }
    public void DeleteRope()
    {
        _hitCount = 0;
        _hitPos.Clear();
        _hitOffset.Clear();
        _hitTrm.Clear();
        foreach (var joint in _joints)
            Destroy(joint);
        _joints.Clear();

        // 라인 렌더러 지우기
        DrawRope(false);
    }
}
