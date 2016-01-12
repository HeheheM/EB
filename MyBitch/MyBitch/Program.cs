using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;
using Color = System.Drawing.Color;

namespace MyBitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
            var place1 = new Vector3(6900f, 1800f, -189f);
            Player.IssueOrder(GameObjectOrder.MoveTo, place1);
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Game.OnTick += Game_OnTick;
            Drawing.OnDraw += Drawing_OnDraw;
            Player.OnSpawn += Player_OnSpawn;
        }

        private static void Player_OnSpawn(Obj_AI_Base sender)
        {
            var place1 = new Vector3(6900f, 1800f, -189f);
            Player.IssueOrder(GameObjectOrder.MoveTo, place1);
        }

        private static void Game_OnTick(EventArgs args)
        {
            var place1 = new Vector3(6900f, 1800f, -189f);
            var place2 = new Vector3(7900f, 1800f, -189f);
            var place3 = new Vector3(7900f, 2000f, -189f);
            var place4 = new Vector3(6900f, 2000f, -189f);

            if (Player.Instance.Distance(place1) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place2);
            }

            if (Player.Instance.Distance(place2) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place3);
            }

            if (Player.Instance.Distance(place3) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place4);
            }

            if (Player.Instance.Distance(place4) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place1);
            }
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            var place1 = new Vector3(6900f, 1800f, -189f);
            Drawing.DrawCircle(place1, 10f, Color.Red);
        }
    }
}
