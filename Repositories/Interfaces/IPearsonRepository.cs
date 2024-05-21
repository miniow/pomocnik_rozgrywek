using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface IPearsonRepository
    {
        Task<Pearson> AddAsync(Pearson pearson);
        Task<Pearson> EditAsync(Pearson pearson);
        Task RemoveAsync(int id);
        Task<Pearson> GetByIdAsync(int id);
        Task<IEnumerable<Pearson>> GetAllAsync();
    }
}
