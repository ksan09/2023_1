using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private LineRenderer    _webLine;       // �Ź��� �׷��ֱ�
    [SerializeField]
    private LayerMask       _shotAbleLayer; // �Ź����� ��ġ ������ ���̾�
    [SerializeField]
    private float           _webDist = 5;   // �Ź��� ����

    private Vector3         _hitPos;        // ����ĳ��Ʈ ���� ��ġ
    public bool             IsUseSkill { get; private set; }    // ��ų ����� ����

    private void Awake()
    {
        _webLine = GetComponent<LineRenderer>();
    }

    public void ShotWeb()
    {
        // �������� ��

        // ������ Pos�� ����

        // ���� ������ �׸��� 
    }

    public void PoolWeb()
    {
        // ���� ������ �����

        // hitPos �������� AddForce
    }

    public void CancelWeb()
    {
        // ���� ������ �����
    }
}
