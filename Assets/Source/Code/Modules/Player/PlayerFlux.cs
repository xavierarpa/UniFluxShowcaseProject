using Kingdox.UniFlux;
using Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerFlux : MonoFlux
{
    [SerializeField] private PlayerEntity prefab_player = default;
    
    [Flux(Player.Key.Generate)] private void Generate(Transform tr)
    {
        Instantiate(prefab_player, tr.position, Quaternion.identity, transform);
    }
}