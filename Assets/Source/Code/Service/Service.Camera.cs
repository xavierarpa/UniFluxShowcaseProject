using Kingdox.UniFlux;
using UnityEngine;

namespace Service
{
    public static partial class Camera
    {
        public static partial class Key
        {
            public const string _Camera = nameof(Camera) + ".";
            public const string OnMove = _Camera + nameof(OnMove);
            public const string OnRotate = _Camera + nameof(OnRotate);
            public const string Generate = _Camera + nameof(Generate);
        }
    }
    public static partial class Camera
    {
        public static void OnMove(Vector3 targetPos)
        {
            Key.OnMove.Dispatch(targetPos);
        }
        public static void OnRotate(Quaternion rotate)
        {
            Key.OnRotate.Dispatch(rotate);
        }
        public static void Generate(Transform parent)
        {
            Key.Generate.Dispatch(parent);
        }
    }
}
