using Microsoft.AspNetCore.Components;
using TournamentLibrary.Models;

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
            Player.ChangeTeam(team);
            go = "GOGOGOGOGGO!!!!";
        }
    }
}
