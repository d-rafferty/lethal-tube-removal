using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;

namespace LethalTubeRemoval.Patches;

internal class OutsideShipPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(StartOfRound), "Start")] //runs the patch each time the round is started
    private static void OutsideShip()
    {
        var floodLight =
            GameObject.Find(
                "Environment/HangarShip/ShipModels2b/ShipLightsPost"); //sets each ship item path as a GameObject
        var leftMachinery = GameObject.Find("Environment/HangarShip/SideMachineryLeft");
        var rightMachinery = GameObject.Find("Environment/HangarShip/SideMachineryRight");
        var rightTubing1 = GameObject.Find("Environment/HangarShip/Cube.005");
        var rightTubing2 = GameObject.Find("Environment/HangarShip/Cube.006");
        var backTubing1 = GameObject.Find("Environment/HangarShip/Cube.007");
        var backTubing2 = GameObject.Find("Environment/HangarShip/Cube.008");
        var exhaustLeft = GameObject.Find("Environment/HangarShip/NurbsPath.001");
        var weirdBoxRight = GameObject.Find("Environment/HangarShip/MeterBoxDevice.001");
        var extraPipingLeft = GameObject.Find("Environment/HangarShip/Pipework2.002");


        var railPosts = GameObject.Find("Environment/HangarShip/ShipRailPosts");
        var rails = GameObject.Find("Environment/HangarShip/ShipRails");

        var backRightThruster = GameObject.Find("Environment/HangarShip/ThrusterBackRight");
        var backLeftThruster = GameObject.Find("Environment/HangarShip/ThrusterBackLeft");

        var frontRightThruster = GameObject.Find("Environment/HangarShip/ThrusterFrontRight");
        var frontLeftThruster = GameObject.Find("Environment/HangarShip/ThrusterFrontLeft");

        var supportBeams1 = GameObject.Find("Environment/HangarShip/ShipSupportBeams");
        var supportBeams2 = GameObject.Find("Environment/HangarShip/ShipSupportBeams.001");

        var weirdBox = GameObject.Find("Environment/HangarShip/Cube.004");


        //Catwalk stuff
        var catWalk = GameObject.Find("Environment/HangarShip/CatwalkShip");
        var catWalkRailLining1 = GameObject.Find("Environment/HangarShip/CatwalkRailLining");
        var catWalkRailLining2 = GameObject.Find("Environment/HangarShip/CatwalkRailLiningB");
        var catWalkSupports = GameObject.Find("Environment/HangarShip/CatwalkUnderneathSupports");

        var bigLadder = GameObject.Find("Environment/HangarShip/OutsideShipRoom/Ladder");
        var shortLadder1 = GameObject.Find("Environment/HangarShip/LadderShort");
        var shortLadder2 = GameObject.Find("Environment/HangarShip/LadderShort (1)");
        var catWalkHitbox = GameObject.Find("Environment/HangarShip/ClimbOntoCatwalkHelper");


        if (Config.deleteFloodLight.Value) //checks config file for boolean value and if true deletes the item
            Object.Destroy(floodLight);

        if (Config.deleteMachinery.Value)
        {
            Object.Destroy(leftMachinery);
            Object.Destroy(rightMachinery);
            Object.Destroy(weirdBoxRight);
            Object.Destroy(extraPipingLeft);
        }
        else if (Config.deleteLeftMachinery.Value)
        {
            Object.Destroy(leftMachinery);
            Object.Destroy(extraPipingLeft);
        }

        if (Config.deleteOutsideTubing.Value)
        {
            Object.Destroy(rightTubing1);
            Object.Destroy(rightTubing2);
            Object.Destroy(backTubing1);
            Object.Destroy(backTubing2);
            Object.Destroy(exhaustLeft);
        }


        if (Config.deleteThrusters.Value) //deletes all thrusters
        {
            Object.Destroy(backRightThruster);
            Object.Destroy(frontRightThruster);
            Object.Destroy(backLeftThruster);
            Object.Destroy(frontLeftThruster);
        }
        else if
            (Config.deleteThrusterTube
             .Value) //if all thrusters have been chosen to be deleted, this will not run as it is redundant
        {
            Object.Destroy(backRightThruster);
        }

        if (Config.deleteSupportBeams.Value)
        {
            Object.Destroy(supportBeams1);
            Object.Destroy(supportBeams2);
        }

        if (Config.deleteWeirdBox.Value) Object.Destroy(weirdBox);

        if (Config.parkourMode.Value)
        {
            if (!Config.deleteSupportBeams.Value)
            {
                Object.Destroy(supportBeams1);
                Object.Destroy(supportBeams2);
            }

            Object.Destroy(catWalk);
            Object.Destroy(catWalkRailLining1);
            Object.Destroy(catWalkRailLining2);
            Object.Destroy(catWalkSupports);
            Object.Destroy(catWalkHitbox);
            Object.Destroy(railPosts);
            Object.Destroy(rails);
            bigLadder.SetActive(
                false); //ladders prevent door from closing as well, found setting the item as inactive instead of destroying it preserves door function
            shortLadder1.SetActive(false);
            shortLadder2.SetActive(false);
        }
        else if (Config.deleteRailing.Value)
        {
            Object.Destroy(railPosts);
            Object.Destroy(rails);
        }
    }
}