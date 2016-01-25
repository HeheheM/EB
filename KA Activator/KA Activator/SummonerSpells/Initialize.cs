using KA_Activator.SummonerSpells.Spells;
using KickassSeries.Activator.SummonerSpells;

namespace KA_Activator.SummonerSpells
{
    internal class Initialize : Extensions
    {
        public static int lastSpell;

        public static void Init()
        {
            if (HasSpell("summonersmite"))
            {
                Smite.Initialize();
            }

            if (HasSpell("summonerheal"))
            {
                Heal.Initialize();
            }

            if (HasSpell("summonerbarrier"))
            {
                Barrier.Initialize();
            }

            if (HasSpell("summonerexhaust"))
            {
                Exhaust.Initialize();
            }

            if (HasSpell("summonerghost"))
            {
                Ghost.Initialize();
            }
        }

        public static void Execute()
        {
            if (HasSpell("summonersmite"))
            {
                Smite.Execute();
            }

            if (HasSpell("summonerheal"))
            {
                Heal.Execute();
            }

            if (HasSpell("summonerbarrier"))
            {
                Barrier.Execute();
            }

            if (HasSpell("summonerexhaust"))
            {
                Exhaust.Execute();
            }

            if (HasSpell("summonerghost"))
            {
                Ghost.Execute();
            }
        }
    }
}
