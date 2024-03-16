using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LethalConfig.ConfigItems;
using LethalConfig;
using LethalTubeRemoval.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Security.Policy;

namespace LethalTubeRemoval
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("ainavt.lc.lethalconfig")]
    public class TubeRemoval : BaseUnityPlugin
    {
        private const string modGUID = "Hamster.LethalTubeRemoval";
        private const string modName = "Lethal Tube Removal";
        private const string modVersion = "1.5.0";

        public static new Config MyConfig { get; internal set; }

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TubeRemoval Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance = null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            mls.LogInfo("Mod is woked");

            MyConfig = new(base.Config);

            harmony.PatchAll(typeof(TubeRemoval));
            harmony.PatchAll(typeof(TubeRemovalPatch));
            harmony.PatchAll(typeof(TerminalReposition));
            harmony.PatchAll(typeof(OutsideShipPatch));
        }
    }

}