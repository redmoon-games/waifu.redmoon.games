using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.UpgradeSys;

namespace waifu.redmoon.games.Pages.Game.Mini_Components
{
    public class UpgradeItemCompLogic : ComponentBase
    {
        [Parameter]
        public IUpgrade Upgrade { get; set; }
        [Parameter]
        public IPlayer Player { get; set; }

        public string error = "";

        public void BuyUpgrade()
        {
            if (Player.CanPay(Upgrade.Price))
            {
                Player.BuyUgrade(Upgrade);
                error = "";
            }
            else
            {
                error = "Player cant pay: " + Upgrade.Price;
            }
        }
    }
}
