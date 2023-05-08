using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;

namespace Service 
{
    public static partial class Map // Data
    {
        private static partial class Data
        {
        }
    }
    public static partial class Map // Key
    {
        public static partial class Key
        {
            private const string _Map =  nameof(Map) + ".";
            public const string Generate = _Map + nameof(Generate);
            public const string OnGenerate = _Map + nameof(OnGenerate);
            public const string Load = _Map + nameof(Load);
        }
    }
    public static partial class Map // Methods
    {
        public static void Generate() 
        {
            Key.Generate.Dispatch();
        }
        public static void OnGenerate(MonoBehaviour entity)
        {
            Key.OnGenerate.Dispatch(entity);
        }
        public static void Load() 
        {
            Key.Load.Dispatch();
        }
    }
}