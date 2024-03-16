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
using static LethalTubeRemoval.Config;

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
            
            if (Config.terminalReposition.Value)
            {
                GameObject terminal = GameObject.Find("Environment/HangarShip/Terminal");
                AutoParentToShip Term = terminal.GetComponent<AutoParentToShip>();                  //gets the AutoParentToShip component for the terminal where positioning is set

                UnityEngine.Vector3 localTerminalPos = new Vector3(9.1888f, 0.971f, -4.4357f);      //sets coords for the terminal on startup
                UnityEngine.Vector3 terminalRotation = new Vector3(270f, 359.8239f, 0f);            //sets the rotation of the terminal
                
                Term.positionOffset = localTerminalPos;
                Term.rotationOffset = terminalRotation;                                             //sets the offsets to our defined coordinates
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(StartOfRound), "Update")]
        static void TerminalMoveCustom()
        {
            if (Config.customTerminal.Value)
            {
                GameObject terminal = GameObject.Find("Environment/HangarShip/Terminal");
                AutoParentToShip Term = terminal.GetComponent<AutoParentToShip>();

                UnityEngine.Vector3 localTerminalPos = new Vector3(xCordTerm.Value, yCordTerm.Value, zCordTerm.Value);
                UnityEngine.Vector3 terminalRotation = new Vector3(xRotTerm.Value, yRotTerm.Value, zRotTerm.Value);

                Term.positionOffset = localTerminalPos;
                Term.rotationOffset = terminalRotation;
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


        //Custom Terminal Coords
        [HarmonyPostfix]
        [HarmonyPatch(typeof(StartOfRound), "Update")]
        public static void CustomTerminalMove()
        {
            
        }
    }
}
