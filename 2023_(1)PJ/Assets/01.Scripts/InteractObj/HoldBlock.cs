using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldBlock : MonoBehaviour, IInteractable
{
    private bool isHold = false;
    private PlayerBrain _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerBrain>();
    }

    private void Update()
    {
        
    }

    private void Holding()
    {
        if (isHold == false) return;
    }

    public void Interact()
    {
        isHold = !isHold;
    }
}
