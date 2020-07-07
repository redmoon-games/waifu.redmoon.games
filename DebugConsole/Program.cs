using System;
using TournamentLibrary.Models;

namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ITeam firstTeam = new SummerTeam("Rem");
            ITeam secondTeam = new SummerTeam("Asui");
            ITournament tournament = new VSTournament(firstTeam, secondTeam);

            IPlayer newPlayer = new Player("saha1506");
            tournament.AddPlayer(newPlayer, firstTeam);

            for (int i = 0; i < 10; i++)
            {
                newPlayer.ClickEarn(new BigNumber(12, 0));
            }

            newPlayer.AddMoney(new BigNumber(125, 0));

            Console.WriteLine(tournament);
        }
    }
}
