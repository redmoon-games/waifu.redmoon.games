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

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Timer.SetTimer(1000);
            Timer.OnElapsed += TickHandle;
        }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            Timer.SetTimer(1000);
            Timer.OnElapsed += TickHandle;
        }

        public async Task СlickHandle()
        {
            StateHasChanged();
            BigNumber moneyPerClick = BigNumber.One;
            IMoneyReward clickReward = new ClickReward(moneyPerClick);
            Player.AddReward(clickReward);
        }

        public void TickHandle()
        {
            IMoneyReward clickReward = new ClickReward(new BigNumber(10, 1));
            Player.AddReward(clickReward);
            Timer.SetTimer(1000);
            Timer.OnElapsed += TickHandle;
        }
    }
}
