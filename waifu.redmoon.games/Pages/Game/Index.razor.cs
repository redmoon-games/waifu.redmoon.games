using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TournamentLibrary.Models;
using LocalStorageLibrary;
using Blazored.LocalStorage;
using TournamentLibrary.CustomPlayer;

namespace waifu.redmoon.games.Pages.Game
{
    public class IndexLogic : ComponentBase
    {
        [Inject]
        public ITournament Tournament { get; set; }
        [Inject]
        public IPlayer Player { get; set; }
        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }
        public bool PlayerIsReady { 
            get 
            {
                if (Player.Team != null)
                {
                    foreach (var tournamentTeam in Tournament.Teams)
                    {
                        if (Player.Team.Name == tournamentTeam.Name)
                            return true;
                    }
                }
                return false;
            } }

        private IPlayerLocalData _localData;

        public async Task ResetLocalData()
        {
            await _localData.ClearDataAsync();
            Player = await LoadPlayerData();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Player = await LoadPlayerData();
        }

        private async Task<IPlayer> LoadPlayerData()
        {
            _localData = new PlayerLocalData(LocalStorageService);
            bool localDataIsCorrect = await _localData.IsCorrectAsync();
            IPlayer playerData = localDataIsCorrect ? await LoadProfileFromLocal() : GenerateProfile();
            return playerData;
        }

        private async Task<IPlayer> LoadProfileFromLocal()
        {
            return await _localData.LoadAsync();
        }

        private IPlayer GenerateProfile()
        {
            return new RemPlayer($"RU{new Random().Next()}");
        }

        public void ReloadPage(string hello)
        {
            StateHasChanged();
        }
    }
}
