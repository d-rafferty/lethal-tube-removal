using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;
using static LethalTubeRemoval.Config;

namespace LethalTubeRemoval.Patches;

[HarmonyPatch(typeof(GameObject))]
internal class TubeRemovalPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")] //runs the patch each time the round is started
    public static void TubeRemove()
    {
        var tube = GameObject.Find("Environment/HangarShip/BezierCurve"); //sets each ship item path as a GameObject
        var beds = GameObject.Find("Environment/HangarShip/Bunkbeds");
        var cabinet = GameObject.Find("Environment/HangarShip/FileCabinet");
        var tank = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.002");

        var clipboard = GameObject.Find("Environment/HangarShip/ClipboardManual");
        var doorGenerator = GameObject.Find("Environment/HangarShip/DoorGenerator");
        var boots = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.004");
        var mask = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.001");
        var airFilter = GameObject.Find("Environment/HangarShip/ShipModels2b/AirFilterThing");
        var stickyNote = GameObject.Find("Environment/HangarShip/StickyNoteItem");
        var vent = GameObject.Find("Environment/HangarShip/VentEntrance/Hinge");

        var battery = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle");
        var battery1 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (1)");
        var battery2 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (2)");
        var batteryPack = GameObject.Find("Environment/HangarShip/SmallDetails/BatteryPack");

        var monitorCords = GameObject.Find("Environment/HangarShip/WallCords");
        var doorSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (1)");
        var posters = GameObject.Find("Environment/HangarShip/Plane.001");
        var clothingRack = GameObject.Find("Environment/HangarShip/NurbsPath.004");
        var clothingHook = GameObject.Find("Environment/HangarShip/NurbsPath.002");
        var defaultSuit = GameObject.Find("ChangableSuit(Clone)");
        var doorTubes = GameObject.Find("Environment/HangarShip/NurbsPath");
        var keyboardCord = GameObject.Find("Environment/HangarShip/Terminal/BezierCurve.001");

        var mainSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)");
        var speakerAudio = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)/SpeakerAudio");


        //Lights
        var areaLight1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (3)");
        var areaLight2 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (4)");
        var areaLight3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (5)");
        var hangingLamp1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (2)");
        var hangingLamp3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (4)");

        //Store Items


        if (deleteTube.Value) //checks config file for boolean value and if true deletes the item
            Object.Destroy(tube);

        if (deleteBunkbeds.Value) Object.Destroy(beds);

        if (deleteFileCabinets.Value) Object.Destroy(cabinet);

        if (deleteOxygenTank.Value) Object.Destroy(tank);

        if (deleteClipboard.Value) Object.Destroy(clipboard);

        if (deleteDoorGenerator.Value) Object.Destroy(doorGenerator);

        if (deleteBoots.Value) Object.Destroy(boots);

        if (deleteMask.Value) Object.Destroy(mask);

        if (deleteAirFilter.Value) Object.Destroy(airFilter);

        if (deleteStickyNote.Value) Object.Destroy(stickyNote);

        if (deleteBatteries.Value)
        {
            Object.Destroy(battery);
            Object.Destroy(battery1);
            Object.Destroy(battery2);
            Object.Destroy(batteryPack);
        }

        if (deleteVent.Value) Object.Destroy(vent);

        if (deleteMonitorCords.Value) Object.Destroy(monitorCords);

        if (deleteDoorSpeaker.Value) Object.Destroy(doorSpeaker);

        if (deleteMainSpeaker.Value)
        {
            //ship speaker being instantiated is somehow tied to the ship door manual controls
            //to work around this I hid the speaker inside the ship wall and disabled the audio
            var localSpeakerPos =
                new Vector3(11.4571f, 1.9706f,
                    -16.9578f); //hides the speaker in the front of the ship in the wall behind the monitors
            mainSpeaker.transform.position = localSpeakerPos;
            Object.Destroy(speakerAudio); //disables the audio from the speaker
        }

        if (deletePosters.Value) Object.Destroy(posters);

        if (deleteClothingRack.Value)
        {
            Object.Destroy(clothingRack);
            Object.Destroy(clothingHook);
            Object.Destroy(defaultSuit);
        }

        if (deleteDoorTubes.Value) Object.Destroy(doorTubes);

        if (deleteKeyboardCord.Value) Object.Destroy(keyboardCord);

        if (lowLightMode.Value)
        {
            Object.Destroy(areaLight1);
            Object.Destroy(areaLight2);
            Object.Destroy(areaLight3);
            Object.Destroy(hangingLamp1);
            Object.Destroy(hangingLamp3);
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    public static void CoilCustomCoords()
    {
        //for custom charging coil coordinates
        if (moveCoil.Value)
        {
            var chargingCoil = GameObject.Find("Environment/HangarShip/ShipModels2b/ChargeStation");
            var chargeLocalPos = new Vector3(xCordCoil.Value, yCordCoil.Value, zCordCoil.Value);
            var chargeLocalRotation = new Vector3(xRotCoil.Value, yRotCoil.Value, zRotCoil.Value);

            chargingCoil.transform.localPosition = chargeLocalPos;
            chargingCoil.transform.eulerAngles = chargeLocalRotation;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    public static void ClipboardCustomCoords()
    {
        //for custom charging coil coordinates
        if (moveClipboard.Value)
        {
            var clipboard = GameObject.Find("Environment/HangarShip/ClipboardManual");
            var clipPos = new Vector3(xCordClip.Value, yCordClip.Value, zCordClip.Value);
            var clipLocalRotation = new Vector3(xRotClip.Value, yRotClip.Value, zRotClip.Value);

            //gets this component and sets inactive because you cannot change position with it active
            var clippyitem = clipboard.GetComponent<ClipboardItem>();   
            clippyitem.enabled = false;
            clipboard.transform.position = clipPos;

            //re-enables to set rotation and for game functions
            clippyitem.enabled = true;                                  
            clipboard.transform.eulerAngles = clipLocalRotation;
        }
        
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipTeleporter), "Awake")]
    private static void TeleporterCord()
    {
        if (GameObject.Find("Teleporter(Clone)/ButtonContainer/LongCord"))
        {
            var longCord = GameObject.Find("Teleporter(Clone)/ButtonContainer/LongCord");
            longCord.SetActive(false);
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipTeleporter), "Awake")]
    public static void TeleporterButtons()
    {
        if (moveTeleButtonsToDesk.Value && GameObject.Find("Teleporter(Clone)/ButtonContainer"))
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(ShipTeleporter), "Update")]
            static void TeleporterStuff()
            {
                if (moveTeleButtonsToDesk.Value)
                {
                    var teleButton = GameObject.Find("Teleporter(Clone)/ButtonContainer");
                    var teleButtonGlobal = new Vector3(1.8872f, -1.4394f, -11.642f);
                    var teleButtonPosLocal = new Vector3(-1.1767f, -3.1688f, 2.2629f);


                    teleButton.transform.localRotation =
                        new Quaternion(0.1211f, -0.1197f, -0.0436f,
                            -0.9844f); //to get this quaternion, use UnityExplorer, find the buttoncontainer rotation vector you need
                    teleButton.transform.position = teleButtonGlobal;
                    teleButton.transform.localPosition = teleButtonPosLocal;
                }
            }
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(ShipTeleporter), "Awake")]
    public static void InverseTeleporterButtons()
    {
        if (moveTeleButtonsToDesk.Value && GameObject.Find("InverseTeleporter(Clone)/ButtonContainer"))
        {
            [HarmonyPostfix]
            [HarmonyPatch(typeof(ShipTeleporter), "Update")]
            static void InverseTeleporterStuff()
            {
                if (moveTeleButtonsToDesk.Value)
                {
                    var inverseTeleButton = GameObject.Find("InverseTeleporter(Clone)/ButtonContainer");

                    var inverseTeleButtonPosGlobal = new Vector3(1.21f, 0.74f, -14.12f);
                    var inverseTeleButtonPosLocal = new Vector3(0.2214f, 0.3496f, 0.3927f);
                    var teleButtonGlobal = new Vector3(1.8872f, -1.4394f, -11.642f);

                    inverseTeleButton.transform.localRotation = new Quaternion(0f, 0.0175f, 0f, 0.9998f);
                    inverseTeleButton.transform.position = inverseTeleButtonPosGlobal;
                    inverseTeleButton.transform.localPosition = inverseTeleButtonPosLocal;
                }
            }
        }
    }
}