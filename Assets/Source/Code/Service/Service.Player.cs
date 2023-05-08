using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;

namespace Service {
    public static partial class Player 
    {
        public static partial class Key
        {
            public const string _Player =  nameof(Player) + ".";
            public const string OnLifeChange = _Player + "OnLifeChange";
            public const string Generate = _Player + nameof(Generate);
        }
    }
    public static partial class Player
    {
        public static void Generate(Transform parent)
        {
            Key.Generate.Dispatch(parent);
        }
    }
}

