using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;

namespace SpellCasterAIO
{
    public static class SpellManager
    {
        public static Spell.SpellBase Q { get; private set; }
        public static Spell.SpellBase W { get; private set; }
        public static Spell.SpellBase E { get; private set; }
        public static Spell.SpellBase R { get; private set; }

        static SpellManager()
        {
            foreach (var spell in Player.Instance.Spellbook.Spells.Where(s => s.Slot == SpellSlot.Q || s.Slot == SpellSlot.W || s.Slot == SpellSlot.E ||
                    s.Slot == SpellSlot.R))
            {
                var spelltype = GetSpellType(spell.Slot);

                switch (spell.Slot)
                {
                    case SpellSlot.Q:
                        switch (spelltype)
                        {
                            case Spells.Active:
                                Q = new Spell.Active(spell.Slot, GetSpellRange(SpellSlot.Q));
                                break;
                            case Spells.Targeted:
                                Q = new Spell.Targeted(spell.Slot, GetSpellRange(SpellSlot.Q));
                                break;
                            case Spells.SkillShotCircular:
                                Q = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.Q), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotLinear:
                                Q = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.Q), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotCone:
                                Q = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.Q), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastConeAngle);
                                break;
                        }
                        break;
                    case SpellSlot.W:
                        switch (spelltype)
                        {
                            case Spells.Active:
                                W = new Spell.Active(spell.Slot, GetSpellRange(SpellSlot.W));
                                break;
                            case Spells.Targeted:
                                W = new Spell.Targeted(spell.Slot, GetSpellRange(SpellSlot.W));
                                break;
                            case Spells.SkillShotCircular:
                                W = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.W), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotLinear:
                                W = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.W), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotCone:
                                W = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.W), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastConeAngle);
                                break;
                        }
                        break;
                    case SpellSlot.E:
                        switch (spelltype)
                        {
                            case Spells.Active:
                                E = new Spell.Active(spell.Slot, GetSpellRange(SpellSlot.E));
                                break;
                            case Spells.Targeted:
                                E = new Spell.Targeted(spell.Slot, GetSpellRange(SpellSlot.E));
                                break;
                            case Spells.SkillShotCircular:
                                E = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.E), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotLinear:
                                E = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.E), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotCone:
                                E = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.E), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastConeAngle);
                                break;
                        }
                        break;
                    case SpellSlot.R:
                        switch (spelltype)
                        {
                            case Spells.Active:
                                R = new Spell.Active(spell.Slot, GetSpellRange(SpellSlot.R));
                                break;
                            case Spells.Targeted:
                                R = new Spell.Targeted(spell.Slot, GetSpellRange(SpellSlot.R));
                                break;
                            case Spells.SkillShotCircular:
                                R = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.R), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotLinear:
                                R = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.R), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastRadius);
                                break;
                            case Spells.SkillShotCone:
                                R = new Spell.Skillshot(spell.Slot, GetSpellRange(SpellSlot.R), SkillShotType.Linear, 250, (int)spell.SData.MissileSpeed, (int)spell.SData.CastConeAngle);
                                break;
                        }
                        break;
                }
            }
            Q = new Spell.Active(SpellSlot.Q, GetSpellRange(SpellSlot.Q));
            W = new Spell.Active(SpellSlot.W, GetSpellRange(SpellSlot.W));
            E = new Spell.Active(SpellSlot.E, GetSpellRange(SpellSlot.E));
            R = new Spell.Targeted(SpellSlot.R, GetSpellRange(SpellSlot.R));
        }

        public static void Initialize()
        {
        }

        private enum Spells
        {
            Active,
            Targeted,
            SkillShotCircular,
            SkillShotLinear,
            SkillShotCone
        }

        private static uint GetSpellRange(SpellSlot slot)
        {
            if (Player.Instance.Spellbook.GetSpell(slot).SData.CastRangeDisplayOverride <= 0)
            {
                return (uint) Player.Instance.Spellbook.GetSpell(slot).SData.CastRange;
            }
            return (uint) Player.Instance.Spellbook.GetSpell(slot).SData.CastRangeDisplayOverride;
        }

        private static Spells GetSpellType(SpellSlot slot)
        {
            switch (Player.Instance.Spellbook.GetSpell(slot).SData.TargettingType)
            {
                case SpellDataTargetType.Self:
                    return Spells.Active;
                case SpellDataTargetType.Unit:
                    return Spells.Targeted;
                case SpellDataTargetType.LocationAoe:
                    return Spells.SkillShotCircular;
                case SpellDataTargetType.Cone:
                    return Spells.SkillShotCone;
                case SpellDataTargetType.SelfAoe:
                    return Spells.Active;
                case SpellDataTargetType.Location:
                    return Spells.SkillShotLinear;
                case SpellDataTargetType.SelfAndUnit:
                    return Spells.Active;
                case SpellDataTargetType.Location2:
                    return Spells.SkillShotLinear;
                case SpellDataTargetType.LocationVector:
                    return Spells.SkillShotLinear;
                case SpellDataTargetType.LocationTunnel:
                    return Spells.SkillShotLinear;
            }
            return Spells.Active;
        }

        public static bool SpellNeedTarget(SpellSlot slot)
        {
            var spelltype = GetSpellType(slot);
            switch (spelltype)
            {
                case Spells.Active:
                    return false;
                case Spells.Targeted:
                    return true;
                case Spells.SkillShotCircular:
                    return true;
                case Spells.SkillShotLinear:
                    return true;
                case Spells.SkillShotCone:
                    return true;
            }
            return false;
        }
    }
}
