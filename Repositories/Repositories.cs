using LiveCharts.Wpf.Charts.Base;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomocnik_Rozgrywek.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly Database _db;

        public RepositoryBase()
        {
            _db = Database.Instance;
        }
    }

    public class AreaRepository : RepositoryBase, IAreaRepository
    {
        public Task<Area> AddAsync(Area area)
        {
            return Task.Run(() =>
            {
                _db.Areas.Add(area);
                return area;
            });
        }

        public Task<Area> EditAsync(Area area)
        {
            return Task.Run(() =>
            {
                var existingArea = _db.Areas.FirstOrDefault(a => a.Id == area.Id);
                if (existingArea != null)
                {
                    existingArea.Name = area.Name;
                    existingArea.Code = area.Code;
                    existingArea.Flag = area.Flag;
                    existingArea.ParentAreaId = area.ParentAreaId;
                    existingArea.ParentArea = area.ParentArea;
                    existingArea.ChildAreas = area.ChildAreas;
                    existingArea.Competitions = area.Competitions;
                }
                return existingArea;
            });
        }

        public Task<IEnumerable<Area>> GetAllAsync()
        {
            return Task.Run(() => _db.Areas.AsEnumerable());
        }

        public Task<Area> GetRootAsync()
        {
            return Task.Run(() => _db.Areas.FirstOrDefault(a => a.ParentAreaId == null));
        }

        public Task<Area> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.Areas.FirstOrDefault(a => a.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var area = _db.Areas.FirstOrDefault(a => a.Id == id);
                if (area != null)
                {
                    _db.Areas.Remove(area);
                }
            });
        }

    }

    public class CompetitionRepository : RepositoryBase, ICompetitionRepository
    {
        public Task<Competition> AddAsync(Competition competition)
        {
            return Task.Run(() =>
            {
                _db.Competitions.Add(competition);
                return competition;
            });
        }

        public Task<Competition> EditAsync(Competition competition)
        {
            return Task.Run(() =>
            {
                var existingCompetition = _db.Competitions.FirstOrDefault(c => c.Id == competition.Id);
                if (existingCompetition != null)
                {
                    existingCompetition.Name = competition.Name;
                    existingCompetition.Code = competition.Code;
                    existingCompetition.Type = competition.Type;
                    existingCompetition.Emblem = competition.Emblem;
                    existingCompetition.CurrentSeason = competition.CurrentSeason;
                    existingCompetition.Teams = competition.Teams;
                    existingCompetition.Area = competition.Area;
                }
                return existingCompetition;
            });
        }

        public Task<IEnumerable<Competition>> GetAllAsync()
        {
            return Task.Run(() => _db.Competitions.AsEnumerable());
        }

        public Task<Competition> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.Competitions.FirstOrDefault(c => c.Id == id));
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var competition = _db.Competitions.FirstOrDefault(c => c.Id == id);
                if (competition != null)
                {
                    _db.Competitions.Remove(competition);
                }
            });
        }

        public Task<int> GetNumberOfTeamsInCompetitionAsync(Competition competition)
        {
            return Task.Run(() => competition.Teams?.Count ?? 0);
        }

        public Task<IEnumerable<Team>> GetAllTeamsAsync(Competition competition)
        {
            return Task.Run(() => competition.Teams.AsEnumerable());
        }
    }

    public class MatchRepository : RepositoryBase, IMatchRepository
    {
        public Task<Match> AddAsync(Match match)
        {
            return Task.Run(() =>
            {
                _db.Matches.Add(match);
                return match;
            });
        }

        public Task<Match> EditAsync(Match match)
        {
            return Task.Run(() =>
            {
                var existingMatch = _db.Matches.FirstOrDefault(m => m.Id == match.Id);
                if (existingMatch != null)
                {
                    existingMatch.Competition = match.Competition;
                    existingMatch.UtcDate = match.UtcDate;
                    existingMatch.Status = match.Status;
                    existingMatch.Minute = match.Minute;
                    existingMatch.InjuryTime = match.InjuryTime;
                    existingMatch.Attendance = match.Attendance;
                    existingMatch.Venue = match.Venue;
                    existingMatch.Matchday = match.Matchday;
                    existingMatch.Stage = match.Stage;
                    existingMatch.HomeTeam = match.HomeTeam;
                    existingMatch.HomeStatistic = match.HomeStatistic;
                    existingMatch.HomeStatisticId = match.HomeStatisticId;
                    existingMatch.AwayTeam = match.AwayTeam;
                    existingMatch.AwayStatistic = match.AwayStatistic;
                    existingMatch.AwayStatisticId = match.AwayStatisticId;
                }
                return existingMatch;
            });
        }

        public Task<Match> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.Matches.FirstOrDefault(m => m.Id == id));
        }

        public Task<IEnumerable<Match>> GetAllAsync()
        {
            return Task.Run(() => _db.Matches.AsEnumerable());
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var match = _db.Matches.FirstOrDefault(m => m.Id == id);
                if (match != null)
                {
                    _db.Matches.Remove(match);
                }
            });
        }

        public Task AddMatchesAsync(List<Match> matches)
        {
            return Task.Run(() =>
            {
                foreach (var match in matches)
                {
                    _db.Matches.Add(match);
                }
            });
        }
    }

    public class PersonRepository : RepositoryBase, IPersonRepository
    {
        public Task<Person> AddAsync(Person player)
        {
            return Task.Run(() =>
            {
                _db.People.Add(player);
                return player;
            });
        }

        public Task<Person> EditAsync(Person player)
        {
            return Task.Run(() =>
            {
                var existingPlayer = _db.People.FirstOrDefault(p => p.Id == player.Id);
                if (existingPlayer != null)
                {
                    existingPlayer.FirstName = player.FirstName;
                    existingPlayer.LastName = player.LastName;
                    existingPlayer.DateOfBirth = player.DateOfBirth;
                    existingPlayer.Nationality = player.Nationality;
                    existingPlayer.Position = player.Position;
                    existingPlayer.ShirtNumber = player.ShirtNumber;
                    existingPlayer.LastUpdated = player.LastUpdated;
                    existingPlayer.CurrentTeamId = player.CurrentTeamId;
                    existingPlayer.CurrentTeam = player.CurrentTeam;
                }
                return existingPlayer;
            });
        }

        public Task<Person> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.People.FirstOrDefault(p => p.Id == id));
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            return Task.Run(() => _db.People.AsEnumerable());
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var player = _db.People.FirstOrDefault(p => p.Id == id);
                if (player != null)
                {
                    _db.People.Remove(player);
                }
            });
        }
    }

    public class SeasonRepository : RepositoryBase, ISeasonRepository
    {
        public Task<Season> AddAsync(Season season)
        {
            return Task.Run(() =>
            {
                _db.Seasons.Add(season);
                return season;
            });
        }

        public Task<Season> EditAsync(Season season)
        {
            return Task.Run(() =>
            {
                var existingSeason = _db.Seasons.FirstOrDefault(s => s.Id == season.Id);
                if (existingSeason != null)
                {
                    existingSeason.StartDate = season.StartDate;
                    existingSeason.EndDate = season.EndDate;
                    existingSeason.CurrentMatchday = season.CurrentMatchday;
                    existingSeason.Stages = season.Stages;
                    existingSeason.Competitions = season.Competitions;
                }
                return existingSeason;
            });
        }

        public Task<Season> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.Seasons.FirstOrDefault(s => s.Id == id));
        }

        public Task<IEnumerable<Season>> GetAllAsync()
        {
            return Task.Run(() => _db.Seasons.AsEnumerable());
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var season = _db.Seasons.FirstOrDefault(s => s.Id == id);
                if (season != null)
                {
                    _db.Seasons.Remove(season);
                }
            });
        }
    }

    public class TeamRepository : RepositoryBase, ITeamRepository
    {
        public Task<Team> AddAsync(Team team)
        {
            return Task.Run(() =>
            {
                _db.Teams.Add(team);
                return team;
            });
        }

        public Task<Team> EditAsync(Team team)
        {
            return Task.Run(() =>
            {
                var existingTeam = _db.Teams.FirstOrDefault(t => t.Id == team.Id);
                if (existingTeam != null)
                {
                    existingTeam.Name = team.Name;
                    existingTeam.ShortName = team.ShortName;
                    existingTeam.Tla = team.Tla;
                    existingTeam.Crest = team.Crest;
                    existingTeam.Address = team.Address;
                    existingTeam.Website = team.Website;
                    existingTeam.Founded = team.Founded;
                    existingTeam.ClubColors = team.ClubColors;
                    existingTeam.Venue = team.Venue;
                    existingTeam.RunningCompetitions = team.RunningCompetitions;
                    existingTeam.Squad = team.Squad;
                    existingTeam.CoachId = team.CoachId;
                    existingTeam.Coach = team.Coach;
                    existingTeam.LastUpdated = team.LastUpdated;
                }
                return existingTeam;
            });
        }

        public Task<Team> GetByIdAsync(int id)
        {
            return Task.Run(() => _db.Teams.FirstOrDefault(t => t.Id == id));
        }

        public Task<IEnumerable<Team>> GetAllAsync()
        {
            return Task.Run(() => _db.Teams.AsEnumerable());
        }

        public Task RemoveAsync(int id)
        {
            return Task.Run(() =>
            {
                var team = _db.Teams.FirstOrDefault(t => t.Id == id);
                if (team != null)
                {
                    _db.Teams.Remove(team);
                }
            });
        }
    }
}

