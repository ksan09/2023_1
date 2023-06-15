using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour, IInteractable
{
    private bool clear = false;

    public void Interact()
    {
        if(clear == false)
        {
            GameManager.Instance.GameClear();
            clear = true;
        }
    }
}
