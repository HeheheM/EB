using System;
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
        private static bool CanDrawHitMarker;
        private static Vector2 HitMarkPosition;
        private static Sprite BrazzerSprite;
        private static bool CanDrawBrazzerSprite;
        #region Sounds
        private static SoundPlayer WOWSound;
        private static SoundPlayer HitMarkerSound;
        private static SoundPlayer SadMusicSound;
        private static SoundPlayer OhMyGodSound;
        private static SoundPlayer FuckYeahSound;
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

            FuckYeahSound = new SoundPlayer(Resource1.fuck);

            #endregion Sounds
            #region Images

            TextureLoader.Load("hitmarker", Resource1.hitmark);
            HitMarker = new Sprite(() => TextureLoader["hitmarker"]);
            
            TextureLoader.Load("brazzer", Resource1.brazzer);
            BrazzerSprite = new Sprite(() => TextureLoader["brazzer"]);

            #endregion Images


            Game.OnNotify += Game_OnNotify;
            Obj_AI_Base.OnPlayAnimation += Obj_AI_Base_OnPlayAnimation;
            Drawing.OnEndScene += Drawing_OnEndScene;
            AttackableUnit.OnDamage += Obj_AI_Base_OnDamage;
        }

        private static void Obj_AI_Base_OnDamage(AttackableUnit sender, AttackableUnitDamageEventArgs args)
        {
            var caster = sender as AIHeroClient;
            var target = args.Target as AIHeroClient;
            if (caster == null || target == null || sender.Distance(Player.Instance) > 1500) return;

            HitMarkPosition = args.Target.Position.WorldToScreen();
            HitMarkerSound.Play();
            CanDrawHitMarker = true;
            Core.DelayAction(() => CanDrawHitMarker = false, 330);
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
                FuckYeahSound.Play();
                CanDrawBrazzerSprite = true;
                Core.DelayAction(() => CanDrawBrazzerSprite = false, 1500);
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
            if (CanDrawHitMarker)
            {
                var pos = new Vector2(HitMarkPosition.X - Resource1.hitmark.Width / 2, HitMarkPosition.Y - Resource1.hitmark.Height / 2 -30);
                HitMarker.Draw(pos);
            }

            if (CanDrawBrazzerSprite)
            {
                var pos1 = new Vector2(450, 280);
                BrazzerSprite.Draw(pos1);
            }
        }
    }
}
