﻿using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using UnityEngine;

namespace SolastaCommunityExpansion.Patches.GameUiBattle
{
    [HarmonyPatch(typeof(GameTime), "SetTimeScale")]
    [SuppressMessage("Minor Code Smell", "S101:Types should be named in PascalCase", Justification = "Patch")]
    internal static class GameTime_SetTimeScale
    {
        internal static bool Prefix(ref float ___timeScale, ref bool ___fasterTimeMode)
        {
            if (!Main.Settings.PermanentlySpeedBattleUp)
            {
                return true;
            }

            var isBattleInProgress = ServiceRepository.GetService<IGameLocationBattleService>()?.IsBattleInProgress;

            if (isBattleInProgress == true)
            {
                Time.timeScale = ___timeScale * Main.Settings.BattleCustomTimeScale;
            }
            else
            {
                Time.timeScale = ___timeScale * (___fasterTimeMode ? Main.Settings.BattleCustomTimeScale : 1f);
            }

            return false;
        }
    }
}
