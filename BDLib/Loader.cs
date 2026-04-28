using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace BDLib
{
    [BepInPlugin("com.coolchair.BDLibLoader", "BDLibLoader", "1.0.0")]
    public class BDLibLoaderPlugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("BDLib pathing starting...");
            var harmony = new Harmony("com.coolchair.BDLibLoader");

            harmony.PatchAll();
            Logger.LogInfo("BDLib was patched successful!");
        }
    }
}
