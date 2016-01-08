using System;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using Settings = SpellCasterAIO.Config.Modes.Draw;


namespace SpellCasterAIO
{
    public static class Program
    {
        // ReSharper disable once MemberCanBePrivate.Global

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            Drawing.OnDraw += OnDraw;

            /*
            foreach (
                var spell in
                    Player.Instance.Spellbook.Spells.Where(
                        s => s.Slot == SpellSlot.Q || s.Slot == SpellSlot.W || s.Slot == SpellSlot.E ||
                             s.Slot == SpellSlot.R))
            {
                Chat.Print("SpellName = " + spell.Name + " SCAIOrange = " + SpellManager.GetSpellRange(spell.Slot) +
                           " SCAIOspelltype = " + SpellManager.GetSpellType(spell.Slot) + " SpellDelay = " + (int)spell.SData.CastTime * 1000);
            }
            */
            
        }

        private static void OnDraw(EventArgs args)
        {
            try
            {
                if (Settings.DrawQ)
                {
                    new Circle { Color = SpellManager.Q.IsReady() ? Color.DodgerBlue : Color.Red, BorderWidth = 1f, Radius = SpellManager.Q.Range }.Draw(Player.Instance.Position);
                }

                if (Settings.DrawW)
                {
                    new Circle { Color = SpellManager.W.IsReady() ? Color.DodgerBlue : Color.Red, BorderWidth = 1f, Radius = SpellManager.W.Range }.Draw(Player.Instance.Position);
                }

                if (Settings.DrawE)
                {
                    new Circle { Color = SpellManager.E.IsReady() ? Color.DodgerBlue : Color.Red, BorderWidth = 1f, Radius = SpellManager.E.Range }.Draw(Player.Instance.Position);
                }

                if (Settings.DrawR)
                {
                    new Circle { Color = SpellManager.R.IsReady() ? Color.DodgerBlue : Color.Red, BorderWidth = 1f, Radius = SpellManager.R.Range }.Draw(Player.Instance.Position);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
