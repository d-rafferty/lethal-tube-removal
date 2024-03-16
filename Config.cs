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
        private const string terminalmove = "Terminal Reposition";

        private const string chargingcoil = "Charging Coil Reposition";

        private const string inside = "Inside Ship";

        private const string outside = "Outside Ship";

        private const string storeItems = "Store Items";

        private const string misc = "Misc Modes";

        //Custom Terminal Coords
        public static ConfigEntry<bool> customTerminal;
        public static ConfigEntry<float> xCordTerm;
        public static ConfigEntry<float> yCordTerm;
        public static ConfigEntry<float> zCordTerm;

        public static ConfigEntry<float> xRotTerm;
        public static ConfigEntry<float> yRotTerm;
        public static ConfigEntry<float> zRotTerm;

        //Custom Coil Coords
        public static ConfigEntry<bool> moveCoil;
        public static ConfigEntry<float> xCordCoil;
        public static ConfigEntry<float> yCordCoil;
        public static ConfigEntry<float> zCordCoil;

        public static ConfigEntry<float> xRotCoil;
        public static ConfigEntry<float> yRotCoil;
        public static ConfigEntry<float> zRotCoil;

        //Store Items
        public static ConfigEntry<bool> deleteTeleporterCord;
        public static ConfigEntry<bool> moveTeleButtonsToDesk;

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
            //Custom Terminal Coords

            terminalReposition = cfg.Bind(
               terminalmove,
               "Automatic Terminal Reposition",
               false,
               "Sets the terminal to the left of the monitors by default."
           );
            var terminalRepositionToggle = new BoolCheckBoxConfigItem(terminalReposition, requiresRestart: false);
            LethalConfigManager.AddConfigItem(terminalRepositionToggle);

            customTerminal= cfg.Bind(
             terminalmove,
             "Custom Terminal Coordinates",
             false,
             "Allows the custom coordinates to be set. [CAUTION] Having this enabled disables the native ship furniture moving feature. You can enable/disable this in real-time in the pause menu."
         ); var termCustomMoveToggle = new BoolCheckBoxConfigItem(customTerminal, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termCustomMoveToggle);

            xCordTerm = cfg.Bind(
             terminalmove,
             "X-Coordinate",
             6.1759f,
             "Sets X-coordinate of Terminal"
         );
            var termX = new FloatInputFieldConfigItem(xCordTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termX);

            yCordTerm = cfg.Bind(
             terminalmove,
             "Y-Coordinate",
             1.2561f,
             "Sets Y-coordinate of Terminal"
         );
            var termY = new FloatInputFieldConfigItem(yCordTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termY);

            zCordTerm = cfg.Bind(
             terminalmove,
             "Z-Coordinate",
             -9.1415f,
             "Sets Z-coordinate of Terminal"
         );
            var termZ = new FloatInputFieldConfigItem(zCordTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termZ);

            xRotTerm = cfg.Bind(
             terminalmove,
             "X-Rotation",
             270f,
             "Sets X-Rotation of Terminal"
         );
            var termRotX = new FloatInputFieldConfigItem(xRotTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termRotX);

            yRotTerm = cfg.Bind(
             terminalmove,
             "Y-Rotation",
             90f,
             "Sets Y-Rotation of Terminal"
         );
            var termRotY = new FloatInputFieldConfigItem(yRotTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termRotY);

            zRotTerm = cfg.Bind(
             terminalmove,
             "Z-Rotation",
             0f,
             "Sets Z-Rotation of Terminal"
         );
            var termRotZ = new FloatInputFieldConfigItem(zRotTerm, requiresRestart: false);
            LethalConfigManager.AddConfigItem(termRotZ);



            //Custom Coil Coords

            moveCoil = cfg.Bind(
             chargingcoil,
             "Move Coil",
             false,
             "Allows the custom coordinates to be set"
         ); var coilMoveToggle = new BoolCheckBoxConfigItem(moveCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(coilMoveToggle);

            xCordCoil = cfg.Bind(
             chargingcoil,
             "X-Coordinate",
             -0.343f,
             "Sets X-coordinate of Charging Coil"
         );
            var coilX = new FloatInputFieldConfigItem(xCordCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(coilX);

            yCordCoil = cfg.Bind(
             chargingcoil,
             "Y-Coordinate",
             1.2561f,
             "Sets Y-coordinate of Charging Coil"
         );
            var coilY = new FloatInputFieldConfigItem(yCordCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(coilY);

            zCordCoil = cfg.Bind(
             chargingcoil,
             "Z-Coordinate",
             -4.802f,
             "Sets Z-coordinate of Charging Coil"
         );
            var coilZ = new FloatInputFieldConfigItem(zCordCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(coilZ);

            xRotCoil = cfg.Bind(
             chargingcoil,
             "X-Rotation",
             270f,
             "Sets X-Rotation of Charging Coil"
         );
            var rotX = new FloatInputFieldConfigItem(xRotCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(rotX);

            yRotCoil = cfg.Bind(
             chargingcoil,
             "Y-Rotation",
             0.0009f,
             "Sets Y-Rotation of Charging Coil"
         );
            var rotY = new FloatInputFieldConfigItem(yRotCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(rotY);

            zRotCoil = cfg.Bind(
             chargingcoil,
             "Z-Rotation",
             0f,
             "Sets Z-Rotation of Charging Coil"
         );
            var rotZ = new FloatInputFieldConfigItem(zRotCoil, requiresRestart: false);
            LethalConfigManager.AddConfigItem(rotZ);




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

            moveTeleButtonsToDesk = cfg.Bind(
             storeItems,
             "Teleporter Buttons",
             false,
             "Moves the teleporter buttons to the desk"
         );
            var teleButtonsToggle = new BoolCheckBoxConfigItem(moveTeleButtonsToDesk, requiresRestart: false);
            LethalConfigManager.AddConfigItem(teleButtonsToggle);
        }
    }
}