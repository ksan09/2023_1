using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField]
    private LayerMask       _shotAbleLayer; // �Ź����� ��ġ ������ ���̾�
    [SerializeField]
    private float           _webDist = 5;   // �Ź��� ����
    private float           _power = 10;

    private Transform       _fireTrm;       // �ѱ� Ʈ������

    private RaycastHit      hit;
    private Vector3[]       _hitPos = new Vector3[2];
    private Vector3[]       _hitOffset = new Vector3[2];
    private Transform[]     _hitTrm = new Transform[2];        // ����ĳ��Ʈ ���� ������Ʈ
    private int             _hitCount = 0;

    public bool             IsUseSkill { get; private set; }
    private SpringJoint     _joint;
    private LineRenderer    _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        DrawRope(false);
    }

    private void Update()
    {
        RenderRope();
    }

    private void RenderRope()
    {
        if (IsUseSkill == false) return;
        if (_joint == null) return;

        _lineRenderer.SetPosition(0, _hitTrm[0].position + _hitOffset[0]);
        _lineRenderer.SetPosition(1, _hitTrm[1].position + _hitOffset[1]);
    }
    private void DrawRope(bool isDraw)
    {
        IsUseSkill = isDraw;
        _lineRenderer.enabled = isDraw;
    }

    public void ShotRope()
    {
        if (IsUseSkill == true)
            return;

        // �������� ��
        bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
            Define.MainCam.transform.forward, out hit, _webDist, _shotAbleLayer));

        // ������ Pos�� ����
        if(isHit)
        {
            if(_hitCount == 1)
                if (_hitTrm[0] == hit.transform)
                    return;

            _hitPos[_hitCount] = hit.point;

            _hitTrm[_hitCount] = hit.collider.gameObject.transform;
            _hitOffset[_hitCount] = hit.point - _hitTrm[_hitCount].position;
            _hitCount++;

            if(_hitCount >= 2)
            {
                // ���� ������ �׸��� 
                DrawRope(true);

                // ����Ʈ ����, Rigidbody ����
                _joint = _hitTrm[0].gameObject.AddComponent<SpringJoint>();
                _joint.connectedBody = _hitTrm[1].GetComponent<Rigidbody>();

                // ����Ʈ ����
                _joint.autoConfigureConnectedAnchor = false;
                _joint.connectedMassScale = 100f;
                _joint.massScale = 100f;

                // ������ ����
                _joint.anchor = _hitOffset[0];
                _joint.connectedAnchor = _hitOffset[1];

                // �Ÿ� ����
                float dist = Vector3.Distance(_hitPos[0], _hitPos[1]);

                _joint.maxDistance = dist;
                _joint.minDistance = 0f;
                _joint.spring = 1f;
                _joint.damper = 2f;
                _joint.massScale = 5f;
            }
        }
    }
    public void DeleteRope()
    {
        _hitCount = 0;
        if (_joint != null)
        {
            Destroy(_joint);
            _joint = null;
        }
        // ���� ������ �����
        DrawRope(false);
    }

    public void PushShot()
    {
        // �������� ��
        bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
            Define.MainCam.transform.forward, out hit, _webDist, _shotAbleLayer));

        if(isHit)
        {
            Rigidbody temp = hit.transform.gameObject.GetComponent<Rigidbody>();
            temp.AddForce(-hit.normal * _power, ForceMode.Force);
        }
    }
    public void PullShot()
    {
        // �������� ��
        bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
            Define.MainCam.transform.forward, out hit, _webDist, _shotAbleLayer));

        if(isHit)
        {
            Rigidbody temp = hit.transform.gameObject.GetComponent<Rigidbody>();
            temp.AddForce(hit.normal * _power, ForceMode.Force);
        }
    }
}
