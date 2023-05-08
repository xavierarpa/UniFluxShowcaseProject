using Service;
using System.Collections;
using System.Collections.Generic;
using Kingdox.UniFlux;
using UnityEngine;

public sealed class LampFlux : MonoFlux 
{
    [SerializeField] private LampEntity prefab_lamp = default;
    [SerializeField] private List<LampEntity> lamps = new List<LampEntity>();
    [Space]
    [SerializeField] private Material m_on;
    [SerializeField] private Material m_off;
    protected override void OnFlux(in bool condition)
    {
        "Material.Light.On".StoreState<Material>(MaterialLightOn, condition);
        "Material.Light.Off".StoreState<Material>(MaterialLightOff, condition);
    }
    private void MaterialLightOn(Material on) 
    {
        m_on = on;
        "Light.OnChangeMaterialOn".Dispatch();
    }
    private void MaterialLightOff(Material off) 
    {
        m_off = off;
        "Light.OnChangeMaterialOff".Dispatch();
    }
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
    [Flux("Lamp.MaterialOn")] private Material MaterialOn() => m_on;
    [Flux("Lamp.MaterialOff")] private Material MaterialOff() => m_off;
}
