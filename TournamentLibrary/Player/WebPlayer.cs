using System;
using System.Collections.Generic;
using System.Text;
using TournamentLibrary.MoneySystem;
using TournamentLibrary.UpdateSystem;

namespace TournamentLibrary.Player
{
    public class WebPlayer : Player
    {

        public WebPlayer(string login) : base(new WebPlayerProfile(login),
                                              new RemUpgrades(),
                                              new PlayerMoney())
        {

        }
    }
}
