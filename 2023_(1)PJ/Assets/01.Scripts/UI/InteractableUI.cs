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

        Camera cam = Camera.main;

        bool isHit = (Physics.Raycast(cam.transform.position,
            cam.transform.forward, out hit, _dist, layer));

        if (isHit == false)
        {
            _textUI.text = "";
            return;
        }

        IInteractable interactableObj = hit.transform.gameObject.GetComponent<IInteractable>();
        if (interactableObj == null)
        {
            _textUI.text = "";
            return;
        }

        // UI Ç¥½Ã
        _textUI.text = interactText;

        if (InputManager.Instance.InteractKeyDown())
        {
            interactableObj.Interact();
        }
    }
}
