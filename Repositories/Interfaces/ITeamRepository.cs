using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface ITeamRepository
    {
        Task<Team> AddAsync(Team team);
        Task<Team> EditAsync(Team team);
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        void AttachEntity(Team team);
    }
}
