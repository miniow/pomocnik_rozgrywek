using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IPearsonService
    {
        Task<Pearson> GetPearsonByIdAsync(int id);
        Task<IEnumerable<Pearson>> GetAllPearsonsAsync();
        Task<Pearson> CreatePearsonAsync(Pearson pearson);
        Task<Pearson> UpdatePearsonAsync(Pearson pearson);
        Task DeletePearsonAsync(int id);
        Task SetPlayerCurrentTeam(Pearson pearson, Team team);
    }
}
