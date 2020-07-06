using System;

namespace TournamentLibrary.Models
{
    public class SummerTeam : Team
    {
        public SummerTeam(string name)
            :base($"Summer: { name }")
        {
            //
        }
    }
}
