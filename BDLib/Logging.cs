using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Rendering.LookDev;
using UnityEngine;
namespace BDLib
{
    internal static class Logging
    {
        public static void LogPatcher(string text) { Debug.Log("[DBLib Patcher] " + text); }
        public static void LogBuilder(string text) { Debug.Log("[DBLib Builder] " + text); }
        public static void LogPatchedPlayer(string text) { Debug.Log("[DBLib Patched player] " + text); }
        public static void LogEvent(string text) { Debug.Log("[DBLib Events] " + text); }
    }
}
