using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using TournamentLibrary.Player;
using TournamentLibrary.Team;

namespace waifu.redmoon.games.Pages.Game
{
    public class IndexLogic : ComponentBase
    {
        public bool IsLogged { get; set; } = false;

        [Inject]
        public ITournament Tournament { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public void OnPlayerReady(bool isAuthorize)
        {
            IsLogged = isAuthorize;
        }
    }
}
