using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour, IInteractable
{
    private bool hold = false;
    private PlayerBrain _player;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBrain>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Holding(bool use)
    {
        hold = use;
        _rigidbody.useGravity = !use;
        _rigidbody.constraints = use ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.FreezeRotation;
    }

    public void Interact()
    {
        if(_player.IsHold == false && hold == false)
        {
            _player.DoHold(transform);
            Holding(true);
        }
        else
        {
            _player.UnHold();
            Holding(false);
        }
    }
}
