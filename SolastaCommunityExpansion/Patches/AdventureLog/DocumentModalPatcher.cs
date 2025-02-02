﻿using HarmonyLib;
using System.Diagnostics.CodeAnalysis;

namespace SolastaCommunityExpansion.Patches.AdventureLog
{
    [HarmonyPatch(typeof(DocumentModal), "Show")]
    [SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Patch")]
    internal static class DocumentModal_Show
    {
        internal static void Postfix(GuiEquipmentItem guiEquipmentItem)
        {
            if (Main.Settings.EnableAdventureLogDocuments)
            {
                var itemDefinition = guiEquipmentItem.ItemDefinition;

                Models.AdventureLogContext.LogEntry(itemDefinition, itemDefinition.GuiPresentation.SpriteReference);
            }
        }
    }
}
