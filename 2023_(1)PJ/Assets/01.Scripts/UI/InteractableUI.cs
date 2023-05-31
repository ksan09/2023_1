using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractableUI : MonoBehaviour
{
    RaycastHit hit;
    TextMeshProUGUI _textUI;

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
        bool isHit = (Physics.Raycast(Define.MainCam.transform.position,
            Define.MainCam.transform.forward, out hit));

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

        // UI Ç¥½Ã
        _textUI.text = interactText;

        if (InputManager.Instance.InteractKeyDown())
        {
            interactableObj.Interact();
        }
    }
}
