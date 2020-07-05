using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentLibrary.Models
{
    public abstract class Tournament : ITournament
    {
        public List<ITeam> TournamentMembers => _tournamentMembers;
        public string Name => _tournamentName;
        public DateTime StartTime => _startTime;


        private readonly string _tournamentName;
        private readonly DateTime _startTime;
        private List<ITeam> _tournamentMembers;

        public Tournament(string tournamentName, List<ITeam> tournamentMembers)
        {
            if (tournamentMembers.Count == 0)
                throw new ArgumentNullException($"tournamentMembers should be greater than 0! tournamentMembers.Count = {tournamentMembers.Count}");
            _tournamentName = tournamentName;
            _startTime = DateTime.Now;
            _tournamentMembers = tournamentMembers;
        }

        public Tournament()
        {
            _startTime = DateTime.Now;
        }

        public virtual void AddPointsToMember(ITeam character, int score)
        {
            if (MemberIsExist(character))
            {
                ITeam characterToAdd = _tournamentMembers.Find(c => c == character);
                characterToAdd.AddScore(score);
            }
        }

        public virtual List<ITeam> GetTopMembersList(int listSizeLimit = 25)
        {
            List<ITeam> topList = _tournamentMembers.OrderBy(param => param.Score).ToList();
            return topList.Take(listSizeLimit).ToList();
        }

        private bool MemberIsExist(ITeam character)
        {
            // TODO: If member dont exist, log information
            return _tournamentMembers.Contains(character);
        }

        public ITeam GetWinner()
        {
            ITeam winner = GetTopMembersList(1).Take(1) as ITeam;
            return winner;
        }

        public void AddMember(ITeam member)
        {
            TournamentMembers.Add(member);
        }
    }
}
