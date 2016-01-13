using System;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;

namespace MLG_
{
    internal class Program
    {
        private static Sprite HitMarker;
        private static SoundPlayer WOW;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static readonly TextureLoader TextureLoader = new TextureLoader();

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            WOW = new SoundPlayer(Resource1.WOWwav);

            TextureLoader.Load("hitmarker", Resource1.hitmarker);
            HitMarker = new Sprite(() => TextureLoader["hitmarker"]);

            Game.OnNotify += Game_OnNotify;
            AIHeroClient.OnDeath += AIHeroClient_OnDeath;
        }

        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnChampionPentaKill)
            {
                WOW.Play();
            }
        }

        private static void AIHeroClient_OnDeath(Obj_AI_Base sender, OnHeroDeathEventArgs args)
        {
            var pos = sender.Position;
            HitMarker.Draw(pos.To2D());
        }
    }
}
