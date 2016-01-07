using EloBuddy.SDK;

namespace SpellCasterAIO.Modes
{
    public abstract class ModeBase
    {
        protected Spell.SpellBase Q
        {
            get { return SpellManager.Q; }
        }
        protected Spell.SpellBase W
        {
            get { return SpellManager.W; }
        }
        protected Spell.SpellBase E
        {
            get { return SpellManager.E; }
        }
        protected Spell.SpellBase R
        {
            get { return SpellManager.R; }
        }

        public abstract bool ShouldBeExecuted();

        public abstract void Execute();
    }
}
