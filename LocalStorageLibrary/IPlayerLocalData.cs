using System.Threading.Tasks;
using TournamentLibrary.Player;

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