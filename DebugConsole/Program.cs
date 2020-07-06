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
        }
    }
}
