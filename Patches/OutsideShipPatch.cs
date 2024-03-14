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

namespace LethalTubeRemoval.Patches
{
    internal class OutsideShipPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(StartOfRound), "Start")]           //runs the patch each time the round is started
        static void OutsideShip()
        {
            GameObject floodLight = GameObject.Find("Environment/HangarShip/ShipModels2b/ShipLightsPost");        //sets each ship item path as a GameObject
            GameObject leftMachinery = GameObject.Find("Environment/HangarShip/SideMachineryLeft");
            GameObject rightMachinery = GameObject.Find("Environment/HangarShip/SideMachineryRight");
            GameObject rightTubing1 = GameObject.Find("Environment/HangarShip/Cube.005");
            GameObject rightTubing2 = GameObject.Find("Environment/HangarShip/Cube.006");
            GameObject backTubing1 = GameObject.Find("Environment/HangarShip/Cube.007");
            GameObject backTubing2 = GameObject.Find("Environment/HangarShip/Cube.008");
            GameObject exhaustLeft = GameObject.Find("Environment/HangarShip/NurbsPath.001");
            GameObject weirdBoxRight = GameObject.Find("Environment/HangarShip/MeterBoxDevice.001");
            GameObject extraPipingLeft = GameObject.Find("Environment/HangarShip/Pipework2.002");


            GameObject railPosts = GameObject.Find("Environment/HangarShip/ShipRailPosts");
            GameObject rails = GameObject.Find("Environment/HangarShip/ShipRails");

            GameObject backRightThruster = GameObject.Find("Environment/HangarShip/ThrusterBackRight");
            GameObject backLeftThruster = GameObject.Find("Environment/HangarShip/ThrusterBackLeft");

            GameObject frontRightThruster = GameObject.Find("Environment/HangarShip/ThrusterFrontRight");
            GameObject frontLeftThruster = GameObject.Find("Environment/HangarShip/ThrusterFrontLeft");

            GameObject supportBeams1 = GameObject.Find("Environment/HangarShip/ShipSupportBeams");
            GameObject supportBeams2 = GameObject.Find("Environment/HangarShip/ShipSupportBeams.001");

            GameObject weirdBox = GameObject.Find("Environment/HangarShip/Cube.004");


            //Catwalk stuff
            GameObject catWalk = GameObject.Find("Environment/HangarShip/CatwalkShip");
            GameObject catWalkRailLining1 = GameObject.Find("Environment/HangarShip/CatwalkRailLining");
            GameObject catWalkRailLining2 = GameObject.Find("Environment/HangarShip/CatwalkRailLiningB");
            GameObject catWalkSupports = GameObject.Find("Environment/HangarShip/CatwalkUnderneathSupports");

            GameObject bigLadder = GameObject.Find("Environment/HangarShip/OutsideShipRoom/Ladder");
            GameObject shortLadder1 = GameObject.Find("Environment/HangarShip/LadderShort");
            GameObject shortLadder2 = GameObject.Find("Environment/HangarShip/LadderShort (1)");
            GameObject catWalkHitbox = GameObject.Find("Environment/HangarShip/ClimbOntoCatwalkHelper");



            if (Config.deleteFloodLight.Value)            //checks config file for boolean value and if true deletes the item
            {
                GameObject.Destroy(floodLight);
            }

            if (Config.deleteMachinery.Value)
            {
                GameObject.Destroy(leftMachinery);
                GameObject.Destroy(rightMachinery);
                GameObject.Destroy(weirdBoxRight);
                GameObject.Destroy(extraPipingLeft);
            }

            if (Config.deleteOutsideTubing.Value)
            {
                GameObject.Destroy(rightTubing1);
                GameObject.Destroy(rightTubing2);
                GameObject.Destroy(backTubing1);
                GameObject.Destroy(backTubing2);
                GameObject.Destroy(exhaustLeft);
            }

            if (Config.deleteRailing.Value)
            {
                GameObject.Destroy(railPosts);
                GameObject.Destroy(rails);
            }

            if (Config.deleteThrusters.Value)                       //deletes all thrusters
            {
                GameObject.Destroy(backRightThruster);
                GameObject.Destroy(frontRightThruster);
                GameObject.Destroy(backLeftThruster);
                GameObject.Destroy(frontLeftThruster);

            }
            else if (Config.deleteThrusterTube.Value)             //if all thrusters have been chosen to be deleted, this will not run as it is redundant
            {
                GameObject.Destroy(backRightThruster);
            }

            if (Config.deleteSupportBeams.Value)
            {
                GameObject.Destroy(supportBeams1);
                GameObject.Destroy(supportBeams2);
            }

            if (Config.deleteWeirdBox.Value)
            {
                GameObject.Destroy(weirdBox);
            }

            if (Config.parkourMode.Value)
            {
                GameObject.Destroy(catWalk);
                GameObject.Destroy(catWalkRailLining1);
                GameObject.Destroy(catWalkRailLining2);
                GameObject.Destroy(catWalkSupports);
                GameObject.Destroy(catWalkHitbox);
                bigLadder.SetActive(false);             //ladders prevent door from closing as well, found setting the item as inactive instead of destroying it preserves door function
                shortLadder1.SetActive(false);
                shortLadder2.SetActive(false);
            }
        }
    }
}
