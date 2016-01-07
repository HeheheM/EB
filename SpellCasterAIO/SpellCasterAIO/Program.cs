using System;
using System.Drawing;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using Settings = SpellCasterAIO.Config.Modes.Draw;


namespace SpellCasterAIO
{
    public static class Program
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public const string ChampName = "";

        public static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if (Player.Instance.ChampionName == ChampName)
            {
                return;
            }

            Config.Initialize();
            SpellManager.Initialize();
            ModeManager.Initialize();

            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
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
    }
}
