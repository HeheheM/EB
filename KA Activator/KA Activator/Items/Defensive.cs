using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using KA_Activator.DMGHandler;

using Misc = KA_Activator.Config.Types.Settings;
using Settings = KA_Activator.Config.Types.DeffensiveItems;


namespace KA_Activator.Items
{
    // ReSharper disable once ClassNeverInstantiated.Global
    internal class Defensive : Ids
    {
        public static void Execute()
        {
            if (Player.Instance.IsInShopRange() || Player.Instance.CountAlliesInRange(Misc.RangeEnemy) < Misc.EnemyCount ||
                Activator.lastUsed >= Environment.TickCount) return;
            #region Self

            if (Zhonyas.IsReady() && Zhonyas.IsOwned() && Player.Instance.InDanger(Settings.ZhonyasMyHp) && Settings.Zhonyas)
            {
                Zhonyas.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (ArchengelStaff.IsReady() && ArchengelStaff.IsOwned() && Player.Instance.InDanger(Settings.MYHPArchengelStaff) && Settings.UseArchengelStaff)
            {
                ArchengelStaff.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (FaceOfTheMountain.IsReady() && FaceOfTheMountain.IsOwned() && Player.Instance.InDanger(30))
            {
                FaceOfTheMountain.Cast(Player.Instance);
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Talisman.IsReady() && Player.Instance.CountAlliesInRange(450) >= 2 && Talisman.IsOwned() &&
                Player.Instance.InDanger(30))
            {
                Talisman.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Mikael.IsReady() && Player.Instance.HasCC() && Mikael.IsOwned() && Player.Instance.InDanger(30))
            {
                Mikael.Cast(Player.Instance);
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Solari.IsReady() && Solari.IsOwned() && Player.Instance.InDanger(30))
            {
                Solari.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Ohm.IsReady() && Ohm.IsOwned() && Player.Instance.InDanger(30))
            {
                var turret = EntityManager.Turrets.Enemies.FirstOrDefault(t => t.IsAttackingPlayer);
                if (turret != null)
                {
                    Ohm.Cast(turret);
                    Activator.lastUsed = Environment.TickCount + 1500;
                }
            }

            if (Randuin.IsReady() && Player.Instance.CountEnemiesInRange(Randuin.Range) >= 2 && Randuin.IsOwned() &&
                Player.Instance.InDanger(30))
            {
                Randuin.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            //CC

            if (!Player.Instance.HasCC()) return;

            if (DerbishBlade.IsReady() && DerbishBlade.IsOwned())
            {
                DerbishBlade.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (Mercurial.IsReady() && Mercurial.IsOwned())
            {
                Mercurial.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            if (QuickSilver.IsReady() && QuickSilver.IsOwned())
            {
                QuickSilver.Cast();
                Activator.lastUsed = Environment.TickCount + 1500;
            }

            #endregion Self
        }
    }
}


