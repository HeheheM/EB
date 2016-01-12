using System;
using EloBuddy;
using EloBuddy.SDK.Events;

namespace EBSpammer
{
    internal class Program
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
            if (LastRun + 600000 <= Environment.TickCount)
            {
                Chat.Say("/all EloBuddy ponto net, oferece os melhores scripts e e FREE");
                Chat.Say("/all Quem esta jogando nesse momento e um bot oferecido pelo EB.net");
                Chat.Say("/all Essas Mensagens serao enviadas a cada 10min GL HF");
                LastRun = Environment.TickCount;
            }
        }
    }
}
