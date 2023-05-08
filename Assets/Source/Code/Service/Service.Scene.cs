using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdox.UniFlux;

namespace Service 
{
    public static partial class Scene
    {
        private static partial class Data
        {
            public const string Bootstrap = "Bootstrap";
            public const string Scene = "UniFlux.Scene";
            public const string Keyboard = Kingdox.UniFlux.Input.InputData.SCENE;
            public const string EventSystem = "EventSystem";
            public const string Hud = "Hud";
            public const string Player = "Player";
            public const string Camera = "Camera";
            public const string Map = "Map";
            public const string Ground = "Ground";
            public const string Lamps = "Lamps";
        }
        public static int Count => UnityEngine.SceneManagement.SceneManager.sceneCount;
        public static bool IsMultiScene => Count>1;
        public static partial class Load
        {
            internal static void __Load(in string name) => UnityEngine.SceneManagement.SceneManager.LoadScene(name, UnityEngine.SceneManagement.LoadSceneMode.Single);
            public static void Bootstrap() => __Load(Data.Bootstrap);
        }
        public static partial class Add
        {
            internal static IEnumerator __Add(in string name) => Kingdox.UniFlux.Scenes.Key.Add.IEnumerator(name);
            public static IEnumerator Scene 
            {
                get 
                {
                    yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(Data.Scene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
                }
            }
            public static IEnumerator Keyboard => __Add(Data.Keyboard);
            public static IEnumerator EventSystem => __Add(Data.EventSystem);
            public static IEnumerator Ground => __Add(Data.Ground);
            public static IEnumerator Hud => __Add(Data.Hud);
            public static IEnumerator Map => __Add(Data.Map);
            public static IEnumerator Player => __Add(Data.Player); 
            public static IEnumerator Lamps => __Add(Data.Lamps);
            public static IEnumerator Camera => __Add(Data.Camera);
        }
    }
}