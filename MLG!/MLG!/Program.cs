using System;
using System.Drawing;
using System.Media;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using SharpDX;

namespace MLG
{
    internal class Program
    {
        private static Sprite HitMarker;
        private static bool CanDraw;
        #region Sounds
        private static SoundPlayer WOWSound;
        private static SoundPlayer HitMarkerSound;
        private static SoundPlayer SadMusicSound;
        private static SoundPlayer OhMyGodSound;
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
            OhMyGodSound = new SoundPlayer(Resource1.ohmygod);
            #endregion Sounds

            TextureLoader.Load("hitmarker", Resource1.hitmark);
            HitMarker = new Sprite(() => TextureLoader["hitmarker"]);
            

            Game.OnNotify += Game_OnNotify;
            Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
            Drawing.OnEndScene += Drawing_OnEndScene;
            Obj_AI_Base.OnDamage += Obj_AI_Base_OnDamage;
        }

        private static void Obj_AI_Base_OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            HitMarkerSound.Play();
            CanDraw = true;
            Core.DelayAction(() => CanDraw = false, 700);
        }

        private static void Game_OnNotify(GameNotifyEventArgs args)
        {
            if (args.EventId == GameEventId.OnChampionPentaKill)
            {
                WOWSound.Play();
            }

            if (args.EventId == GameEventId.OnAce)
            {
                OhMyGodSound.Play();
            }

            if (args.EventId == GameEventId.OnFirstBlood)
            {
                
            }
        }

        private static void Obj_AI_Base_OnPlayAnimation(Obj_AI_Base sender, GameObjectPlayAnimationEventArgs args)
        {
            if (sender.IsMe && args.Animation.Equals("Death"))
            {
                SadMusicSound.Play();
            }
        }

        private static void Drawing_OnEndScene(EventArgs args)
        {
            if (CanDraw)
            {
                var pos = new Vector2(Player.Instance.Position.WorldToScreen().X - Resource1.hitmark.Height / 2, Player.Instance.Position.WorldToScreen().Y - Resource1.hitmark.Width / 2);
                HitMarker.Draw(pos);
            }
        }
    }
}
