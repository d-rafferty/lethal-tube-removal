using BepInEx.Configuration;
using LethalConfig;
using LethalConfig.ConfigItems;

namespace LethalTubeRemoval;

public class Config
{
    private const string terminalmove = "Terminal Reposition";

    private const string chargingcoil = "Charging Coil Reposition";

    private const string cliprepos = "Clipboard Reposition";

    private const string inside = "Inside Ship";

    private const string outside = "Outside Ship";

    private const string storeItems = "Store Items";

    private const string misc = "Misc Modes";

    //Custom Terminal Coords
    internal static ConfigEntry<bool> customTerminal;
    internal static ConfigEntry<float> xCordTerm;
    internal static ConfigEntry<float> yCordTerm;
    internal static ConfigEntry<float> zCordTerm;

    internal static ConfigEntry<float> xRotTerm;
    internal static ConfigEntry<float> yRotTerm;
    internal static ConfigEntry<float> zRotTerm;

    //Custom Coil Coords
    internal static ConfigEntry<bool> moveCoil;
    internal static ConfigEntry<float> xCordCoil;
    internal static ConfigEntry<float> yCordCoil;
    internal static ConfigEntry<float> zCordCoil;

    internal static ConfigEntry<float> xRotCoil;
    internal static ConfigEntry<float> yRotCoil;
    internal static ConfigEntry<float> zRotCoil;

    //Custom Clipboard Coords
    internal static ConfigEntry<bool> moveClipboard;
    internal static ConfigEntry<float> xCordClip;
    internal static ConfigEntry<float> yCordClip;
    internal static ConfigEntry<float> zCordClip;

    internal static ConfigEntry<float> xRotClip;
    internal static ConfigEntry<float> yRotClip;
    internal static ConfigEntry<float> zRotClip;


    //Store Items
    internal static ConfigEntry<bool> deleteTeleporterCord;
    internal static ConfigEntry<bool> moveTeleButtonsToDesk;

    //Inside Ship
    internal static ConfigEntry<bool> deleteTube; //initializes the config entry for each ship item, uses LethalConfig
    internal static ConfigEntry<bool> deleteBunkbeds;
    internal static ConfigEntry<bool> deleteFileCabinets;
    internal static ConfigEntry<bool> deleteOxygenTank;
    internal static ConfigEntry<bool> deleteClipboard;
    internal static ConfigEntry<bool> deleteDoorGenerator;
    internal static ConfigEntry<bool> deleteBoots;
    internal static ConfigEntry<bool> deleteMask;
    internal static ConfigEntry<bool> deleteAirFilter;
    internal static ConfigEntry<bool> deleteStickyNote;
    internal static ConfigEntry<bool> deleteBatteries;
    internal static ConfigEntry<bool> deleteVent;
    internal static ConfigEntry<bool> deleteMonitorCords;
    internal static ConfigEntry<bool> deleteDoorSpeaker;
    internal static ConfigEntry<bool> deleteMainSpeaker;
    internal static ConfigEntry<bool> deletePosters;
    internal static ConfigEntry<bool> deleteClothingRack;
    internal static ConfigEntry<bool> deleteDoorTubes;
    internal static ConfigEntry<bool> deleteKeyboardCord;
    internal static ConfigEntry<bool> terminalReposition;
    internal static ConfigEntry<bool> deleteShelf;
    internal static ConfigEntry<bool> deleteDoorMonitor;

    //Outside Ship
    internal static ConfigEntry<bool> deleteFloodLight;
    internal static ConfigEntry<bool> deleteOutsideTubing;
    internal static ConfigEntry<bool> deleteMachinery;
    internal static ConfigEntry<bool> deleteRailing;
    internal static ConfigEntry<bool> deleteThrusterTube;
    internal static ConfigEntry<bool> deleteThrusters;
    internal static ConfigEntry<bool> deleteSupportBeams;
    internal static ConfigEntry<bool> deleteWeirdBox;
    internal static ConfigEntry<bool> deleteLeftMachinery;

    //Misc
    internal static ConfigEntry<bool> parkourMode;
    internal static ConfigEntry<bool> lowLightMode;


