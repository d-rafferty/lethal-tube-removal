using HarmonyLib;
using System;
using UnityEngine;
using static LethalTubeRemoval.Config;
using Object = UnityEngine.Object;

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
        var shelf = GameObject.Find("Environment/HangarShip/StorageCloset");

        var clipboard = GameObject.Find("Environment/HangarShip/ClipboardManual");
        var doorGenerator = GameObject.Find("Environment/HangarShip/DoorGenerator");
        var boots = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.004");
        var mask = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.001");
        var airFilter = GameObject.Find("Environment/HangarShip/ShipModels2b/AirFilterThing");
        var stickyNote = GameObject.Find("Environment/HangarShip/StickyNoteItem");
        var vent = GameObject.Find("Environment/HangarShip/VentEntrance/Hinge/VentCover");

        var battery = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle");
        var battery1 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (1)");
        var battery2 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (2)");
        var batteryPack = GameObject.Find("Environment/HangarShip/SmallDetails/BatteryPack");

        var monitorCords = GameObject.Find("Environment/HangarShip/WallCords");
        var doorSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (1)");
        var posters = GameObject.Find("Environment/HangarShip/Plane.001");
        var clothingHook = GameObject.Find("Environment/HangarShip/NurbsPath.004");
        var clothingRack = GameObject.Find("Environment/HangarShip/NurbsPath.002");
        var defaultSuit = GameObject.Find("ChangableSuit(Clone)");
        var doorTubes = GameObject.Find("Environment/HangarShip/NurbsPath");
        var keyboardCord = GameObject.Find("Environment/HangarShip/Terminal/BezierCurve.001");

        var mainSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)");
        var speakerAudio = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)/SpeakerAudio");
        var doorMonitor = GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen");
        var doorCamera = GameObject.Find("Environment/HangarShip/Cameras/FrontDoorSecurityCam");
        var shipCamera = GameObject.Find("Environment/HangarShip/Cameras/ShipCamera");


        //Lights
        var areaLight1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (3)");
        var areaLight2 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (4)");
        var areaLight3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (5)");
        var hangingLamp1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (2)");
        var hangingLamp3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (4)");

        //Suit Renderer Paths
        var suitParent = GameObject.Find("ChangableSuit(Clone)");
        var suit = GameObject.Find("ChangableSuit(Clone)/SuitRenderer");
        var suitHook = GameObject.Find("ChangableSuit(Clone)/SuitHook");

        if(deleteIndoorCam.Value == true) shipCamera.SetActive(false); 

        if(deleteOutdoorCam.Value == true) doorCamera.SetActive(false);


        if (removalMode.Value == true)
        {
            //checks config file for boolean value and if true deletes the item

            if (deleteTube.Value) Object.Destroy(tube);

            if (deleteBunkbeds.Value) Object.Destroy(beds);

            if (deleteFileCabinets.Value) Object.Destroy(cabinet);

            if (deleteOxygenTank.Value) Object.Destroy(tank);

            if (deleteShelf.Value) Object.Destroy(shelf);

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

            if (deleteDoorSpeaker.Value)
            {
                //door speaker was causing unity warning spam in v50 so moving it instead of deleting only causes warning on ship takeoff/land
                var localSpeakerPos =
                    new Vector3(11.4571f, 1.9706f,
                        -16.9578f); //hides the speaker in the front of the ship in the wall behind the monitors
                doorSpeaker.transform.position = localSpeakerPos;
            }


            if (deleteMainSpeaker.Value)
            {
                //ship speaker being instantiated is somehow tied to the ship door manual controls
                //to work around this I hid the speaker inside the ship wall and disabled the audio
                var localSpeakerPos =
                    new Vector3(11.4571f, 1.9706f,
                        -16.9578f); //hides the speaker in the front of the ship in the wall behind the monitors
                mainSpeaker.transform.position = localSpeakerPos;
                //Object.Destroy(speakerAudio); //disables the audio from the speaker
                speakerAudio.SetActive(false);
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

            if (deleteDoorMonitor.Value)
            {
                Object.Destroy(doorMonitor);
                Object.Destroy(doorCamera);
                //Object.Destroy(shipCamera);
            }
        }
        else
        {
            //checks config file for boolean value and if true deletes the item

            if (deleteTube.Value)
            {
                //List<Component> tubeCmp = new List<Component>();
                //tubeCmp = tube.GetComponents();

                var rend = tube.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteBunkbeds.Value)
            {
                var rend = beds.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteFileCabinets.Value)
            {
                var rend = cabinet.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteOxygenTank.Value)
            {
                var rend = tank.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteShelf.Value)
            {
                var rend = shelf.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteClipboard.Value)
            {
                Object.Destroy(clipboard);
            }

            if (deleteDoorGenerator.Value)
            {
                var rend = doorGenerator.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteBoots.Value)
            {
                var rend = boots.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteMask.Value)
            {
                var rend = mask.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteAirFilter.Value)
            {
                var rend = airFilter.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteStickyNote.Value)
            {
                var rend = stickyNote.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteBatteries.Value)
            {
                var rend = battery.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);

                var rend1 = battery1.GetComponent<MeshRenderer>();
                rend1.gameObject.SetActive(false);

                var rend2 = battery2.GetComponent<MeshRenderer>();
                rend2.gameObject.SetActive(false);

                var rend3 = batteryPack.GetComponent<MeshRenderer>();
                rend3.gameObject.SetActive(false);
            }

            if (deleteVent.Value)
            {
                var rend = vent.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteMonitorCords.Value)
            {
                var rend = monitorCords.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteDoorSpeaker.Value)
            {
                //door speaker was causing unity warning spam in v50 so moving it instead of deleting only causes warning on ship takeoff/land
                var localSpeakerPos =
                    new Vector3(11.4571f, 1.9706f,
                        -16.9578f); //hides the speaker in the front of the ship in the wall behind the monitors
                doorSpeaker.transform.position = localSpeakerPos;
            }


            if (deleteMainSpeaker.Value)
            {
                //ship speaker being instantiated is somehow tied to the ship door manual controls
                //to work around this I hid the speaker inside the ship wall and disabled the audio
                var localSpeakerPos =
                    new Vector3(11.4571f, 1.9706f,
                        -16.9578f); //hides the speaker in the front of the ship in the wall behind the monitors
                mainSpeaker.transform.position = localSpeakerPos;
                //Object.Destroy(speakerAudio); //disables the audio from the speaker
                speakerAudio.SetActive(false);
            }

            if (deletePosters.Value)
            {
                var rend = posters.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteClothingRack.Value)
            {
                var interactButton = suitParent.GetComponent<InteractTrigger>();
                interactButton.gameObject.SetActive(false);

                var rendRack = clothingRack.GetComponent<MeshRenderer>();
                rendRack.gameObject.SetActive(false);

                var rendHook = suitHook.GetComponent<MeshRenderer>();
                rendHook.gameObject.SetActive(false);

                var rendSuit = suit.GetComponent<SkinnedMeshRenderer>();
                rendSuit.gameObject.SetActive(false);
            }

            if (deleteDoorTubes.Value)
            {
                var rend = doorTubes.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (deleteKeyboardCord.Value)
            {
                var rend = keyboardCord.GetComponent<MeshRenderer>();
                rend.gameObject.SetActive(false);
            }

            if (lowLightMode.Value)
            {
                var rendLight1 = areaLight1.GetComponent<MeshRenderer>();
                rendLight1.gameObject.SetActive(false);

                var rendLight2 = areaLight2.GetComponent<MeshRenderer>();
                rendLight2.gameObject.SetActive(false);

                var rendLight3 = areaLight3.GetComponent<MeshRenderer>();
                rendLight3.gameObject.SetActive(false);

                var rendLamp1 = hangingLamp1.GetComponent<MeshRenderer>();
                rendLamp1.gameObject.SetActive(false);

                var rendLamp2 = hangingLamp3.GetComponent<MeshRenderer>();
                rendLamp2.gameObject.SetActive(false);
            }

            if (deleteDoorMonitor.Value)
            {
                var rendDoorMoni = doorMonitor.GetComponent<MeshRenderer>();
                rendDoorMoni.gameObject.SetActive(false);
            }
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
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    public static void VentCustomCoords()
    {
        //for custom charging coil coordinates
        if (moveVent.Value && !deleteVent.Value)
        {
            var vent = GameObject.Find("Environment/HangarShip/VentEntrance/Hinge");
            var ventLocalPos = new Vector3(xCordVent.Value, yCordVent.Value, zCordVent.Value);
            var ventLocalRotation = new Vector3(xRotVent.Value, yRotVent.Value, zRotVent.Value);

            vent.transform.localPosition = ventLocalPos;
            vent.transform.eulerAngles = ventLocalRotation;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    public static void TankCustomCoords()
    {
        //for custom charging coil coordinates
        if (moveTank.Value && !deleteOxygenTank.Value)
        {
            var tank = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.002");
            var tankLocalPos = new Vector3(xCordTank.Value, yCordTank.Value, zCordTank.Value);
            var tankLocalRotation = new Vector3(xRotTank.Value, yRotTank.Value, zRotTank.Value);

            tank.transform.localPosition = tankLocalPos;
            tank.transform.eulerAngles = tankLocalRotation;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    public static void FilterCustomCoords()
    {
        //for custom charging coil coordinates
        if (moveFilter.Value && !deleteAirFilter.Value)
        {
            var airFilter = GameObject.Find("Environment/HangarShip/ShipModels2b/AirFilterThing");
            var filterLocalPos = new Vector3(xCordFilter.Value, yCordFilter.Value, zCordFilter.Value);
            var filterLocalRotation = new Vector3(xRotFilter.Value, yRotFilter.Value, zRotFilter.Value);

            airFilter.transform.localPosition = filterLocalPos;
            airFilter.transform.eulerAngles = filterLocalRotation;
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
        if (deleteTeleporterCord.Value && GameObject.Find("Teleporter(Clone)/ButtonContainer/LongCord"))
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
                if (moveTeleButtonsToDesk.Value && GameObject.Find("Teleporter(Clone)/ButtonContainer"))
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
                if (moveTeleButtonsToDesk.Value && GameObject.Find("InverseTeleporter(Clone)/ButtonContainer"))
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

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    static void StoreageCabinetMove()
    {
        if (moveStorage.Value && GameObject.Find("Environment/HangarShip/StorageCloset"))
        {

            var shelf = GameObject.Find("Environment/HangarShip/StorageCloset");
            var Shelf = shelf.GetComponent<AutoParentToShip>();
            var shelfLocalPos = new Vector3(xCordStorage.Value, yCordStorage.Value, zCordStorage.Value);
            var shelfLocalRotation = new Vector3(xRotStorage.Value, yRotStorage.Value, zRotStorage.Value);

            Shelf.positionOffset = shelfLocalPos;
            Shelf.rotationOffset = shelfLocalRotation;

        }
    }

    //Adds autoparent component to objects that do not have it
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    static void AutoParentAdd()
    {
        //Door Monitor
        if (GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen"))
        {
            var doorMonitor = GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen");
            doorMonitor.AddComponent<AutoParentToShip>();
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    static void DoorMonitorMove()
    {
        if (moveMonitor.Value && GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen"))
        {
            var doorMonitor = GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen");
            var Monitor = doorMonitor.GetComponent<AutoParentToShip>();

            var doorMonitorLocalPos = new Vector3(xCordMonitor.Value, yCordMonitor.Value, zCordMonitor.Value);
            var doorMonitorLocalRotation = new Vector3(xRotMonitor.Value, yRotMonitor.Value, zRotMonitor.Value);

            Monitor.positionOffset = doorMonitorLocalPos;
            Monitor.rotationOffset = doorMonitorLocalRotation;
        }
    }

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    static void DoorButtonsMove()
    {
        if (moveButtons.Value && GameObject.Find("Environment/HangarShip/ShipModels2b/MonitorWall/SingleScreen"))
        {
            var doorButtons = GameObject.Find("Environment/HangarShip/AnimatedShipDoor/HangarDoorButtonPanel");

            var doorButtonsLocalPos = new Vector3(xCordButtons.Value, yCordButtons.Value, zCordButtons.Value);
            var doorButtonsLocalRotation = new Vector3(xRotButtons.Value, yRotButtons.Value, zRotButtons.Value);

            doorButtons.transform.localPosition = doorButtonsLocalPos;
            doorButtons.transform.eulerAngles = doorButtonsLocalRotation;
        }
    }
}