using Service;
using System.Collections;
using System.Collections.Generic;
using Kingdox.UniFlux;
using UnityEngine;

public sealed class LampFlux : MonoFlux 
{
    [SerializeField] private LampEntity prefab_lamp = default;
    [SerializeField] private List<LampEntity> lamps = new List<LampEntity>();
    [Flux(Lamp.Key.GenerateByParent)] private void GenerateByParent(Transform tr)
    {
        foreach (Transform item in tr) Generate(item);
    }
    private void Generate(Transform tr)
    {
        Lamp.OnGenerate(Instantiate(prefab_lamp, tr.position, Quaternion.identity, transform));
    }
    [Flux(Lamp.Key.OnGenerate)] private void OnGenerate(MonoBehaviour entity)
    {
        lamps.Add(entity as LampEntity);
    }
}