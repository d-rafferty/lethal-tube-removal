using HarmonyLib;
using UnityEngine;
using static LethalTubeRemoval.Config;

namespace LethalTubeRemoval.Patches;

[HarmonyPatch(typeof(GameObject))]
internal class TerminalReposition
{
    private static Terminal terminal;
    private static ShipTeleporter teleporter = null;

    [HarmonyPrefix]
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    private static void TerminalMove()
    {
        if (terminalReposition.Value)
        {
            var terminal = GameObject.Find("Environment/HangarShip/Terminal");
            var Term = terminal
                .GetComponent<
                    AutoParentToShip>(); //gets the AutoParentToShip component for the terminal where positioning is set

            var localTerminalPos = new Vector3(9.1888f, 0.971f, -4.4357f); //sets coords for the terminal on startup
            var terminalRotation = new Vector3(270f, 359.8239f, 0f); //sets the rotation of the terminal

            Term.positionOffset = localTerminalPos;
            Term.rotationOffset = terminalRotation; //sets the offsets to our defined coordinates
        }
    }

    [HarmonyPrefix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    private static void TerminalMoveCustom()
    {
        if (customTerminal.Value)
        {
            var terminal = GameObject.Find("Environment/HangarShip/Terminal");
            var Term = terminal.GetComponent<AutoParentToShip>();

            var localTerminalPos = new Vector3(xCordTerm.Value, yCordTerm.Value, zCordTerm.Value);
            var terminalRotation = new Vector3(xRotTerm.Value, yRotTerm.Value, zRotTerm.Value);

            Term.positionOffset = localTerminalPos;
            Term.rotationOffset = terminalRotation;
        }
    }

    [HarmonyPatch(typeof(Terminal), "Start")]
    [HarmonyPostfix]
    private static void TerminalLightStart(Terminal __instance)
    {
        terminal = __instance;
        if (lowLightMode.Value) terminal.terminalLight.enabled = true;
    }

    [HarmonyPatch(typeof(Terminal), "SetTerminalInUseClientRpc")]
    [HarmonyPostfix]
    private static void TerminalLight(Terminal __instance)
    {
        terminal = __instance;
        if (lowLightMode.Value) terminal.terminalLight.enabled = true;
    }


    //Custom Terminal Coords
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    public static void CustomTerminalMove()
    {
    }
}