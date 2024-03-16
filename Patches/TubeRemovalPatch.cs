using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx;
using System.Runtime.CompilerServices;
using Object = UnityEngine.Object;
using static LethalTubeRemoval.TubeRemoval;
using static LethalTubeRemoval.Config;

namespace LethalTubeRemoval.Patches
{
    [HarmonyPatch(typeof(GameObject))]
    internal class TubeRemovalPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(StartOfRound), "Start")]           //runs the patch each time the round is started
        public static void TubeRemove()
        {
            GameObject tube = GameObject.Find("Environment/HangarShip/BezierCurve");        //sets each ship item path as a GameObject
            GameObject beds = GameObject.Find("Environment/HangarShip/Bunkbeds");
            GameObject cabinet = GameObject.Find("Environment/HangarShip/FileCabinet");
            GameObject tank = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.002");

            GameObject clipboard = GameObject.Find("Environment/HangarShip/ClipboardManual");
            GameObject doorGenerator = GameObject.Find("Environment/HangarShip/DoorGenerator");
            GameObject boots = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.004");
            GameObject mask = GameObject.Find("Environment/HangarShip/ScavengerModelSuitParts/Circle.001");
            GameObject airFilter = GameObject.Find("Environment/HangarShip/ShipModels2b/AirFilterThing");
            GameObject stickyNote = GameObject.Find("Environment/HangarShip/StickyNoteItem");
            GameObject vent = GameObject.Find("Environment/HangarShip/VentEntrance/Hinge");

            GameObject battery = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle");
            GameObject battery1 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (1)");
            GameObject battery2 = GameObject.Find("Environment/HangarShip/SmallDetails/BatterySingle (2)");
            GameObject batteryPack = GameObject.Find("Environment/HangarShip/SmallDetails/BatteryPack");

            GameObject monitorCords = GameObject.Find("Environment/HangarShip/WallCords");
            GameObject doorSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (1)");
            GameObject posters = GameObject.Find("Environment/HangarShip/Plane.001");
            GameObject clothingRack = GameObject.Find("Environment/HangarShip/NurbsPath.004");
            GameObject clothingHook= GameObject.Find("Environment/HangarShip/NurbsPath.002"); 
            GameObject defaultSuit = GameObject.Find("ChangableSuit(Clone)");
            GameObject doorTubes = GameObject.Find("Environment/HangarShip/NurbsPath");
            GameObject keyboardCord = GameObject.Find("Environment/HangarShip/Terminal/BezierCurve.001");

            GameObject mainSpeaker = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)");
            GameObject speakerAudio = GameObject.Find("Environment/HangarShip/ShipModels2b/Cube.005 (2)/SpeakerAudio");


            //Lights
            GameObject areaLight1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (3)");
            GameObject areaLight2 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (4)");
            GameObject areaLight3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/Area Light (5)");
            GameObject hangingLamp1 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (2)");
            GameObject hangingLamp3 = GameObject.Find("Environment/HangarShip/ShipElectricLights/HangingLamp (4)");

            //Store Items
            

            if (Config.deleteTube.Value)            //checks config file for boolean value and if true deletes the item
            {
                GameObject.Destroy(tube);
            }

            if (Config.deleteBunkbeds.Value)
            {
                GameObject.Destroy(beds);
            }

            if (Config.deleteFileCabinets.Value)
            {
                GameObject.Destroy(cabinet);
            }

            if (Config.deleteOxygenTank.Value)
            {
                GameObject.Destroy(tank);
            }

            if (Config.deleteClipboard.Value)
            {
                GameObject.Destroy(clipboard);
            }

            if (Config.deleteDoorGenerator.Value)
            {
                GameObject.Destroy(doorGenerator);
            }

            if (Config.deleteBoots.Value)
            {
                GameObject.Destroy(boots);
            }

            if (Config.deleteMask.Value)
            {
                GameObject.Destroy(mask);
            }

            if (Config.deleteAirFilter.Value)
            {
                GameObject.Destroy(airFilter);
            }

            if (Config.deleteStickyNote.Value)
            {
                GameObject.Destroy(stickyNote);
            }

            if (Config.deleteBatteries.Value)
            {
                GameObject.Destroy(battery);
                GameObject.Destroy(battery1);
                GameObject.Destroy(battery2);
                GameObject.Destroy(batteryPack);
            }

            if (Config.deleteVent.Value)
            {
                GameObject.Destroy(vent);
            }

            if (Config.deleteMonitorCords.Value)
            {
                GameObject.Destroy(monitorCords);
            }

            if (Config.deleteDoorSpeaker.Value)
            {
                GameObject.Destroy(doorSpeaker);
            }

            if (Config.deleteMainSpeaker.Value) 
            {   
                //ship speaker being instantiated is somehow tied to the ship door manual controls
                //to work around this I hid the speaker inside the ship wall and disabled the audio
                UnityEngine.Vector3 localSpeakerPos = new Vector3(11.4571f, 1.9706f, -16.9578f);        //hides the speaker in the front of the ship in the wall behind the monitors
                mainSpeaker.transform.position = localSpeakerPos;
                GameObject.Destroy(speakerAudio);                                                       //disables the audio from the speaker
            }

            if (Config.deletePosters.Value)
            {
                GameObject.Destroy(posters);
            }

            if (Config.deleteClothingRack.Value)
            {
                GameObject.Destroy(clothingRack);
                GameObject.Destroy(clothingHook);
                GameObject.Destroy(defaultSuit);
            }

            if (Config.deleteDoorTubes.Value)
            {
                GameObject.Destroy(doorTubes);
            }

            if (Config.deleteKeyboardCord.Value)
            {
                GameObject.Destroy(keyboardCord);
            }

            if (Config.lowLightMode.Value)
            {
                GameObject.Destroy(areaLight1);
                GameObject.Destroy(areaLight2);
                GameObject.Destroy(areaLight3);
                GameObject.Destroy(hangingLamp1);
                GameObject.Destroy(hangingLamp3);
            }
        }

        [HarmonyPostfix]
        [HarmonyPatch(typeof(StartOfRound), "Update")]
        public static void CustomCoords()
        { 
            //for custom charging coil coordinates
            if (Config.moveCoil.Value)
            {
                GameObject chargingCoil = GameObject.Find("Environment/HangarShip/ShipModels2b/ChargeStation");
                UnityEngine.Vector3 chargeLocalPos = new Vector3(xCordCoil.Value, yCordCoil.Value, zCordCoil.Value);
                UnityEngine.Vector3 chargeLocalRotation = new Vector3(xRotCoil.Value, yRotCoil.Value, zRotCoil.Value);

                chargingCoil.transform.localPosition = chargeLocalPos;
                chargingCoil.transform.eulerAngles = chargeLocalRotation;
            }
        }


        [HarmonyPostfix]
        [HarmonyPatch(typeof(ShipTeleporter), "Awake")]
        public static void TeleporterStuff()
        {
            if (GameObject.Find("Teleporter(Clone)/ButtonContainer/LongCord"))
            {
                GameObject longCord = GameObject.Find("Teleporter(Clone)/ButtonContainer/LongCord");
                longCord.SetActive(false);
            }

            
            if (Config.moveTeleButtonsToDesk.Value)
            {
                GameObject inverseTeleButton = GameObject.Find("InverseTeleporter(Clone)/ButtonContainer");
                GameObject teleButton = GameObject.Find("Teleporter(Clone)/ButtonContainer");

                UnityEngine.Vector3 linverseTeleButtonPos = new Vector3(-1.1695f, 0.4287f, 1.7645f);
                UnityEngine.Vector3 inverseTeleButtonRotation = new Vector3(0f, 2f, 0f);

                //UnityEngine.Vector3 teleButtonPosLocal = new Vector3(-1.3844f, 2.1098f, 2.143f);
                //UnityEngine.Vector3 teleButtonRotation = new Vector3(8f, 13f, 0f);
                UnityEngine.Vector3 teleButtonGlobal = new Vector3(1.7651f, 1.8303f, -11.5574f);

                inverseTeleButton.transform.localPosition = linverseTeleButtonPos;
                inverseTeleButton.transform.eulerAngles = inverseTeleButtonRotation;
                
                teleButton.transform.localRotation = new UnityEngine.Quaternion(0.0693f, 0.1129f, -0.0079f, 0.9912f);       //to get this quaternion, use UnityExplorer, find the buttoncontainer rotation vector you need
                teleButton.transform.position = teleButtonGlobal;                                                           //then inspect the transform component, and find the rotation quaternion and write it there

                //normal tele
                //rot 8 13 0
                //local -1.3844 2.1098 2.143s
                //global 1.7651 1.8303 -11.5574

                //inverse
                //global 1.61 0.789 -12.978
                //local -1.1695 0.4287 1.7645
                //rot 0 2 0
            }
            else if(Config.terminalReposition.Value)                          //Original button move
            {

                //if terminal is on the left it moves the inverse teleporter button so you can use it
                GameObject inverseTeleButton = GameObject.Find("InverseTeleporter(Clone)/ButtonContainer");
                GameObject teleButton = GameObject.Find("Teleporter(Clone)/ButtonContainer");

                UnityEngine.Vector3 linverseTeleButtonPos = new Vector3(-2.5327f, 0f, 1.6f);      //fixes button so it is not clipping in terminal
                UnityEngine.Vector3 inverseTeleButtonRotation = new Vector3(0f, 3f, 0f);

                UnityEngine.Vector3 teleButtonPos = new Vector3(-2.5327f, 0f, 1.6f);      //fixes button so it is not clipping in terminal 
                UnityEngine.Vector3 teleButtonRotation = new Vector3(0f, 3f, 0f); 

                inverseTeleButton.transform.localPosition = linverseTeleButtonPos;
                inverseTeleButton.transform.localRotation = new UnityEngine.Quaternion(0f, 0.0262f, 0f, 0.9997f);

            }

        }
    }
}

