using System;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;

namespace MLG
{
    internal class Program
    {
        private static Sprite HitMarker;
        #region Sounds
        private static SoundPlayer WOWSound;
        private static SoundPlayer HitMarkerSound;
        private static SoundPlayer SadMusicSound;
        #endregion Sounds

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        public static readonly TextureLoader TextureLoader = new TextureLoader();

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            #region Sounds
            WOWSound = new SoundPlayer(Resource1.WOWwav);
            HitMarkerSound = new SoundPlayer(Resource1.hitmarkersound);
            SadMusicSound = new SoundPlayer(Resource1.sadmusic);
            #endregion Sounds

            TextureLoader.Load("hitmarker", Resource1.hitmarker);
            HitMarker = new Sprite(() => TextureLoader["hitmarker"]);

            Game.OnNotify += Game_OnNotify;
            AIHeroClient.OnDeath += AIHeroClient_OnDeath;
        }

        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnChampionPentaKill)
            {
                WOWSound.Play();
            }
        }

        private static void AIHeroClient_OnDeath(Obj_AI_Base sender, OnHeroDeathEventArgs args)
        {
            var pos = sender.Position;
            HitMarkerSound.Play();
            HitMarker.Draw(pos.To2D());
            if (sender.IsMe)
            {
                SadMusicSound.Play();
            }
        }
    }
}
