using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //플레이어가 떨어지면 다시 올리는 스크립트 작성
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.Instance.PlayerBrain.ResetPlayer();
            StageManager.Instance.TeleportStartPos();
        }

        HoldBlock _hold = other.GetComponent<HoldBlock>();
        if (_hold != null)
        {
            _hold.ResetHoldBlock();
        }
    }
}
