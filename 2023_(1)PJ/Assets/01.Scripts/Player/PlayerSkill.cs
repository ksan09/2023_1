using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    //[SerializeField]
    //private LayerMask       _shotAbleLayer; // �Ź����� ��ġ ������ ���̾�
    //[SerializeField]
    //private float           _webDist = 5;   // �Ź��� ����

    //private RaycastHit  hit;
    //private Vector3     _hitPos;            // ����ĳ��Ʈ ���� ��ġ
    //[SerializeField]
    //private Transform   _webPos;            // �Ź��� �߻� ��ġ
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
    //    Debug.Log("������ �߻�");
    //    // �������� ��
    //    bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
    //        Define.MainCam.transform.forward, out hit, _webDist, _shotAbleLayer));

    //    // ������ Pos�� ����
    //    if(isHit)
    //    {
    //        Debug.Log("��ǥ ����");
    //        _hitPos = hit.point;

    //        // ���� ������ �׸��� 
    //        DrawWeb(true);

    //        // ����Ʈ ����
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
    //    // ���� ������ �����
    //    CancelWeb();
    //    // hitPos �������� AddForce
    //    Vector3 dir = _hitPos - transform.position;
    //    float dist = Vector3.Distance(transform.position, _hitPos);
    //    _movement.Dash(dir.normalized, dist * 1.8f, 0.55f);
    //}

    //public void CancelWeb()
    //{
    //    // ���� ������ �����
    //    DrawWeb(false);
    //    Destroy(_joint);
    //}
}
