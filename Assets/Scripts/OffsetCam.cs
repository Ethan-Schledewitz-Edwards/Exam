using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCam : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;

    public void AssignTarget(Transform newTarget)
    {
        _target = newTarget;
    }

    public void DecoupleTarget()
    {
        _target = null;
    }

    private void Update()
    {
        if (_target)
            transform.position = _target.position + _offset;
    }
}
