using BepInEx.Configuration;
using LethalConfig.ConfigItems;
using LethalConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LethalTubeRemoval
{
    public class Config
    {
        private const string inside = "Inside Ship:";

        private const string outside = "Outside Ship:";

        private const string storeItems = "Store Items:";

        private const string misc = "Misc Modes:";

        //Store Items
        public static ConfigEntry<bool> deleteTeleporterCord;

        //Inside Ship
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
        public static ConfigEntry<bool> deleteVent;
        public static ConfigEntry<bool> deleteMonitorCords;
        public static ConfigEntry<bool> deleteDoorSpeaker;
        public static ConfigEntry<bool> deleteMainSpeaker;
        public static ConfigEntry<bool> deletePosters;
        public static ConfigEntry<bool> deleteClothingRack;
        public static ConfigEntry<bool> deleteDoorTubes;
        public static ConfigEntry<bool> deleteKeyboardCord;
        public static ConfigEntry<bool> terminalReposition;

        //Outside Ship
        public static ConfigEntry<bool> deleteFloodLight;
        public static ConfigEntry<bool> deleteOutsideTubing;
        public static ConfigEntry<bool> deleteMachinery;
        public static ConfigEntry<bool> deleteRailing;
        public static ConfigEntry<bool> deleteThrusterTube;
        public static ConfigEntry<bool> deleteThrusters;
        public static ConfigEntry<bool> deleteSupportBeams;
        public static ConfigEntry<bool> deleteWeirdBox;
        public static ConfigEntry<bool> deleteLeftMachinery;

        //Misc
        public static ConfigEntry<bool> parkourMode;
        public static ConfigEntry<bool> lowLightMode;



        public Config(ConfigFile cfg)
        {
            //Inside Ship

            deleteTube = cfg.Bind(                                  //sets initial LethalConfig values
               inside,                                           //type of change
               "Tube",                                              //Name in the UI
               true,                                                //default value
               "Deletes the tube on the floor"                      //Description for UI
           );
            var tubeToggle = new BoolCheckBoxConfigItem(deleteTube, requiresRestart: false);    //sets as checkbox for bool, sets restart flag as false as these changes do not require a restart of the game
            LethalConfigManager.AddConfigItem(tubeToggle);

            deleteBunkbeds = cfg.Bind(
                inside,
                "BunkBeds",
                false,
                "Deletes the bunkbeds"
            );
            var bedToggle = new BoolCheckBoxConfigItem(deleteBunkbeds, requiresRestart: false);
            LethalConfigManager.AddConfigItem(bedToggle);

            deleteFileCabinets = cfg.Bind(
               inside,
                "File Cabinets",
                false,
                "Deletes the file cabinets"
            );
            var fileCabinetsToggle = new BoolCheckBoxConfigItem(deleteFileCabinets, requiresRestart: false);
            LethalConfigManager.AddConfigItem(fileCabinetsToggle);

            deleteOxygenTank = cfg.Bind(
                inside,
                "Oxygen Tank",
                false,
                "Deletes the oxygen tank"
            );
            var oxygenTankToggle = new BoolCheckBoxConfigItem(deleteOxygenTank, requiresRestart: false);
            LethalConfigManager.AddConfigItem(oxygenTankToggle);

            deleteClipboard = cfg.Bind(
                inside,
                "Clipboard",
                false,
                "Deletes the clipboard"
            );
            var clipboardToggle = new BoolCheckBoxConfigItem(deleteClipboard, requiresRestart: false);
            LethalConfigManager.AddConfigItem(clipboardToggle);

            deleteDoorGenerator = cfg.Bind(
                inside,
                "Door Generator",
                false,
                "Deletes the door generator"
            );
            var doorGeneratorToggle = new BoolCheckBoxConfigItem(deleteDoorGenerator, requiresRestart: false);
            LethalConfigManager.AddConfigItem(doorGeneratorToggle);

            deleteBoots = cfg.Bind(
                inside,
                "Boots",
                false,
                "Deletes the boots under the clothing rack"
            );
            var bootsToggle = new BoolCheckBoxConfigItem(deleteBoots, requiresRestart: false);
            LethalConfigManager.AddConfigItem(bootsToggle);

            deleteMask = cfg.Bind(
                inside,
                "Mask",
                false,
                "Deletes the mask on the control desk"
            );
            var maskToggle = new BoolCheckBoxConfigItem(deleteMask, requiresRestart: false);
            LethalConfigManager.AddConfigItem(maskToggle);

            deleteAirFilter = cfg.Bind(
                inside,
                "Air Filter",
                false,
                "Deletes the air filter on the wall"
            );
            var airFilterToggle = new BoolCheckBoxConfigItem(deleteAirFilter, requiresRestart: false);
            LethalConfigManager.AddConfigItem(airFilterToggle);

            deleteStickyNote = cfg.Bind(
                inside,
                "Sticky Note",
                false,
                "Deletes the sticky note"
            );
            var stickyNoteToggle = new BoolCheckBoxConfigItem(deleteStickyNote, requiresRestart: false);
            LethalConfigManager.AddConfigItem(stickyNoteToggle);

            deleteBatteries = cfg.Bind(
                inside,
                "Batteries",
                false,
                "Deletes the batteries on control desk"
            );
            var batteryToggle = new BoolCheckBoxConfigItem(deleteBatteries, requiresRestart: false);
            LethalConfigManager.AddConfigItem(batteryToggle);

            deleteVent = cfg.Bind(
                inside,
                "Vent",
                false,
                "Deletes the vent below the charging station"
            );
            var ventToggle = new BoolCheckBoxConfigItem(deleteVent, requiresRestart: false);
            LethalConfigManager.AddConfigItem(ventToggle);

            deleteMonitorCords = cfg.Bind(
               inside,
               "Monitor Cords",
               false,
               "Deletes the cords behind the monitors"
           );
            var monitorCordsToggle = new BoolCheckBoxConfigItem(deleteMonitorCords, requiresRestart: false);
            LethalConfigManager.AddConfigItem(monitorCordsToggle);

            deleteDoorSpeaker = cfg.Bind(
               inside,
               "Door Speaker",
               false,
               "Deletes the speaker near the ship door"
           );
            var doorSpeakerToggle = new BoolCheckBoxConfigItem(deleteDoorSpeaker, requiresRestart: false);
            LethalConfigManager.AddConfigItem(doorSpeakerToggle);

            deleteMainSpeaker = cfg.Bind(
               inside,
               "Main Speaker",
               false,
               "Deletes the main speaker that normally plays audio. WARNING: No ship-speaker audio will play if this is selected!"
           );
            var mainSpeakerToggle = new BoolCheckBoxConfigItem(deleteMainSpeaker, requiresRestart: false);
            LethalConfigManager.AddConfigItem(mainSpeakerToggle);

            deletePosters = cfg.Bind(
               inside,
               "Posters",
               false,
               "Deletes the posters inside the ship"
           );
            var postersToggle = new BoolCheckBoxConfigItem(deletePosters, requiresRestart: false);
            LethalConfigManager.AddConfigItem(postersToggle);

            deleteClothingRack = cfg.Bind(
               inside,
               "Clothing Rack",
               false,
               "Deletes the clothing rack. WARNING: Purchasable suits will not be able to be equipped if this is selected!"
           );
            var clothingRackToggle = new BoolCheckBoxConfigItem(deleteClothingRack, requiresRestart: false);
            LethalConfigManager.AddConfigItem(clothingRackToggle);

            deleteDoorTubes = cfg.Bind(
               inside,
               "Door Tubes",
               false,
               "Deletes the tubes by the ship door."
           );
            var doorTubesToggle = new BoolCheckBoxConfigItem(deleteDoorTubes, requiresRestart: false);
            LethalConfigManager.AddConfigItem(doorTubesToggle);

            deleteKeyboardCord = cfg.Bind(
               inside,
               "Keyboard Cord",
               true,
               "Deletes the cord coming out of the keyboard on the terminal"
           );
            var keyboardCordToggle = new BoolCheckBoxConfigItem(deleteKeyboardCord, requiresRestart: false);
            LethalConfigManager.AddConfigItem(keyboardCordToggle);


            terminalReposition = cfg.Bind(
               inside,
               "Terminal Reposition",
               false,
               "Sets the terminal to the left of the monitors by default."
           );
            var terminalRepositionToggle = new BoolCheckBoxConfigItem(terminalReposition, requiresRestart: false);
            LethalConfigManager.AddConfigItem(terminalRepositionToggle);



            // OUTSIDE SHIP
            deleteFloodLight = cfg.Bind(
               outside,
               "Floodlight",
               false,
               "Removes the floodlight outside the ship"
           );
            var deleteFloodlightToggle = new BoolCheckBoxConfigItem(deleteFloodLight, requiresRestart: false);
            LethalConfigManager.AddConfigItem(deleteFloodlightToggle);

            deleteMachinery = cfg.Bind(
               outside,
               "Machinery Boxes",
               false,
               "Removes the machinery boxes on both sides of the ship"
           );
            var machineryToggle = new BoolCheckBoxConfigItem(deleteMachinery, requiresRestart: false);
            LethalConfigManager.AddConfigItem(machineryToggle);

            deleteOutsideTubing = cfg.Bind(
               outside,
               "Tubing",
               false,
               "Removes the tubing outside the ship"
           );
            var outsideTubingToggle = new BoolCheckBoxConfigItem(deleteOutsideTubing, requiresRestart: false);
            LethalConfigManager.AddConfigItem(outsideTubingToggle);

            deleteRailing = cfg.Bind(
               outside,
               "Railing",
               false,
               "Removes the railing outside the ship"
           );
            var railingToggle = new BoolCheckBoxConfigItem(deleteRailing, requiresRestart: false);
            LethalConfigManager.AddConfigItem(railingToggle);

            deleteThrusterTube = cfg.Bind(
              outside,
               "Back Right Thruster Tube",
               false,
               "Removes the thruster tube in the back right. NOTE: Also deletes back right thruster"
           );
            var thrusterTubeToggle = new BoolCheckBoxConfigItem(deleteThrusterTube, requiresRestart: false);
            LethalConfigManager.AddConfigItem(thrusterTubeToggle);

            deleteThrusters = cfg.Bind(
               outside,
               "All Thrusters",
               false,
               "Removes all thrusters."
           );
            var thrustersToggle = new BoolCheckBoxConfigItem(deleteThrusters, requiresRestart: false);
            LethalConfigManager.AddConfigItem(thrustersToggle);

            deleteSupportBeams = cfg.Bind(
               outside,
               "Support Beams Under Ship",
               false,
               "Removes support beams."
           );
            var supportBeamsToggle = new BoolCheckBoxConfigItem(deleteSupportBeams, requiresRestart: false);
            LethalConfigManager.AddConfigItem(thrustersToggle);

            deleteWeirdBox = cfg.Bind(
               outside,
               "Large Exhaust",
               false,
               "Removes large exhaust box near front of ship"
           );
            var weirdBoxToggle = new BoolCheckBoxConfigItem(deleteWeirdBox, requiresRestart: false);
            LethalConfigManager.AddConfigItem(thrustersToggle);

            deleteLeftMachinery = cfg.Bind(
               outside,
               "Left Machinery",
               false,
               "Removes machinery and bottom tubing from left of ship"
           );
            var leftMachineryToggle = new BoolCheckBoxConfigItem(deleteLeftMachinery, requiresRestart: false);
            LethalConfigManager.AddConfigItem(leftMachineryToggle);




            //MISC MODES
            parkourMode = cfg.Bind(
              misc,
              "Parkour Mode",
              false,
              "Only for the bravest Company Employees. Removes catwalk and ladders from the outside of the ship."
          );
            var parkourToggle = new BoolCheckBoxConfigItem(parkourMode, requiresRestart: false);
            LethalConfigManager.AddConfigItem(parkourToggle);

            lowLightMode = cfg.Bind(
             misc,
             "Low Light Mode",
             false,
             "Removes some lights inside the ship"
         );
            var lightToggle = new BoolCheckBoxConfigItem(lowLightMode, requiresRestart: false);
            LethalConfigManager.AddConfigItem(lightToggle);



            //Store Items
            deleteTeleporterCord = cfg.Bind(
             storeItems,
             "Teleporter Cord",
             false,
             "Removes the long cord from the teleporter"
         );
            var teleCordToggle = new BoolCheckBoxConfigItem(deleteTeleporterCord, requiresRestart: false);
            LethalConfigManager.AddConfigItem(teleCordToggle);
        }
    }
}