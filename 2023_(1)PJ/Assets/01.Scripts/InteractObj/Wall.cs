using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layer;

    [SerializeField]
    private Transform _wallBrickTrm;

    private Rigidbody[] _wallRigidbody;

    private void Awake()
    {
        _wallRigidbody = _wallBrickTrm.GetComponentsInChildren<Rigidbody>();
    }
}
