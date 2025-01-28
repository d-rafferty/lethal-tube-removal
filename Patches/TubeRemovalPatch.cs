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
        
        //Desk
        var mainDesk = GameObject.Find("Environment/HangarShip/ControlDesk");
        var rightDesk = GameObject.Find("Environment/HangarShip/ControlDesk.001");
        var controlPanel = GameObject.Find("Environment/HangarShip/ControlPanelWTexture");
        

        if(deleteIndoorCam.Value == true) shipCamera.SetActive(false); 

        if(deleteOutdoorCam.Value == true) doorCamera.SetActive(false);

        if(muteAudio.Value == true) speakerAudio.SetActive(false);


        if (removalMode.Value == RemovalMode.Deletion)
        {
            //checks config file for boolean value and if true deletes the item
            
            if (deleteDesks.Value == true)
            {
                Object.Destroy(mainDesk);
                Object.Destroy(rightDesk);
            }

            if (deleteControlPanel.Value == true) Object.Destroy(controlPanel);

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
                //Object.Destroy(doorCamera);
                //Object.Destroy(shipCamera);
            }
        }
        else if(removalMode.Value == RemovalMode.Inactive)
        {
            //checks config file for boolean value and if true deletes the item
            
            if (deleteDesks.Value)
            {
                mainDesk.SetActive(false);
                rightDesk.SetActive(false);
            } 
        
            if(deleteControlPanel.Value) controlPanel.SetActive(false);  

            if (deleteTube.Value)
            {
                tube.gameObject.SetActive(false);
            }

            if (deleteBunkbeds.Value)
            {
                beds.gameObject.SetActive(false);
            }

            if (deleteFileCabinets.Value)
            {
                cabinet.gameObject.SetActive(false);
            }

            if (deleteOxygenTank.Value)
            {
                tank.gameObject.SetActive(false);
            }

            if (deleteShelf.Value)
            {
                shelf.gameObject.SetActive(false);   
            }

            if (deleteClipboard.Value)
            {
                Object.Destroy(clipboard);
            }

            if (deleteDoorGenerator.Value)
            {
                doorGenerator.gameObject.SetActive(false);
            }

            if (deleteBoots.Value)
            {
                boots.gameObject.SetActive(false);
            }

            if (deleteMask.Value)
            {
                mask.gameObject.SetActive(false);
            }

            if (deleteAirFilter.Value)
            {
                airFilter.gameObject.SetActive(false);
            }

            if (deleteStickyNote.Value)
            {
                stickyNote.gameObject.SetActive(false);
            }

            if (deleteBatteries.Value)
            {
                battery.gameObject.SetActive(false);

                battery1.gameObject.SetActive(false);

                battery2.gameObject.SetActive(false);

                batteryPack.gameObject.SetActive(false);
            }

            if (deleteVent.Value)
            {
                vent.gameObject.SetActive(false);
            }

            if (deleteMonitorCords.Value)
            {
                monitorCords.gameObject.SetActive(false);
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
            }

            if (deletePosters.Value)
            {
                posters.gameObject.SetActive(false);
            }

            if (deleteClothingRack.Value)
            {
                suitParent.gameObject.SetActive(false);

                clothingRack.gameObject.SetActive(false);

                suitHook.gameObject.SetActive(false);

                suit.gameObject.SetActive(false);
            }

            if (deleteDoorTubes.Value)
            {
                doorTubes.gameObject.SetActive(false);
            }

            if (deleteKeyboardCord.Value)
            {
                keyboardCord.gameObject.SetActive(false);
            }

            if (lowLightMode.Value)
            {
                areaLight1.gameObject.SetActive(false);

                areaLight2.gameObject.SetActive(false);

                areaLight3.gameObject.SetActive(false);

                hangingLamp1.gameObject.SetActive(false);

                hangingLamp3.gameObject.SetActive(false);
            }

            if (deleteDoorMonitor.Value)
            {
                doorMonitor.gameObject.SetActive(false);

            }
        }
        else
        {
            if (deleteDesks.Value)
            {
                mainDesk.GetComponent<MeshRenderer>().enabled = false;
                rightDesk.GetComponent<MeshRenderer>().enabled = false;
            } 
        
            if(deleteControlPanel.Value) controlPanel.GetComponent<MeshRenderer>().enabled = false;
            
            
            if (deleteTube.Value)
            {
                tube.GetComponent<MeshRenderer>().enabled = false;
            }

            if (deleteBunkbeds.Value)
            {
                beds.GetComponent<MeshRenderer>().enabled = false;

                foreach (var collider in beds.GetComponentsInChildren<BoxCollider>()){
                    collider.enabled = false;
                }

            }

            if (deleteFileCabinets.Value)
            {
                cabinet.GetComponent<MeshRenderer>().enabled = false;
                cabinet.GetComponent<BoxCollider>().enabled = false;
            }

            if (deleteOxygenTank.Value)
            {
                tank.GetComponent<MeshRenderer>().enabled = false;
            }

            if (deleteShelf.Value)
            {
                //TODO: Children of the door objects are current set inactive because box colliders will not disable

                var rend = shelf.GetComponent<MeshRenderer>();
                rend.enabled = false;
                shelf.GetComponent<MeshCollider>().enabled = false;

                var door1 = GameObject.Find("Environment/HangarShip/StorageCloset/Cube.000");
                var door1Child = GameObject.Find("Environment/HangarShip/StorageCloset/Cube.000/Cube");
                door1.GetComponent<MeshRenderer>().enabled = false;
                door1.GetComponentInChildren<InteractTrigger>().enabled = false;
                door1Child.GetComponent<BoxCollider>().enabled = false;
                foreach (var collider in door1.GetComponentsInChildren<BoxCollider>())
                {
                    collider.enabled = false;
                }
                door1Child.SetActive(false);

                var door2 = GameObject.Find("Environment/HangarShip/StorageCloset/Cube.002");
                var door2Child = GameObject.Find("Environment/HangarShip/StorageCloset/Cube.002/Cube");
                door2.GetComponent<MeshRenderer>().enabled = false;
                door2.GetComponentInChildren<InteractTrigger>().enabled = false;
                door2Child.GetComponent<BoxCollider>().enabled = false;
                foreach (var collider in door2.GetComponentsInChildren<BoxCollider>())
                {
                    collider.enabled = false;
                }
                door2Child.SetActive(false);

                var placementpositions = GameObject.Find("Environment/HangarShip/StorageCloset/ObjectPlacements");
                foreach (var collider in placementpositions.GetComponentsInChildren<BoxCollider>())
                {
                    collider.enabled = false;
                }

                foreach (var trigger in placementpositions.GetComponentsInChildren<InteractTrigger>())
                {
                    trigger.enabled = false;
                }
            }
        }

        if (deleteClipboard.Value)
        {
            clipboard.SetActive(false);

        }

        if (deleteDoorGenerator.Value)
        {
            doorGenerator.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteBoots.Value)
        {
            boots.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteMask.Value)
        {
            mask.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteAirFilter.Value)
        {
            airFilter.GetComponent<MeshRenderer>().enabled = false;
            airFilter.GetComponent<MeshCollider>().enabled = false;
        }

        if (deleteStickyNote.Value)
        {
            stickyNote.GetComponent<MeshRenderer>().enabled = false;
            stickyNote.GetComponent<BoxCollider>().enabled = false;
        }

        if (deleteBatteries.Value)
        {
            battery.GetComponent<MeshRenderer>().enabled = false;

            battery1.GetComponent<MeshRenderer>().enabled = false;

            battery2.GetComponent<MeshRenderer>().enabled = false;

            batteryPack.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteVent.Value)
        {
            vent.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteMonitorCords.Value)
        {
            monitorCords.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteDoorSpeaker.Value)
        {
            doorSpeaker.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteMainSpeaker.Value)
        {
            mainSpeaker.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deletePosters.Value)
        {
            posters.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteClothingRack.Value)
        {
            //suitParent.SetActive(false);
            suitParent.GetComponent<InteractTrigger>().enabled = false;
            suitParent.GetComponent<BoxCollider>().enabled = false;

            clothingRack.GetComponent<MeshRenderer>().enabled = false;

            suitHook.GetComponent<MeshRenderer>().enabled = false;

            suit.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }

        if (deleteDoorTubes.Value)
        {
            doorTubes.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteKeyboardCord.Value)
        {
            keyboardCord.GetComponent<MeshRenderer>().enabled = false;
        }

        if (lowLightMode.Value)
        {
            areaLight1.GetComponent<MeshRenderer>().enabled = false;

            areaLight2.GetComponent<MeshRenderer>().enabled = false;

            areaLight3.GetComponent<MeshRenderer>().enabled = false;

            hangingLamp1.GetComponent<MeshRenderer>().enabled = false;

            hangingLamp3.GetComponent<MeshRenderer>().enabled = false;
        }

        if (deleteDoorMonitor.Value)
        {
            doorMonitor.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }
    
    
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")]
    public static void LeverCustomCoords()
    {
        //for custom ship lever coordinates
        if (moveLever.Value)
        {
            //Ship Lever
            var leverModel = GameObject.Find("Environment/HangarShip/HangarDoorLever");
            var leverInteractable = GameObject.Find("Environment/HangarShip/StartGameLever");
            
            //Lever model and interactable should be the same coordinates so they act as one entity
            var leverPos = new Vector3(xCordLever.Value, yCordLever.Value, zCordLever.Value);
            var leverLocalRotation = new Vector3(xRotLever.Value, yRotLever.Value, zRotLever.Value);

            leverModel.transform.localPosition = leverPos;
            leverModel.transform.position = leverPos;
            
            //leverModel.transform.eulerAngles = leverLocalRotation;
            leverInteractable.transform.localPosition = leverPos;
            leverInteractable.transform.position = leverPos;
            leverInteractable.transform.eulerAngles = leverLocalRotation;
            
            //Keeps ship lever from flying off when ship begins to move
            leverModel.AddComponent<AutoParentToShip>();
            leverInteractable.AddComponent<AutoParentToShip>();
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
            longCord.GetComponent<MeshRenderer>().enabled = false;
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

        /*if (moveLever.Value)
        {
            var leverModel = GameObject.Find("Environment/HangarShip/HangarDoorLever");
            var leverInteractable = GameObject.Find("Environment/HangarShip/StartGameLever");
            
            leverModel.AddComponent<AutoParentToShip>();
            leverInteractable.AddComponent<AutoParentToShip>();
        }*/
        
        
        
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

    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Update")]
    static void BedMove()
    {
        if (moveBed.Value && GameObject.Find("Environment/HangarShip/Bunkbeds"))
        {
            var bed = GameObject.Find("Environment/HangarShip/Bunkbeds");
            var BedObj = bed.GetComponent<AutoParentToShip>();
            var bedLocalPos = new Vector3(xCordBed.Value, yCordBed.Value, zCordBed.Value);
            var bedLocalRotation = new Vector3(xRotBed.Value, yRotBed.Value, zRotBed.Value);

            BedObj.positionOffset = bedLocalPos;
            BedObj.rotationOffset = bedLocalRotation;
        }
    }
}