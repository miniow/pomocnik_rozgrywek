using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public PlayerRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Player> AddAsync(Player player)
        {
            await _db.Players.AddAsync(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task<Player> EditAsync(Player player)
        {
            _db.Players.Update(player);
            await _db.SaveChangesAsync();
            return player;
        }

        public async Task RemoveAsync(int id)
        {
            var player = await _db.Players.FindAsync(id);
            if (player != null)
            {
                _db.Players.Remove(player);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Player> GetByIdAsync(int id)
        {
            var player = await _db.Players.FindAsync(id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Pearson with Id {id} not found.");
            }
            return player;
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _db.Players.ToListAsync();
        }
    }
}
