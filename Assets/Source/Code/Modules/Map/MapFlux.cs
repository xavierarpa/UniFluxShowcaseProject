using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Kingdox.UniFlux;
using Service;
public sealed class MapFlux : MonoFlux 
{
    [SerializeField] private MapEntity prefab_map;
    [SerializeField] private List<MapEntity> maps = new List<MapEntity>();
    //
    [Flux(Map.Key.Generate)] private void Generate() 
    {
        Service.Map.OnGenerate(Instantiate(prefab_map, transform));
    }
    [Flux(Map.Key.OnGenerate)] private void OnGenerate(MonoBehaviour entity)
    {
        maps.Add(entity as MapEntity);
    }
    [Flux(Map.Key.Load)] private void Load() 
    {
        foreach (var _map in maps)
        {
            Service.Lamp.GenerateByParent(_map.LampParent);
            Service.Ground.Generate(_map.GroundParent);
            Service.Player.Generate(_map.PlayerParent);
            Service.Camera.Generate(_map.CameraParent);
        }
    }
}