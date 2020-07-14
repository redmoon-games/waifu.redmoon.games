using Blazored.LocalStorage;
using LocalStorageLibrary;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TournamentLibrary.CustomTeam;
using TournamentLibrary.Models;

namespace waifu.redmoon.games.Pages.Game.Components
{
    public class RegistrationWindowLogic : ComponentBase
    {
        [Parameter]
        public IPlayer Player { get; set; }
        [Parameter]
        public ITournament Tournament { get; set; }
        [Parameter]
        public ILocalStorageService LocalStorageService { get; set; }
        [Parameter]
        public EventCallback ReloadParent { get; set; }


        public async Task FastLogin()
        {
            Tournament.Teams[0].AddPlayer(Player);
            await SavePlayerDataToLocal();
            await ReloadParent.InvokeAsync(null);
        }

        private async Task SavePlayerDataToLocal()
        {
            PlayerLocalData localData = new PlayerLocalData(LocalStorageService);
            await localData.SaveAsync(Player);
        }
    }
}
