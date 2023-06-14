using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour, IInteractable
{
    private bool hold = false;
    private PlayerBrain _player;
    private Rigidbody _rigidbody;
    private BoxCollider _collider;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBrain>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
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
            _player.UnHold();
            Holding(false);
        }
        else if (_player.IsHold == true && hold == false)
        {
            UIManager.Instance.ErrorMessage("이미 들고 있는 개체 존재");
        }
    }
}
