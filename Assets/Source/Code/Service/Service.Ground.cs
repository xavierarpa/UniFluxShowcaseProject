using Kingdox.UniFlux;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Service
{
    public static partial class Ground
    {
        public static partial class Key
        {
            private const string _Key = nameof(Ground);
            public const string Generate = _Key + nameof(Generate);
        }
    }
    public static partial class Ground
    {
        public static void Generate(Transform parent)
        {
            Key.Generate.Dispatch(parent);
        }
    }
}