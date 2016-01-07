using System.Linq;
using EloBuddy;
using EloBuddy.SDK;

using Settings = SpellCasterAIO.Config.Modes.LaneClear;

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
            var target = EntityManager.MinionsAndMonsters.GetJungleMonsters().OrderBy(m => m.Health).FirstOrDefault();
            if (target == null) return;

            if (Q.IsReady() && target.IsValidTarget(Q.Range) && Settings.UseQ)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.Q))
                {
                    Q.Cast(target);
                }
                else
                {
                    Q.Cast();
                }
            }

            if (W.IsReady() && target.IsValidTarget(W.Range) && Settings.UseW)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.W))
                {
                    W.Cast(target);
                }
                else
                {
                    W.Cast();
                }
            }

            if (E.IsReady() && target.IsValidTarget(E.Range) && Settings.UseE)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.E))
                {
                    E.Cast(target);
                }
                else
                {
                    E.Cast();
                }
            }

            if (R.IsReady() && target.IsValidTarget(R.Range) && Settings.UseR)
            {
                if (SpellManager.SpellNeedTarget(SpellSlot.R))
                {
                    R.Cast(target);
                }
                else
                {
                    R.Cast();
                }
            }
        }
    }
}
