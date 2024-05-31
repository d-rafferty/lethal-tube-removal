using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using LethalTubeRemoval.Patches;

namespace LethalTubeRemoval;

[BepInPlugin(modGUID, modName, modVersion)]
[BepInDependency("ainavt.lc.lethalconfig")]
public class TubeRemoval : BaseUnityPlugin
{
    private const string modGUID = "Hamster.LethalTubeRemoval";
    private const string modName = "Lethal Tube Removal";
    private const string modVersion = "1.7.4";

    private static TubeRemoval? Instance;

    private readonly Harmony harmony = new(modGUID);

    internal ManualLogSource mls;

    public static Config MyConfig { get; internal set; }

    private void Awake()
    {
        Instance ??= this;

        mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);
        mls.LogInfo("Mod is woked");

        MyConfig = new Config(Config);

        harmony.PatchAll(typeof(TubeRemoval));
        harmony.PatchAll(typeof(TubeRemovalPatch));
        harmony.PatchAll(typeof(TerminalReposition));
        harmony.PatchAll(typeof(OutsideShipPatch));
    }
}