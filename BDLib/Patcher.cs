using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using HarmonyLib;


// Handler for game functions, using for event system(for devs) and for library classes. I used Harmony here.

namespace BDLib
{
    

    [HarmonyPatch(typeof(NetworkPlayer), "PlayerDied_ClientRpc")]
    public class NetworkPlayerDeathPatch
    {   
        static void Prefix(NetworkPlayer __instance)
        {
            Logging.LogPatcher("NetworkPlayer died!");
            BDLib.Events.PlayerEvents.NetworkPlayer.OnDeath?.Invoke(__instance.IsLocalPlayer);
        }
    }
    [HarmonyPatch(typeof(NetworkPlayer), "PlayerRespawned_ClientRpc")]
    public class NetworkPlayerSpawnPatch
    {
        static void Prefix(NetworkPlayer __instance)
        {
            Logging.LogPatcher("NetworkPlayer spawned(respawned)!");
            BDLib.Events.PlayerEvents.NetworkPlayer.OnSpawn?.Invoke(__instance.IsLocalPlayer);
        }
    }
}
