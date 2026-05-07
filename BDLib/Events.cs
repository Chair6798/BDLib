using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
namespace BDLib
{
    namespace Events
    {
        public static class SceneEvents
        {
            internal static void Init()
            {
                OnGameSceneLoaded= new UnityEvent();
                OnMenuSceneLoaded = new UnityEvent();
                SceneManager.sceneLoaded += OnSceneLoaded;
            }   
            private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
            {
                Logging.LogEvent("Scene loaded: " + scene.name);
                if (scene.name == "MainMenu")
                {
                    OnMenuSceneLoaded.Invoke();

                }
                else
                {
                    OnGameSceneLoaded.Invoke();
                }
            }
            public static UnityEvent OnGameSceneLoaded;
            public static UnityEvent OnMenuSceneLoaded;
        }
        namespace PlayerEvents
        {
            
            public static class LocalPlayer
            {
                internal static void Init()
                {
                    OnDeath = new UnityEvent();
                    OnSpawn = new UnityEvent();
                }
                public static UnityEvent OnDeath;
                public static UnityEvent OnSpawn;
            }
            public static class NetworkPlayer
            {
                internal static void Init()
                {
                    OnDeath = new UnityEvent<bool>();
                    OnSpawn = new UnityEvent<bool>();
                }
                public static UnityEvent<bool> OnDeath;
                public static UnityEvent<bool> OnSpawn;
            }
        }
    }
}
