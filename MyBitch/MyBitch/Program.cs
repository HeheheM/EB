using System;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using SharpDX;

namespace MyBitch
{
    class Program
    {
        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += Loading_OnLoadingComplete;
        }

        private static void Loading_OnLoadingComplete(EventArgs args)
        {
            Game.OnTick += Game_OnTick;
        }

        //private static int LastRun;

        private static void Game_OnTick(EventArgs args)
        {
            var place1 = new Vector3(6900f, 1806f, -189f);
            var place2 = new Vector3(7000f, 1806f, -189f);

            Player.IssueOrder(GameObjectOrder.MoveTo, place1);
            Core.DelayAction(()=> Player.IssueOrder(GameObjectOrder.MoveTo, place1), 900);
        }
    }
}
