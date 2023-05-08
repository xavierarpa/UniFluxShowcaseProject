using Kingdox.UniFlux;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class LampEntity : MonoFlux
{
    [field: SerializeField] public MeshRenderer MeshRenderer { get; private set; }
    [SerializeField] private float _distanceToActive = default;
    private bool _isOn;
    private void Awake()
    {
        OnChangeMaterial();
    }
    [Flux(Service.Lamp.Key.UpdatePlayer)] private void CheckPlayerPosition(Transform playerPos)
    {
        if (IsNear(playerPos))
        {
            if (_isOn) return;
            _isOn = true;
            TurnOn();
        }
        else
        {
            if (!_isOn) return;
            _isOn = false;
            TurnOff();
        }
    }
    private bool IsNear(Transform tr) 
    {
        return (transform.position - tr.position).magnitude <= _distanceToActive;
    }
    [Flux("Light.OnChangeMaterialOn")] private void OnChangeMaterialOn() => OnChangeMaterial();
    [Flux("Light.OnChangeMaterialOff")] private void OnChangeMaterialOff() => OnChangeMaterial();
    private void OnChangeMaterial()
    {
        if(_isOn) TurnOn();
        else TurnOff();
    }
    private void TurnOn() 
    {
        MeshRenderer.material = "Lamp.MaterialOn".Dispatch<Material>();
    }
    private void TurnOff()
    {
        MeshRenderer.material = "Lamp.MaterialOff".Dispatch<Material>();
    }
}
