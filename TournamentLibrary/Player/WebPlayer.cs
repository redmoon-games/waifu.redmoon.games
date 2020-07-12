using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.MoneySystem;
using TournamentLibrary.Team;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public class WebPlayer : Player
    {
        public WebPlayer(string login) : base(new WebPlayerProfile(login),
                                              null,
                                              new PlayerMoney())
        {
            Team = new RemTeam("Defoult Team");
        }

        public WebPlayer(string login, ITeam team) : this(login)
        {
            Team = team;
        }
    }
}
