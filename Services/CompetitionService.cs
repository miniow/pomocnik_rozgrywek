using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitonRepository _competitonRepository;

        public CompetitionService()
        {
            _competitonRepository = new CompetitionRepository(new Data.ApplicationDbContext());
        }
        public async Task<Competition> CreateCompetitionAsync(Competition competition)
        {
            throw new NotImplementedException();
        }

        public async Task CreateTournamentAsync(Competition competition)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCompetitionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Competition> GetCompetitionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SetCompetitonSeason(Competition competition, Season season)
        {
            throw new NotImplementedException();
        }

        public async Task<Competition> UpdateCompetitionAsync(Competition competition)
        {
            throw new NotImplementedException();
        }
    }
}
