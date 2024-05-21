using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface ICompetitonRepository
    {
        Task<Competition> AddAsync(Competition competition);
        Task<Competition> EditAsync(Competition competition);
        Task<IEnumerable<Competition>> GetAllAsync();
        Task<Competition> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
