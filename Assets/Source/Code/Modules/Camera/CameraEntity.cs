using Kingdox.UniFlux;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraEntity : MonoFlux
{
    [SerializeField] float _deadZone;
    [Space]
    [SerializeField] Vector3 _target;
    [SerializeField] Vector3 _offset;
    [SerializeField] Vector3 _rotationOffset;
    [SerializeField] float _speed_movement;

    private void Awake()
    {
        _target = transform.position;
        transform.position = _target+ _offset;
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, _target+_offset) > _deadZone)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target + _offset, _speed_movement * Time.deltaTime);
        }
    }
    [Flux(Service.Camera.Key.OnMove)] private void MoveCamera(Vector3 tar)
    {
        _target = tar;
    }
    [Flux(Service.Camera.Key.OnRotate)] private void RotateCamera(Quaternion rotation)
    {
        rotation.eulerAngles += _rotationOffset;
        transform.rotation = rotation;
    }
}
