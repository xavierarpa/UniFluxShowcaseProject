using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;

namespace Service 
{
    public static partial class Lamp // Data
    {
        private static partial class Data
        {
        }
    }
    public static partial class Lamp // Key
    {
        public static partial class Key
        {
            private const string _Key =  nameof(Lamp) + ".";
            public const string GenerateByParent = _Key + nameof(GenerateByParent);
            public const string OnGenerate = _Key + nameof(OnGenerate);
            public const string UpdatePlayer = _Key + nameof(UpdatePlayerPosition);
            public const string TurnOn = _Key + nameof(TurnOn);
            public const string TurnOff = _Key + nameof(TurnOff);
        }
    }
    public static partial class Lamp // Methods
    {
        public static void GenerateByParent(Transform parent) 
        {
            Key.GenerateByParent.Dispatch(parent);
        }
        public static void OnGenerate(MonoBehaviour entity)
        {
            Key.OnGenerate.Dispatch(entity);
        }
        public static void UpdatePlayerPosition(Transform playerPos)
        {
            Key.UpdatePlayer.Dispatch(playerPos);
        }
    }
}