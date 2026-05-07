using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using UnityEngine;

namespace BDLib
{
    namespace Pathed
    {
        namespace Player
        {
            static public class Controller
            {
                private static Network __instance;

                private static Dictionary<NetworkPlayer, Network> playerControllers = new Dictionary<NetworkPlayer, Network>();

                internal static void OnPlayerJoin()
                {

                }

                public static Network getPatchedPlayer()
                {
                    return __instance;
                }
                //public static Network getPatchedPlayer(NetworkPlayer comp)
                //{
                //    for (int i = 0;i++, 
                //}
            }
            public class Network : MonoBehaviour
            {

                public NetworkPlayer playerBehavior;
                public bool isLocalPlayer;
                public void Awake()
                {
                    playerBehavior = GetComponent<NetworkPlayer>();
                    isLocalPlayer = playerBehavior.IsLocalPlayer;
                }
            }
            public class Local : MonoBehaviour
            {
                public PlayerController playerBehavior;
                public void Awake()
                {
                    playerBehavior = GetComponent<PlayerController>();
                }
            }
        }
    }
    
}
