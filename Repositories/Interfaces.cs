using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public interface IAreaRepository
    {
        Task<Area> AddAsync(Area area);
        Task<Area> EditAsync(Area area);
        Task<IEnumerable<Area>> GetAllAsync();
        Task<Area> GetRootAsync();
        Task<Area> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }

    public interface ICompetitionRepository
    {
        Task<Competition> AddAsync(Competition competition);
        Task<Competition> EditAsync(Competition competition);
        Task<IEnumerable<Competition>> GetAllAsync();
        Task<Competition> GetByIdAsync(int id);
        Task RemoveAsync(int id);
        Task<int> GetNumberOfTeamsInCompetitionAsync(Competition competition);
        Task<IEnumerable<Team>> GetAllTeamsAsync(Competition competition);
        Task RemoveFromTournamentAsync(Team losingTeam);
    }

    public interface IMatchRepository
    {
        Task<Match> AddAsync(Match match);
        Task<Match> EditAsync(Match match);
        Task RemoveAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<IEnumerable<Match>> GetAllAsync();
        Task AddMatchesAsync(List<Match> matches);
    }

    public interface IPersonRepository
    {
        Task<Person> AddAsync(Person player);
        Task<Person> EditAsync(Person player);
        Task RemoveAsync(int id);
        Task<Person> GetByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllAsync();
    }

    public interface ISeasonRepository
    {
        Task<Season> AddAsync(Season season);
        Task<Season> EditAsync(Season season);
        Task<IEnumerable<Season>> GetAllAsync();
        Task<Season> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }

    public interface ITeamRepository
    {
        Task<Team> AddAsync(Team team);
        Task<Team> EditAsync(Team team);
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
