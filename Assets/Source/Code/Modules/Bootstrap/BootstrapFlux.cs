using System;
using System.Collections;
using UnityEngine;
using Service;
using Kingdox.UniFlux;
public sealed class BootstrapFlux : MonoFlux
{
    [SerializeField] private Material _m_light_on;
    [SerializeField] private Material _m_light_off;

    private void Awake()
    {
        if(Scene.IsMultiScene)
        {
            Reset();
        }
    }
    private IEnumerator Start()
    {
        "Material.Light.On".DispatchState(_m_light_on);
        "Material.Light.Off".DispatchState(_m_light_off);

        //Adding Modules
        yield return Scene.Add.Scene;
        yield return Scene.Add.Keyboard;
        yield return Scene.Add.EventSystem;
        yield return Scene.Add.Map;
        yield return Scene.Add.Ground;
        yield return Scene.Add.Lamps;
        yield return Scene.Add.Player;
        yield return Scene.Add.Camera;

        Map.Generate();
        Map.Load();
        //Adding Movements
        Keyboard.Add.Up();
        Keyboard.Add.Down();
        Keyboard.Add.Left();
        Keyboard.Add.Right();
        Keyboard.Add.Space();
    }
    [Flux(Bootstrap.Key.Reset)] private void Reset() 
    {
        Scene.Load.Bootstrap();
    }
}
