using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.Player;

namespace waifu.redmoon.games.Pages.Game.Components
{
    public class GameWindowLogic : ComponentBase
    {
        [Inject]
        public IPlayer Player { get; set; }
        [Inject]
        public ITournament Tournament { get; set; }

        public OptionType option = OptionType.clicker;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            StateHasChanged();
        }
    }
}
