using Kingdox.UniFlux;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraFlux : MonoFlux
{
    [SerializeField] private CameraEntity prefab_camera = default;
    [Flux(Service.Camera.Key.Generate)] private void Generate(Transform tr)
    {
        Instantiate(prefab_camera, tr.position, Quaternion.identity, transform);
    }
}
