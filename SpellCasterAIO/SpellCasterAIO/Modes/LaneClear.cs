using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = SpellCasterAIO.Config.Modes.LaneClear;
using Misc = SpellCasterAIO.Config.Modes.Misc;

namespace SpellCasterAIO.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var target = EntityManager.MinionsAndMonsters.GetLaneMinions().OrderBy(m => m.Health).FirstOrDefault(m => m.IsValidTarget(Misc.RangeTarget));
            if (target == null) return;

            var targetQ =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.Q) && m.IsValidTarget(Q.Range));

            if (targetQ != null && Q.IsReady() && targetQ.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.Q))
                {
                    Q.Cast(targetQ);
                }
                else
                {
                    Q.Cast();
                }
            }

            var targetW =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.W) && m.IsValidTarget(W.Range));

            if (targetW != null && W.IsReady() && targetW.IsValidTarget(W.Range) && Settings.UseW)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.W))
                {
                    W.Cast(targetW);
                }
                else
                {
                    W.Cast();
                }
            }

            var targetE =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.E) && m.IsValidTarget(E.Range));

            if (targetE != null && E.IsReady() && targetE.IsValidTarget(E.Range) && Settings.UseE)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.E))
                {
                    E.Cast(targetE);
                }
                else
                {
                    E.Cast();
                }
            }

            var targetR =
                EntityManager.MinionsAndMonsters.GetLaneMinions()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.R) && m.IsValidTarget(R.Range));

            if (targetR != null && R.IsReady() && targetR.IsValidTarget(R.Range) && Settings.UseR)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.R))
                {
                    R.Cast(targetR);
                }
                else
                {
                    R.Cast();
                }
            }
        }
    }
}
