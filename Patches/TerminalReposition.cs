using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;
using static LethalTubeRemoval.TubeRemoval;
using JetBrains.Annotations;

namespace LethalTubeRemoval.Patches
{
    [HarmonyPatch(typeof(GameObject))]
    internal class TerminalReposition
    {
        static Terminal terminal = null;
        static ShipTeleporter teleporter = null;

        [HarmonyPrefix]
        [HarmonyPatch(typeof(StartOfRound), "Start")]

        static void TerminalMove()
        {
            GameObject terminal = GameObject.Find("Environment/HangarShip/Terminal");
            if (Config.terminalReposition.Value)
            {
                UnityEngine.Vector3 localTerminalPos = new Vector3(9.1888f, 0.971f, -4.4357f);      //sets coords for the terminal on startup
                UnityEngine.Vector3 terminalRotation = new Vector3(270f, 359.8239f, 0f);            //sets the rotation of the terminal

                AutoParentToShip Term = terminal.GetComponent<AutoParentToShip>();                  //gets the AutoParentToShip component for the terminal where positioning is set
                Term.positionOffset = localTerminalPos;
                Term.rotationOffset = terminalRotation;                                             //sets the offsets to our defined coordinates
            }
        }

        [HarmonyPatch(typeof(Terminal), "Start")]
        [HarmonyPostfix]
        static void TerminalLightStart(Terminal __instance)
        {
            terminal = __instance;
            if(Config.lowLightMode.Value)
            {
                terminal.terminalLight.enabled = true;
            }
        }

    [HarmonyPatch(typeof(Terminal), "SetTerminalInUseClientRpc")]
        [HarmonyPostfix]
        static void TerminalLight(Terminal __instance)
        {
            terminal = __instance;
            if (Config.lowLightMode.Value)
            {
                terminal.terminalLight.enabled = true;
            }
        }
    }
}
