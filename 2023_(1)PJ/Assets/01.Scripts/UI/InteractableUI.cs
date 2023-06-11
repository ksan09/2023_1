using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableUI : MonoBehaviour
{
    RaycastHit hit;
    TextMeshProUGUI _textUI;
    private readonly float _dist = 4f;

    private readonly string interactText = "[E]";

    private void Awake()
    {
        _textUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        ShowInteractableUI();
    }

    private void ShowInteractableUI()
    {
        LayerMask layer = (-1) - (1 << LayerMask.NameToLayer("Player"));

        bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
            Define.MainCam.transform.forward, out hit, _dist, layer));

        Debug.Log("1");

        if (isHit == false)
        {
            _textUI.text = "";
            return;
        }
        Debug.Log("2");

        IInteractable interactableObj = hit.transform.gameObject.GetComponent<IInteractable>();
        if (interactableObj == null)
        {
            _textUI.text = "";
            return;
        }
        Debug.Log("3");

        // UI ǥ��
        _textUI.text = interactText;

        if (InputManager.Instance.InteractKeyDown())
        {
            interactableObj.Interact();
        }
    }
}
