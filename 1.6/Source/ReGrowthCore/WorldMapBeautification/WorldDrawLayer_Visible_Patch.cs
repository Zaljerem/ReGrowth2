using HarmonyLib;
using RimWorld.Planet;

namespace ReGrowthCore
{
    [HarmonyPatch(typeof(WorldDrawLayer), "Visible", MethodType.Getter)]
    internal static class WorldDrawLayer_Visible_Patch
    {
        internal static bool Prefix(WorldDrawLayer __instance)
        {
            if (__instance is WorldDrawLayer_Hills 
            && BiomesKitWorldLayer.WorldBeautificationIsActive && BiomesKitWorldLayer.WorldBeautificationToggle)
            {
                return false;
            }
            return true;
        }
    }
}
