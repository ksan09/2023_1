using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Transform _startPos;
    public Vector3 StartPos => _startPos.position;
}
