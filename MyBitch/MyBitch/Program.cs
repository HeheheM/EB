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

        private static int LastRun;

        private static void Game_OnTick(EventArgs args)
        {
            if (LastRun > Environment.TickCount)return;

            var place = new Vector3(6950f, 1806f, -189f);
            var dist = Player.Instance.Distance(place);
            if (dist > 300)
            {
                Chat.Say("/all Going to the position!");
                Player.IssueOrder(GameObjectOrder.MoveTo, place);
            }
            LastRun = Environment.TickCount + 5000;
        }
    }
}
