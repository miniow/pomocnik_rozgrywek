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
        private readonly ICompetitonRepository _competitionRepository;

        public CompetitionService()
        {
            _competitionRepository = new CompetitionRepository(new Data.ApplicationDbContext());
        }
        public async Task<Competition> CreateCompetitionAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            return await _competitionRepository.AddAsync(competition);
        }

        public async Task CreateTournamentAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            await _competitionRepository.AddAsync(competition);
        }

        public async Task DeleteCompetitionAsync(int id)
        {
            await _competitionRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsAsync()
        {
            return await _competitionRepository.GetAllAsync();
        }

        public async Task<Competition> GetCompetitionByIdAsync(int id)
        {
            return await _competitionRepository.GetByIdAsync(id);
        }

        public async Task SetCompetitonSeason(Competition competition, Season season)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            competition.CurrentSeason = season;
            await _competitionRepository.EditAsync(competition);
        }

        public async Task<Competition> UpdateCompetitionAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            return await _competitionRepository.EditAsync(competition);
        }
    }
}
