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
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService()
        {
            _matchRepository = new MatchRepository(new Data.ApplicationDbContext());
        }

        public async Task<Match> CreateMatchAsync(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            return await _matchRepository.AddAsync(match);
        }

        public async Task DeleteMatchAsync(int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with Id {id} not found.");
            }

            await _matchRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Match>> GetAllMatchsAsync()
        {
            return await _matchRepository.GetAllAsync();
        }

        public async Task<Match> GetMatchByIdAsync(int id)
        {
            return await _matchRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Match>> GetMatchesByStatusAsync(MatchStatus status)
        {
            var matches = await _matchRepository.GetAllAsync();
            return matches.Where(m => m.Status == status);
        }

        public async Task ScheduleMatchAsync(Match match, MatchStatus status)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            match.Status = status;
            await _matchRepository.EditAsync(match);
        }

        public Task ScheduleMatchAsync(Match match)
        {
            throw new NotImplementedException();
        }


        public async Task SetMatchStatusAsync(int matchId, MatchStatus status)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with Id {matchId} not found.");
            }

            match.Status = status;
            await _matchRepository.EditAsync(match);
        }

        public async Task<Match> UpdateMatchAsync(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }

            return await _matchRepository.EditAsync(match);
        }
    }
}
