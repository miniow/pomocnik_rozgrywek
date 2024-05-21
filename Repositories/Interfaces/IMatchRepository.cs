using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> AddAsync(Match match);
        Task<Match> EditAsync(Match match);
        Task RemoveAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<IEnumerable<Match>> GetAllAsync();
    }
}
