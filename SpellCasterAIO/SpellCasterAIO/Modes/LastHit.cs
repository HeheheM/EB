using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = SpellCasterAIO.Config.Modes.LastHit;

namespace SpellCasterAIO.Modes
{
    public sealed class LastHit : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LastHit);
        }

        public override void Execute()
        {
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderBy(m => m.Health).FirstOrDefault();
            if (target == null) return;

            var targetQ =
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.Q));

            if (Q.IsReady() && targetQ.IsValidTarget(Q.Range) && Settings.UseQ)
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
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.W));

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
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
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.E));

            if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
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
                EntityManager.MinionsAndMonsters.GetJungleMonsters()
                    .OrderByDescending(m => m.Health)
                    .FirstOrDefault(m => m.Health <= Player.Instance.GetSpellDamage(m, SpellSlot.R));

            if (R.IsReady() && target.IsValidTarget(R.Range) && Settings.UseR)
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
