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
            StageManager.Instance.ReloadStage();
        }

        HoldBlock _hold = other.GetComponent<HoldBlock>();
        if (_hold != null)
        {
            _hold.ResetHoldBlock();
        }
    }
}
