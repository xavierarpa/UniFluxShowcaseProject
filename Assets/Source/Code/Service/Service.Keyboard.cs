using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;

namespace Service.ServicioNombre
{
    public static partial class Data
    {
        public static class Id
        {
            public const string Up = nameof(Up);
        }
    }
    public static partial class Function
    {
        public static void Up() => Debug.Log(Data.Id.Up);
    }
}
namespace Service
{
    public static partial class Keyboard 
    {
        public static partial class Key
        {
            public const string Add = Kingdox.UniFlux.Input.InputData.Add;
            public const string Remove = Kingdox.UniFlux.Input.InputData.Remove;
            public const string Clear = Kingdox.UniFlux.Input.InputData.Clear;

            public static partial class OnInput
            {
                public const string _OnInput = Kingdox.UniFlux.Input.InputData.OnInput;
                public const string Space = _OnInput + Data.Id.Space;
                public const string Right = _OnInput + Data.Id.Right;
                public const string Left = _OnInput + Data.Id.Left;
                public const string Down = _OnInput + Data.Id.Down;
                public const string Up = _OnInput + Data.Id.Up;

            }
        }
        private static partial class Data
        {
            public static class Id
            {
                public const string Up = nameof(Up);
                public const string Down = nameof(Down);
                public const string Left = nameof(Left);
                public const string Right = nameof(Right);
                public const string Space = nameof(Space);
            }
            public static class Method
            {
                public const string GetKey = nameof(Input.GetKey);
                public const string GetKeyUp = nameof(Input.GetKeyUp);
                public const string GetKeyDown = nameof(Input.GetKeyDown);
            }
        }
        public static partial class Add
        {
            public static void _Add((string id, KeyCode code, string inputType) data) => Key.Add.Dispatch(data);
            public static void Up() => _Add((Key.OnInput.Up, KeyCode.W, Data.Method.GetKey));
            public static void Down() => _Add((Key.OnInput.Down, KeyCode.S, Data.Method.GetKey));
            public static void Left() => _Add((Key.OnInput.Left, KeyCode.A, Data.Method.GetKey));
            public static void Right() => _Add((Key.OnInput.Right, KeyCode.D, Data.Method.GetKey));
            public static void Space() => _Add((Key.OnInput.Space, KeyCode.Space, Data.Method.GetKeyDown));

        }
        public static partial class Remove
        {
            public static void _Remove(string id) => Key.Remove.Dispatch(id);            
        }
        public static partial class OnInput
        {
            public static void Id(string id) =>  id.Dispatch();
        }
        public static void Clear() => Key.Clear.Dispatch();
    }
}
