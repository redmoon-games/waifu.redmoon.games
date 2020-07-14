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
        public EventCallback<string> ReloadParent { get; set; }


        public void FastLogin()
        {
            Player.ChangeTeam(new RemTeam("Hot Beans #1"));

            //SetPlayerTeam(Tournament.Teams[0]);
            //await SavePlayerDataToLocal();
            //StateHasChanged();
        }

        public void SetPlayerTeam(ITeam team)
        {
            team.AddPlayer(Player);
            Player.ChangeTeam(team);
        }

        private async Task SavePlayerDataToLocal()
        {
            PlayerLocalData localData = new PlayerLocalData(LocalStorageService);
            await localData.SaveAsync(Player);
        }
    }
}
