using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface ICompetitionService
    {
        Task<Competition> GetCompetitionByIdAsync(int id);
        Task<IEnumerable<Competition>> GetAllCompetitionsAsync();
        Task<Competition> CreateCompetitionAsync(Competition competition);
        Task<Competition> UpdateCompetitionAsync(Competition competition);
        Task DeleteCompetitionAsync(int id);
        Task CreateTournamentAsync(Competition competition);
        Task SetCompetitonSeason(Competition competition, Season season);
    }
}
