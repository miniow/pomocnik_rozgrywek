using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IPlayerService
    {
        Task<Player> GetPlayerByIdAsync(int id);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<Player> CreatePlayerAsync(Player player);
        Task<Player> UpdatePlayernAsync(Player player);
        Task DeletePlayerAsync(int id);
        Task SetPlayerCurrentTeam(Player player, Team team);
    }
}
