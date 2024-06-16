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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPersonRepository _personRepository;
        public TeamService() {
            _teamRepository = new TeamRepository(new Data.ApplicationDbContext());
            _personRepository = new PersonRepository(new Data.ApplicationDbContext());
        }
        public async Task<Team> GetTeamByIdAsync(int id)
        {
            return await _teamRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamRepository.GetAllAsync();
        }

        public async Task<Team> CreateTeamAsync(Team team)
        {

            return await _teamRepository.AddAsync(team);
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            return await _teamRepository.EditAsync(team);
        }

        public async Task DeleteTeamAsync(int id)
        {
            await _teamRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Person>> GetTeamPlayersAsync(int teamId)
        {

            return await _personRepository.GetAllAsync();
        }

        public async Task AddPlayerToTeamAsync(Team team, Person person)
        {
            if(team.Squad == null)
            {
                throw new NullReferenceException("Team Squad not initialized");
            }
            team.Squad.Add(person);
            person.CurrentTeam = team;
            await _personRepository.EditAsync(person);
            await _teamRepository.EditAsync(team);
        }

        public async Task AddCoachToTeamAsync(Team team, Person coach)
        {
            team.Coach = coach;
            await _teamRepository.EditAsync(team);
        }

        public async Task RemovePlayerFromTeamAsync(Team team, Person person)
        {
            if (team.Squad == null)
            {
                throw new NullReferenceException("Team Squad not initialized");
            }
            team.Squad.Remove(person);
            await _teamRepository.EditAsync(team);
        }

        public async Task RemoveCoachFromTeamAsync(Team team)
        {
            team.Coach = null;
            await _teamRepository.EditAsync(team);
        }

    }
}
