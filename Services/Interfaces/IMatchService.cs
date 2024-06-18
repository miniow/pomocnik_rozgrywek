using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IMatchService
    {
        Task<Match> GetMatchByIdAsync(int id);
        Task<IEnumerable<Match>> GetAllMatchsAsync();
        Task<Match> CreateMatchAsync(Match match);
        Task<Match> UpdateMatchAsync(Match match);
        Task DeleteMatchAsync(int id);
        Task ScheduleMatchAsync(Match match);
        Task SetMatchStatusAsync(int matchId, MatchStatus status);
        Task<IEnumerable<Match>> GetMatchesByStatusAsync(MatchStatus status);

        Task<IEnumerable<Match>> ScheduleMatches(Competition competition);
    }
}
