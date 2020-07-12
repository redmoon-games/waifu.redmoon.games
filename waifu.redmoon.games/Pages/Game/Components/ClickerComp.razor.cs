using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentLibrary.Player;
using TournamentLibrary.Rewards;
using TournamentLibrary.Models;
using LocalStorageLibrary;

namespace waifu.redmoon.games.Pages.Game.Components
{
    public class ClickerCompLogic : ComponentBase
    {
        [Parameter]
        public IPlayer Player { get; set; }
        [Inject]
        public TimerService Timer { get; set; }

        private const int TICK_SPEED = 1000;

        public string MoneyPerSec { get { 
                return new TimeReward(Player.Upgrades, 1).MoneyToAdd.Amount.ToString(); 
            } }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Timer.OnElapsed += TickHandle;
            Timer.SetTimer(TICK_SPEED);
        }

        public void СlickHandle()
        {
            BigNumber moneyPerClick = BigNumber.One + Player.Upgrades.MoneyPerClick;
            IMoneyReward clickReward = new ClickReward(moneyPerClick);
            Player.AddReward(clickReward);
        }

        public void TickHandle()
        {
            IMoneyReward timeReward = new TimeReward(Player.Upgrades, TICK_SPEED / 1000);
            Player.AddReward(timeReward);

            Timer.SetTimer(TICK_SPEED);
            InvokeAsync(StateHasChanged);
        }
    }
}
