using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;
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
        private readonly ICompetitionRepository _competitonRepository;
        private readonly ITeamRepository _teamRepository;
        public MatchService()
        {
            _matchRepository = new MatchRepository();
            _competitonRepository = new CompetitionRepository();
            _teamRepository = new TeamRepository();
        }
        public async Task RecordMatchStatistics(int matchId, MatchStatistic homeStatistic, MatchStatistic awayStatistic)
        {
            var match = await _matchRepository.GetByIdAsync(matchId);
            if (match != null)
            {
                match.AwayStatistic= homeStatistic;
                match.AwayStatistic = awayStatistic;
            }
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

        public async Task<IEnumerable<Match>> ScheduleMatches(Competition competition)
        {
            var numberOfTeams = await _competitonRepository.GetNumberOfTeamsInCompetitionAsync(competition);
            if (!IsPowerOfTwo(numberOfTeams))
            {
                throw new ArgumentException("To low number of teams");
            }
            if(numberOfTeams > 8)
            {
                throw new ArgumentException("To much number of teams");

            }
            var competitionDTO = await _competitonRepository.GetByIdAsync(competition.Id);
            var teams = competitionDTO.Teams.ToList();
            var matches = new List<Match>();
            var rng = new Random();
            teams = teams.OrderBy(t => rng.Next()).ToList();
            CompetitionStage stage;
            if (numberOfTeams == 2) {
                stage = CompetitionStage.FINAL;
            }
            else if(numberOfTeams == 4)
            {
                stage = CompetitionStage.SEMI_FINALS;
            }
            else
            {
                stage = CompetitionStage.QUARTER_FINALS;
            }
            
            for (int i = 0; i < teams.Count; i += 2)
            {
                var match = new Match
                {
                    Competition = competition,
                    HomeTeam = teams[i],
                    AwayTeam = teams[i + 1],
                    UtcDate = DateTime.UtcNow,
                    Status = MatchStatus.SCHEDULED,
                    Venue = teams[i].Venue,
                    
                    
                };
                if (competition.CurrentSeason != null)
                {
                    match.Stage = competition.CurrentSeason.Stages;
                    match.Matchday = competition.CurrentSeason.CurrentMatchday;
                }
                    

                matches.Add(match);
            }

            await _matchRepository.AddMatchesAsync(matches);
            return matches;
        }



        private static bool IsPowerOfTwo(int number)
        {
            return (number > 0) && ((number & (number - 1)) == 0);
        }
    }

}
