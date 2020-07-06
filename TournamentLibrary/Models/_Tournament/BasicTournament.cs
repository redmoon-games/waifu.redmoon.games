using System.Collections.Generic;

namespace TournamentLibrary.Models
{
    sealed public class BasicTournament : Tournament
    {
        public int TotalScore { get; private set; }
        public bool IsFinished { get; private set; }

        private readonly int _maxScore;

        public BasicTournament(List<ITeam> tournamentMembers, string tournamentName = "new tournament", int maxTournamentScore = 1000)
            : base(tournamentName,
                   tournamentMembers)
        {
            TotalScore = 0;
            IsFinished = false;
            _maxScore = maxTournamentScore;
        }

        public override void AddPointsToMember(ITeam character, int score)
        {
            if (IsFinished == false)
            {
                checked
                {
                    base.AddPointsToMember(character, score);
                    TotalScore += score;
                }
                if (TotalScore >= _maxScore)
                    IsFinished = true;
            }
        }

        public override string ToString()
        {
            string returnString = $"{Name}: {TotalScore} / {_maxScore}\n";
            foreach (ITeam member in TournamentMembers)
            {
                returnString += $"{member.Name} : {member.Score}\n";
            }
            return returnString;
        }
    }
}
