﻿using System;
using EloBuddy;
using EloBuddy.SDK;

using Misc = KA_Activator.Config.Types.Settings;
using Settings = KA_Activator.Config.Types.ConsumablesItems;

namespace KA_Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global

    public sealed class Consumables : Ids
    {
        private static int LastRun;

        public static void Execute()
        {
            if (LastRun > Environment.TickCount)return;

            if (!Player.Instance.IsInShopRange() &&
                Player.Instance.CountAlliesInRange(Misc.RangeEnemy) >= Misc.EnemyCount &&
                Activator.lastUsed > Environment.TickCount)
            {
                if (Settings.UseHPpot && HealthPotion.IsOwned())
                {
                    if (Player.Instance.HealthPercent < Settings.MinHPpot && !Player.Instance.HasBuff("RegenerationPotion"))
                    {
                        HealthPotion.Cast();
                    }
                }

                if (Settings.UseBiscuits && Biscuit.IsOwned())
                {
                    if (Player.Instance.ManaPercent <= Settings.MinBiscuitMp && Player.Instance.HealthPercent <= Settings.MinBiscuitHp && !Player.Instance.HasBuff("ItemMiniRegenPotion"))
                    {
                        Biscuit.Cast();
                    }
                }

                if (Settings.UseRefillPOT && RefilablePotion.IsOwned())
                {
                    if (Player.Instance.HealthPercent <= Settings.MinRefillHp && !Player.Instance.HasBuff("ItemCrystalFlask"))
                    {
                        RefilablePotion.Cast();
                    }
                }

                if (Settings.UseCorrupts && CorruptingPotion.IsOwned())
                {
                    if (Player.Instance.ManaPercent < Settings.MinCorruptMp && Player.Instance.HealthPercent < Settings.MinCorruptHp && !Player.Instance.HasBuff("ItemDarkCrystalFlask"))
                    {
                        CorruptingPotion.Cast();
                    }
                }

                if (Settings.UseHunters && HuntersPotion.IsOwned())
                {
                    if (Player.Instance.ManaPercent < Settings.MinHunterMp && Player.Instance.HealthPercent < Settings.MinHunterHp && !Player.Instance.HasBuff("ItemCrystalFlaskJungle"))
                    {
                        HuntersPotion.Cast();
                    }
                }

                LastRun = Environment.TickCount + 1000;
            }
        }
    }
}
