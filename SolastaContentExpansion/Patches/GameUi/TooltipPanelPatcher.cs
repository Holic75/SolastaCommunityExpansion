﻿using System.Collections.Generic;
using HarmonyLib;

namespace SolastaContentExpansion.Patches
{
    [HarmonyPatch(typeof(TooltipPanel), "SetupFeatures")]
    internal static class TooltipPanel_SetupFeatures_Patcher
    {
        internal static void Prefix(ref TooltipDefinitions.Scope scope, GuiTooltipClassDefinition tooltipClassDefinition, Dictionary<string, TooltipFeature> tooltipsFeatures)
        {
            if (Main.Settings.InvertAltBehaviorOnTooltips)
            {
                if (scope == TooltipDefinitions.Scope.Simplified)
                {
                    scope = TooltipDefinitions.Scope.Detailed;
                }
                else if (scope == TooltipDefinitions.Scope.Detailed)
                {
                    scope = TooltipDefinitions.Scope.Simplified;
                }
            }
        }
    }
}