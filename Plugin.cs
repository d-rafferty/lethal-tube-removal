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
        private const string modVersion = "1.0.0";

        public static new Config MyConfig { get; internal set; }

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TubeRemoval Instance;

        internal ManualLogSource mls;

        public class Config
        {
            public static ConfigEntry<bool> deleteTube;
            public static ConfigEntry<bool> deleteBunkbeds;
            public static ConfigEntry<bool> deleteFileCabinets;
            public static ConfigEntry<bool> deleteOxygenTank;
            public Config(ConfigFile cfg)
            {
                deleteTube = cfg.Bind(
                   "General",
                   "Tube",
                   true,
                   "Deletes the tube on the floor"
               );
                var tubeToggle = new BoolCheckBoxConfigItem(deleteTube, requiresRestart: false);
                LethalConfigManager.AddConfigItem(tubeToggle);

                deleteBunkbeds = cfg.Bind(
                    "General",
                    "BunkBeds",
                    false,
                    "Deletes the bunkbeds"
                );
                var bedToggle = new BoolCheckBoxConfigItem(deleteBunkbeds, requiresRestart: false);
                LethalConfigManager.AddConfigItem(bedToggle);

                deleteFileCabinets = cfg.Bind(
                    "General",
                    "File Cabinets",
                    false,
                    "Deletes the file cabinets"
                );
                var fileCabinetsToggle = new BoolCheckBoxConfigItem(deleteFileCabinets, requiresRestart: false);
                LethalConfigManager.AddConfigItem(fileCabinetsToggle);

                deleteOxygenTank = cfg.Bind(
                    "General",
                    "Oxygen Tank",
                    false,
                    "Deletes the oxygen tank"
                );
                var oxygenTankToggle = new BoolCheckBoxConfigItem(deleteOxygenTank, requiresRestart: false);
                LethalConfigManager.AddConfigItem(oxygenTankToggle);
            }
        }

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
        }
    }

}