using HarmonyLib;
using RimWorld;
using UnityEngine;
using Verse;
using ModSettingsFramework;

namespace ReGrowthCore
{
    [HarmonyPatch(typeof(PlaySettings), nameof(PlaySettings.DoPlaySettingsGlobalControls))]
    public static class PlaySettings_DoPlaySettingsGlobalControls_Patch
    {
        public static void Postfix(WidgetRow row, bool worldView)
        {
            if (worldView is false || BiomesKitWorldLayer.WorldBeautificationIsActive is false)
            {
                return;
            }
            bool showWorldLayers = BiomesKitWorldLayer.WorldBeautificationToggle;
            var toggleTexture = ContentFinder<Texture2D>.Get("UI/Icons/WMB_Toggle");
            row.ToggleableIcon(ref showWorldLayers, toggleTexture, "RG.ToggleWorldMapBeautification".Translate(), SoundDefOf.Mouseover_ButtonToggle);
            if (showWorldLayers != BiomesKitWorldLayer.WorldBeautificationToggle)
            {
                BiomesKitWorldLayer.WorldBeautificationToggle = showWorldLayers;
            }
        }
    }
}
