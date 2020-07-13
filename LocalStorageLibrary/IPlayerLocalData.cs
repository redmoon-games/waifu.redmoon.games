using System.Threading.Tasks;
using TournamentLibrary.Models;

namespace LocalStorageLibrary
{
    public interface IPlayerLocalData
    {
        Task<bool> IsCorrectAsync();
        Task ClearDataAsync();
        Task<IPlayer> LoadAsync();
        Task SaveAsync(IPlayer playerData);
    }
}