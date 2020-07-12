using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary.Player;

namespace LocalStorageLibrary
{
    public class PlayerLocalData : IPlayerLocalData
    {
        private ILocalStorageService _localStorageService;
        private const string DATA_NAME = "playerData";

        public PlayerLocalData(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ClearDataAsync()
        {
            await _localStorageService.ClearAsync();
        }

        public async Task SaveAsync(IPlayer playerData)
        {
            await _localStorageService.SetItemAsync(DATA_NAME, playerData);
        }

        public async Task<IPlayer> LoadAsync()
        {
            return await _localStorageService.GetItemAsync<IPlayer>(DATA_NAME);
        }

        public async Task<bool> IsCorrectAsync()
        {
            IPlayer localPlayerData;
            try
            {
                localPlayerData = await _localStorageService.GetItemAsync<IPlayer>(DATA_NAME);
            }
            catch (Exception)
            {
                localPlayerData = null;
            }
            return localPlayerData != null;
        }
    }
}
