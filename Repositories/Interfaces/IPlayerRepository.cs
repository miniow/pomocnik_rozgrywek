using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> AddAsync(Player player);
        Task<Player> EditAsync(Player player);
        Task RemoveAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<IEnumerable<Player>> GetAllAsync();
    }
}
