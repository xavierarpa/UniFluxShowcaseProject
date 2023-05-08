using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;
using Service;

public class GroundFlux : MonoFlux
{
    [SerializeField] private GroundEntity prefab_ground = default;

    [Flux(Ground.Key.Generate)] private void Generate(Transform tr)
    {
        Instantiate(prefab_ground, tr.position, Quaternion.identity, transform);
    }

}
