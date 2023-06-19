using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Material alphaMaterial;

    [SerializeField]
    private List<MeshRenderer> renderers = new List<MeshRenderer>();
    private Dictionary<MeshRenderer, Material> defaultMats = new Dictionary<MeshRenderer, Material>();

    private bool hold = false;
    private PlayerBrain _player;
    private PlayerSkill _skill;
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private Vector3 _startPos;

    private void Awake()
    {
        foreach (var renderer in renderers)
            defaultMats.Add(renderer, renderer.material);

        _player = FindObjectOfType<PlayerBrain>();
        _skill = _player.transform.GetComponent<PlayerSkill>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();

        _startPos = transform.position;
    }

    public void Holding(bool use)
    {
        hold = use;
        _collider.isTrigger = use;
        _rigidbody.useGravity = !use;
        _rigidbody.constraints = use ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.FreezeRotation;

        if(use)
        {
            foreach (var renderer in renderers)
                renderer.material = alphaMaterial;
        }
        else
        {
            foreach (var renderer in defaultMats)
                renderer.Key.material = renderer.Value;
        }
    }

    public void Interact()
    {
        if (_player.IsHold == false && hold == false)
        {
            _player.DoHold(this);
            Holding(true);
        }
        else if (_player.IsHold == true && hold == true)
        {
            if (UnHoldCheck() == false)
            {
                UIManager.Instance.ErrorMessage("개체를 놓을 공간이 없습니다.");
                return;
            }

            _player.UnHold();
        }
        else if (_player.IsHold == true && hold == false)
        {
            UIManager.Instance.ErrorMessage("이미 가지고 있는 개체 존재");
        }
    }

    public void ResetHoldBlock()
    {
        if(hold == true)
        {
            _player.UnHold();
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
