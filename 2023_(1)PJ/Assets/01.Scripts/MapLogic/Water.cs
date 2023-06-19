using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //�÷��̾ �������� �ٽ� �ø��� ��ũ��Ʈ �ۼ�
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
