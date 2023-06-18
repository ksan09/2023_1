using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour, IInteractable
{
    private bool hold = false;
    private PlayerBrain _player;
    private PlayerSkill _skill;
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private Vector3 _startPos;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBrain>();
        _skill = _player.transform.GetComponent<PlayerSkill>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();

        _startPos = transform.position;
    }

    private void Holding(bool use)
    {
        hold = use;
        _collider.isTrigger = use;
        _rigidbody.useGravity = !use;
        _rigidbody.constraints = use ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.FreezeRotation;
    }

    public void Interact()
    {
        if (_player.IsHold == false && hold == false)
        {
            _player.DoHold(transform);
            Holding(true);
        }
        else if (_player.IsHold == true && hold == true)
        {
            if (UnHoldCheck() == false)
            {
                UIManager.Instance.ErrorMessage("��ü�� ���� ������ �����ϴ�.");
                return;
            }

            _player.UnHold();
            Holding(false);
        }
        else if (_player.IsHold == true && hold == false)
        {
            UIManager.Instance.ErrorMessage("�̹� ������ �ִ� ��ü ����");
        }
    }

    public void ResetHoldBlock()
    {
        if(hold == true)
        {
            _player.UnHold();
            Holding(false);
        }

        transform.position = _startPos;
        if(_skill.HitTrms.Contains(transform))
        {
            _skill.DeleteRope();
        }
    }
    private bool UnHoldCheck()
    {
        LayerMask layer = (-1) - (1 << LayerMask.NameToLayer("Player"));
        _collider.enabled = false;
        bool check = Physics.CheckBox(_collider.transform.position + _collider.center, _collider.size / 2, Quaternion.identity, layer);
        _collider.enabled = true;
        return check == false;
    }
}
