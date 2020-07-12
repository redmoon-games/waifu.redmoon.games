using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.Player;
using TournamentLibrary.Team;

namespace waifu.redmoon.games.Pages.Game.Components
{
    public class RegistrationWindowLogic : ComponentBase
    {
        [Parameter]
        public IPlayer Player { get; set; }
        [Parameter]
        public EventCallback<string> ReloadParent { get; set; }
        [Inject]
        public ITournament Tournament { get; set; }

        public string go = "";

        public void FastLogin()
        {
            ITeam playerTeam = Tournament.Teams[0];
            SetPlayerTeam(playerTeam);

            StateHasChanged();
            ReloadParent.InvokeAsync("Hello from child");
        }

        public void SetPlayerTeam(ITeam team)
        {
            team.AddPlayer(Player);
            Player.Team = team;
            go = "GOGOGOGOGGO!!!!";
        }
    }
}
