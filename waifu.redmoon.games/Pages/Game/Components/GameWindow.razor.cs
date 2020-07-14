using Microsoft.AspNetCore.Components;
using TournamentLibrary.Models;

namespace waifu.redmoon.games.Pages.Game.Components
{
    public class GameWindowLogic : ComponentBase
    {
        [Parameter]
        public IPlayer Player { get; set; }
        [Inject]
        public ITournament Tournament { get; set; }
        [Parameter]
        public bool PlayerIsReady { get; set; }

        public OptionType option = OptionType.clicker;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            StateHasChanged();
        }
    }
}
