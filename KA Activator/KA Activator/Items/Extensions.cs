using EloBuddy;

// ReSharper disable once ConvertIfStatementToReturnStatement

namespace KA_Activator.Items
{
    internal static class Extensions
    {
        public static bool HasCC(this AIHeroClient target)
        {          
            if (target.HasBuffOfType(BuffType.Polymorph) || target.HasBuffOfType(BuffType.Taunt) || target.HasBuffOfType(BuffType.Charm) || target.HasBuffOfType(BuffType.Stun) ||
                target.HasBuffOfType(BuffType.Snare) || target.HasBuffOfType(BuffType.Silence) || target.HasBuff("zedulttargetmark") || target.HasBuff("VladimirHemoplague")
                || target.HasBuff("MordekaiserChildrenOfTheGrave"))
            {
                return true;
            }
            return false;
        }
    }
}