    public Config(ConfigFile cfg)
    {
        //Custom Terminal Coords

        terminalReposition = cfg.Bind(
            terminalmove,
            "Automatic Terminal Reposition",
            false,
            "Sets the terminal to the left of the monitors by default."
        );
        var terminalRepositionToggle = new BoolCheckBoxConfigItem(terminalReposition, false);
        LethalConfigManager.AddConfigItem(terminalRepositionToggle);

        customTerminal = cfg.Bind(
            terminalmove,
            "Custom Terminal Coordinates",
            false,
            "Allows the custom coordinates to be set. [CAUTION] Having this enabled disables the native ship furniture moving feature. You can enable/disable this in real-time in the pause menu."
        );
        var termCustomMoveToggle = new BoolCheckBoxConfigItem(customTerminal, false);
        LethalConfigManager.AddConfigItem(termCustomMoveToggle);

        xCordTerm = cfg.Bind(
            terminalmove,
            "X-Coordinate",
            6.1759f,
            "Sets X-coordinate of Terminal"
        );
        var termX = new FloatInputFieldConfigItem(xCordTerm, false);
        LethalConfigManager.AddConfigItem(termX);

        yCordTerm = cfg.Bind(
            terminalmove,
            "Y-Coordinate",
            1.2561f,
            "Sets Y-coordinate of Terminal"
        );
        var termY = new FloatInputFieldConfigItem(yCordTerm, false);
        LethalConfigManager.AddConfigItem(termY);

        zCordTerm = cfg.Bind(
            terminalmove,
            "Z-Coordinate",
            -9.1415f,
            "Sets Z-coordinate of Terminal"
        );
        var termZ = new FloatInputFieldConfigItem(zCordTerm, false);
        LethalConfigManager.AddConfigItem(termZ);

        xRotTerm = cfg.Bind(
            terminalmove,
            "X-Rotation",
            270f,
            "Sets X-Rotation of Terminal"
        );
        var termRotX = new FloatInputFieldConfigItem(xRotTerm, false);
        LethalConfigManager.AddConfigItem(termRotX);

        yRotTerm = cfg.Bind(
            terminalmove,
            "Y-Rotation",
            90f,
            "Sets Y-Rotation of Terminal"
        );
        var termRotY = new FloatInputFieldConfigItem(yRotTerm, false);
        LethalConfigManager.AddConfigItem(termRotY);

        zRotTerm = cfg.Bind(
            terminalmove,
            "Z-Rotation",
            0f,
            "Sets Z-Rotation of Terminal"
        );
        var termRotZ = new FloatInputFieldConfigItem(zRotTerm, false);
        LethalConfigManager.AddConfigItem(termRotZ);


        //Custom Coil Coords

        moveCoil = cfg.Bind(
            chargingcoil,
            "Move Coil",
            false,
            "Allows the custom coordinates to be set"
        );
        var coilMoveToggle = new BoolCheckBoxConfigItem(moveCoil, false);
        LethalConfigManager.AddConfigItem(coilMoveToggle);

        xCordCoil = cfg.Bind(
            chargingcoil,
            "X-Coordinate",
            -0.343f,
            "Sets X-coordinate of Charging Coil"
        );
        var coilX = new FloatInputFieldConfigItem(xCordCoil, false);
        LethalConfigManager.AddConfigItem(coilX);

        yCordCoil = cfg.Bind(
            chargingcoil,
            "Y-Coordinate",
            1.2561f,
            "Sets Y-coordinate of Charging Coil"
        );
        var coilY = new FloatInputFieldConfigItem(yCordCoil, false);
        LethalConfigManager.AddConfigItem(coilY);

        zCordCoil = cfg.Bind(
            chargingcoil,
            "Z-Coordinate",
            -4.802f,
            "Sets Z-coordinate of Charging Coil"
        );
        var coilZ = new FloatInputFieldConfigItem(zCordCoil, false);
        LethalConfigManager.AddConfigItem(coilZ);

        xRotCoil = cfg.Bind(
            chargingcoil,
            "X-Rotation",
            270f,
            "Sets X-Rotation of Charging Coil"
        );
        var rotX = new FloatInputFieldConfigItem(xRotCoil, false);
        LethalConfigManager.AddConfigItem(rotX);

        yRotCoil = cfg.Bind(
            chargingcoil,
            "Y-Rotation",
            0.0009f,
            "Sets Y-Rotation of Charging Coil"
        );
        var rotY = new FloatInputFieldConfigItem(yRotCoil, false);
        LethalConfigManager.AddConfigItem(rotY);

        zRotCoil = cfg.Bind(
            chargingcoil,
            "Z-Rotation",
            0f,
            "Sets Z-Rotation of Charging Coil"
        );
        var rotZ = new FloatInputFieldConfigItem(zRotCoil, false);
        LethalConfigManager.AddConfigItem(rotZ);


        //MOVE CLIPBOARD
        moveClipboard = cfg.Bind(
            cliprepos,
            "Move Clipboard",
            false,
            "Allows the custom coordinates to be set"
        );
        var clipboardMoveToggle = new BoolCheckBoxConfigItem(moveClipboard, false);
        LethalConfigManager.AddConfigItem(clipboardMoveToggle);

        xCordClip = cfg.Bind(
            cliprepos,
            "X-Coordinate",
            9.6715f,
            "Sets X-coordinate of Clipboard"
        );
        var clipX = new FloatInputFieldConfigItem(xCordClip, false);
        LethalConfigManager.AddConfigItem(clipX);

        yCordClip = cfg.Bind(
            cliprepos,
            "Y-Coordinate",
            1.4404f,
            "Sets Y-coordinate of Clipboard"
        );
        var clipY = new FloatInputFieldConfigItem(yCordClip, false);
        LethalConfigManager.AddConfigItem(clipY);

        zCordClip = cfg.Bind(
            cliprepos,
            "Z-Coordinate",
            -13.505f,
            "Sets Z-coordinate of Clipboard"
        );
        var clipZ = new FloatInputFieldConfigItem(zCordClip, false);
        LethalConfigManager.AddConfigItem(clipZ);

        xRotClip = cfg.Bind(
            cliprepos,
            "X-Rotation",
            359.9378f,
            "Sets X-Rotation of Clipboard"
        );
        var clipRotX = new FloatInputFieldConfigItem(xRotClip, false);
        LethalConfigManager.AddConfigItem(clipRotX);

        yRotClip = cfg.Bind(
            cliprepos,
            "Y-Rotation",
           159.3217f,
            "Sets Y-Rotation of Clipboard"
        );
        var clipRotY = new FloatInputFieldConfigItem(yRotClip, false);
        LethalConfigManager.AddConfigItem(clipRotY);

        zRotClip = cfg.Bind(
            cliprepos,
            "Z-Rotation",
            180.0557f,
            "Sets Z-Rotation of Clipboard"
        );
        var clipRotZ = new FloatInputFieldConfigItem(zRotClip, false);
        LethalConfigManager.AddConfigItem(clipRotZ);


        //Inside Ship

        deleteTube = cfg.Bind( //sets initial LethalConfig values
            inside, //type of change
            "Tube", //Name in the UI
            true, //default value
            "Deletes the tube on the floor" //Description for UI
        );
        var tubeToggle =
            new BoolCheckBoxConfigItem(deleteTube,
                false); //sets as checkbox for bool, sets restart flag as false as these changes do not require a restart of the game
        LethalConfigManager.AddConfigItem(tubeToggle);

        deleteBunkbeds = cfg.Bind(
            inside,
            "BunkBeds",
            false,
            "Deletes the bunkbeds"
        );
        var bedToggle = new BoolCheckBoxConfigItem(deleteBunkbeds, false);
        LethalConfigManager.AddConfigItem(bedToggle);

        deleteFileCabinets = cfg.Bind(
            inside,
            "File Cabinets",
            false,
            "Deletes the file cabinets"
        );
        var fileCabinetsToggle = new BoolCheckBoxConfigItem(deleteFileCabinets, false);
        LethalConfigManager.AddConfigItem(fileCabinetsToggle);

        deleteOxygenTank = cfg.Bind(
            inside,
            "Oxygen Tank",
            false,
            "Deletes the oxygen tank"
        );
        var oxygenTankToggle = new BoolCheckBoxConfigItem(deleteOxygenTank, false);
        LethalConfigManager.AddConfigItem(oxygenTankToggle);

        deleteClipboard = cfg.Bind(
            inside,
            "Clipboard",
            false,
            "Deletes the clipboard"
        );
        var clipboardToggle = new BoolCheckBoxConfigItem(deleteClipboard, false);
        LethalConfigManager.AddConfigItem(clipboardToggle);

        deleteDoorGenerator = cfg.Bind(
            inside,
            "Door Generator",
            false,
            "Deletes the door generator"
        );
        var doorGeneratorToggle = new BoolCheckBoxConfigItem(deleteDoorGenerator, false);
        LethalConfigManager.AddConfigItem(doorGeneratorToggle);

        deleteBoots = cfg.Bind(
            inside,
            "Boots",
            false,
            "Deletes the boots under the clothing rack"
        );
        var bootsToggle = new BoolCheckBoxConfigItem(deleteBoots, false);
        LethalConfigManager.AddConfigItem(bootsToggle);

        deleteMask = cfg.Bind(
            inside,
            "Mask",
            false,
            "Deletes the mask on the control desk"
        );
        var maskToggle = new BoolCheckBoxConfigItem(deleteMask, false);
        LethalConfigManager.AddConfigItem(maskToggle);

        deleteAirFilter = cfg.Bind(
            inside,
            "Air Filter",
            false,
            "Deletes the air filter on the wall"
        );
        var airFilterToggle = new BoolCheckBoxConfigItem(deleteAirFilter, false);
        LethalConfigManager.AddConfigItem(airFilterToggle);

        deleteStickyNote = cfg.Bind(
            inside,
            "Sticky Note",
            false,
            "Deletes the sticky note"
        );
        var stickyNoteToggle = new BoolCheckBoxConfigItem(deleteStickyNote, false);
        LethalConfigManager.AddConfigItem(stickyNoteToggle);

        deleteBatteries = cfg.Bind(
            inside,
            "Batteries",
            false,
            "Deletes the batteries on control desk"
        );
        var batteryToggle = new BoolCheckBoxConfigItem(deleteBatteries, false);
        LethalConfigManager.AddConfigItem(batteryToggle);

        deleteVent = cfg.Bind(
            inside,
            "Vent",
            false,
            "Deletes the vent below the charging station"
        );
        var ventToggle = new BoolCheckBoxConfigItem(deleteVent, false);
        LethalConfigManager.AddConfigItem(ventToggle);

        deleteMonitorCords = cfg.Bind(
            inside,
            "Monitor Cords",
            false,
            "Deletes the cords behind the monitors"
        );
        var monitorCordsToggle = new BoolCheckBoxConfigItem(deleteMonitorCords, false);
        LethalConfigManager.AddConfigItem(monitorCordsToggle);

        deleteDoorSpeaker = cfg.Bind(
            inside,
            "Door Speaker",
            false,
            "Deletes the speaker near the ship door !!WARNING: If you are reading logs, this option will spam null audio warnings in v50."
        );
        var doorSpeakerToggle = new BoolCheckBoxConfigItem(deleteDoorSpeaker, false);
        LethalConfigManager.AddConfigItem(doorSpeakerToggle);

        deleteMainSpeaker = cfg.Bind(
            inside,
            "Main Speaker",
            false,
            "Deletes the main speaker that normally plays audio. WARNING: No ship-speaker audio will play if this is selected!"
        );
        var mainSpeakerToggle = new BoolCheckBoxConfigItem(deleteMainSpeaker, false);
        LethalConfigManager.AddConfigItem(mainSpeakerToggle);

        deletePosters = cfg.Bind(
            inside,
            "Posters",
            false,
            "Deletes the posters inside the ship"
        );
        var postersToggle = new BoolCheckBoxConfigItem(deletePosters, false);
        LethalConfigManager.AddConfigItem(postersToggle);

        deleteClothingRack = cfg.Bind(
            inside,
            "Clothing Rack",
            false,
            "Deletes the clothing rack. WARNING: Purchasable suits will not be able to be equipped if this is selected!"
        );
        var clothingRackToggle = new BoolCheckBoxConfigItem(deleteClothingRack, false);
        LethalConfigManager.AddConfigItem(clothingRackToggle);

        deleteDoorTubes = cfg.Bind(
            inside,
            "Door Tubes",
            false,
            "Deletes the tubes by the ship door."
        );
        var doorTubesToggle = new BoolCheckBoxConfigItem(deleteDoorTubes, false);
        LethalConfigManager.AddConfigItem(doorTubesToggle);

        deleteKeyboardCord = cfg.Bind(
            inside,
            "Keyboard Cord",
            true,
            "Deletes the cord coming out of the keyboard on the terminal"
        );
        var keyboardCordToggle = new BoolCheckBoxConfigItem(deleteKeyboardCord, false);
        LethalConfigManager.AddConfigItem(keyboardCordToggle);

        deleteShelf = cfg.Bind(
            inside,
            "Storage Shelf",
            false,
            "Deletes the storage shelf"
        );
        var shelfToggle = new BoolCheckBoxConfigItem(deleteShelf, false);
        LethalConfigManager.AddConfigItem(shelfToggle);

        deleteDoorMonitor = cfg.Bind(
            inside,
            "Door Monitor",
            false,
            "Deletes the monitor above the door buttons"
        );
        var doorMonitorToggle = new BoolCheckBoxConfigItem(deleteDoorMonitor, false);
        LethalConfigManager.AddConfigItem(doorMonitorToggle);


        // OUTSIDE SHIP
        deleteFloodLight = cfg.Bind(
            outside,
            "Floodlight",
            false,
            "Removes the floodlight outside the ship"
        );
        var deleteFloodlightToggle = new BoolCheckBoxConfigItem(deleteFloodLight, false);
        LethalConfigManager.AddConfigItem(deleteFloodlightToggle);

        deleteMachinery = cfg.Bind(
            outside,
            "Machinery Boxes",
            false,
            "Removes the machinery boxes on both sides of the ship"
        );
        var machineryToggle = new BoolCheckBoxConfigItem(deleteMachinery, false);
        LethalConfigManager.AddConfigItem(machineryToggle);

        deleteOutsideTubing = cfg.Bind(
            outside,
            "Tubing",
            false,
            "Removes the tubing outside the ship"
        );
        var outsideTubingToggle = new BoolCheckBoxConfigItem(deleteOutsideTubing, false);
        LethalConfigManager.AddConfigItem(outsideTubingToggle);

        deleteRailing = cfg.Bind(
            outside,
            "Railing",
            false,
            "Removes the railing outside the ship"
        );
        var railingToggle = new BoolCheckBoxConfigItem(deleteRailing, false);
        LethalConfigManager.AddConfigItem(railingToggle);

        deleteThrusterTube = cfg.Bind(
            outside,
            "Back Right Thruster Tube",
            false,
            "Removes the thruster tube in the back right. NOTE: Also deletes back right thruster"
        );
        var thrusterTubeToggle = new BoolCheckBoxConfigItem(deleteThrusterTube, false);
        LethalConfigManager.AddConfigItem(thrusterTubeToggle);

        deleteThrusters = cfg.Bind(
            outside,
            "All Thrusters",
            false,
            "Removes all thrusters."
        );
        var thrustersToggle = new BoolCheckBoxConfigItem(deleteThrusters, false);
        LethalConfigManager.AddConfigItem(thrustersToggle);

        deleteSupportBeams = cfg.Bind(
            outside,
            "Support Beams Under Ship",
            false,
            "Removes support beams."
        );
        var supportBeamsToggle = new BoolCheckBoxConfigItem(deleteSupportBeams, false);
        LethalConfigManager.AddConfigItem(thrustersToggle);

        deleteWeirdBox = cfg.Bind(
            outside,
            "Large Exhaust",
            false,
            "Removes large exhaust box near front of ship"
        );
        var weirdBoxToggle = new BoolCheckBoxConfigItem(deleteWeirdBox, false);
        LethalConfigManager.AddConfigItem(thrustersToggle);

        deleteLeftMachinery = cfg.Bind(
            outside,
            "Left Machinery",
            false,
            "Removes machinery and bottom tubing from left of ship"
        );
        var leftMachineryToggle = new BoolCheckBoxConfigItem(deleteLeftMachinery, false);
        LethalConfigManager.AddConfigItem(leftMachineryToggle);


        //MISC MODES
        parkourMode = cfg.Bind(
            misc,
            "Parkour Mode",
            false,
            "Only for the bravest Company Employees. Removes catwalk and ladders from the outside of the ship."
        );
        var parkourToggle = new BoolCheckBoxConfigItem(parkourMode, false);
        LethalConfigManager.AddConfigItem(parkourToggle);

        lowLightMode = cfg.Bind(
            misc,
            "Low Light Mode",
            false,
            "Removes some lights inside the ship"
        );
        var lightToggle = new BoolCheckBoxConfigItem(lowLightMode, false);
        LethalConfigManager.AddConfigItem(lightToggle);


        //Store Items
        deleteTeleporterCord = cfg.Bind(
            storeItems,
            "Teleporter Cord",
            false,
            "Removes the long cord from the teleporter"
        );
        var teleCordToggle = new BoolCheckBoxConfigItem(deleteTeleporterCord, false);
        LethalConfigManager.AddConfigItem(teleCordToggle);

        moveTeleButtonsToDesk = cfg.Bind(
            storeItems,
            "Teleporter Buttons",
            false,
            "Moves the teleporter buttons to the desk near the ship lever"
        );
        var teleButtonsToggle = new BoolCheckBoxConfigItem(moveTeleButtonsToDesk, false);
        LethalConfigManager.AddConfigItem(teleButtonsToggle);
    }
}