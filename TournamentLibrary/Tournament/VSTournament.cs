using System.Collections.Generic;
using TournamentLibrary.Team;

namespace TournamentLibrary.Models
{
    sealed public class VSTournament : Tournament
    {
        public bool IsFinished { get; private set; }
        public ITeam FirstTeam { get; }
        public ITeam SecondTeam { get; }

        public VSTournament() : base(new ITeam[0])
        {

        }

        public VSTournament(ITeam firstTeam, ITeam secondTeam)
            : base(new ITeam[] { firstTeam, secondTeam })
        {
            IsFinished = false;
            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
        }

        public override string ToString()
        {
            string returnString = $"Tournament Start Time: { StartTime }\n";
            foreach (ITeam member in Teams)
            {
                returnString += $"{member.Name} : {member.TotalScore}\n";
            }
            return returnString;
        }
    }
}
