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
            var place1 = new Vector3(6900f, 1806f, -189f);
            Player.IssueOrder(GameObjectOrder.MoveTo, place1);
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

            if (Player.Instance.Distance(place2) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place1);
            }

            if (Player.Instance.Distance(place1) < 10)
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, place2);
            }
            
        }
    }
}
