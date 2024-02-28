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
        private const string modVersion = "1.1.0";

        public static new Config MyConfig { get; internal set; }

        private readonly Harmony harmony = new Harmony(modGUID);

        private static TubeRemoval Instance;

        internal ManualLogSource mls;

        public class Config
        {
            public static ConfigEntry<bool> deleteTube;                 //initializes the config entry for each ship item, uses LethalConfig
            public static ConfigEntry<bool> deleteBunkbeds;
            public static ConfigEntry<bool> deleteFileCabinets;
            public static ConfigEntry<bool> deleteOxygenTank;
            public static ConfigEntry<bool> deleteClipboard;
            public static ConfigEntry<bool> deleteDoorGenerator;
            public static ConfigEntry<bool> deleteBoots;
            public static ConfigEntry<bool> deleteMask;
            public static ConfigEntry<bool> deleteAirFilter;
            public static ConfigEntry<bool> deleteStickyNote;
            public static ConfigEntry<bool> deleteBatteries;

            public Config(ConfigFile cfg)
            {
                deleteTube = cfg.Bind(                                  //sets initial LethalConfig values
                   "General",                                           //type of change
                   "Tube",                                              //Name in the UI
                   true,                                                //default value
                   "Deletes the tube on the floor"                      //Description for UI
               );
                var tubeToggle = new BoolCheckBoxConfigItem(deleteTube, requiresRestart: false);    //sets as checkbox for bool, sets restart flag as false as these changes do not require a restart of the game
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

                deleteClipboard = cfg.Bind(
                    "General",
                    "Clipboard",
                    false,
                    "Deletes the clipboard"
                );
                var clipboardToggle = new BoolCheckBoxConfigItem(deleteClipboard, requiresRestart: false);
                LethalConfigManager.AddConfigItem(clipboardToggle);

                deleteDoorGenerator = cfg.Bind(
                    "General",
                    "Door Generator",
                    false,
                    "Deletes the door generator"
                );
                var doorGeneratorToggle = new BoolCheckBoxConfigItem(deleteDoorGenerator, requiresRestart: false);
                LethalConfigManager.AddConfigItem(doorGeneratorToggle);

                deleteBoots = cfg.Bind(
                    "General",
                    "Boots",
                    false,
                    "Deletes the boots under the clothing rack"
                );
                var bootsToggle = new BoolCheckBoxConfigItem(deleteBoots, requiresRestart: false);
                LethalConfigManager.AddConfigItem(bootsToggle);

                deleteMask = cfg.Bind(
                    "General",
                    "Mask",
                    false,
                    "Deletes the mask on the control desk"
                );
                var maskToggle = new BoolCheckBoxConfigItem(deleteMask, requiresRestart: false);
                LethalConfigManager.AddConfigItem(maskToggle);

                deleteAirFilter = cfg.Bind(
                    "General",
                    "Air Filter",
                    false,
                    "Deletes the air filter on the wall"
                );
                var airFilterToggle = new BoolCheckBoxConfigItem(deleteAirFilter, requiresRestart: false);
                LethalConfigManager.AddConfigItem(airFilterToggle);

                deleteStickyNote = cfg.Bind(
                    "General",
                    "Sticky Note",
                    false,
                    "Deletes the sticky note"
                );
                var stickyNoteToggle = new BoolCheckBoxConfigItem(deleteStickyNote, requiresRestart: false);
                LethalConfigManager.AddConfigItem(stickyNoteToggle);

                deleteBatteries = cfg.Bind(
                    "General",
                    "Batteries",
                    false,
                    "Deletes the batteries on control desk"
                );
                var batteryToggle = new BoolCheckBoxConfigItem(deleteBatteries, requiresRestart: false);
                LethalConfigManager.AddConfigItem(batteryToggle);
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