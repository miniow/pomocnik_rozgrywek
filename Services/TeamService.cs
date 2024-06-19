using Microsoft.Identity.Client;
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
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IPersonRepository _personRepository;
        private readonly ICompetitionRepository _competitionRepository;
        public TeamService() {
            _teamRepository = new TeamRepository();
            _personRepository = new PersonRepository();
            _competitionRepository = new CompetitionRepository();
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

        public async Task AddTeamToCometiton(Team team, Competition competition)
        {
            var teamDTO = await _teamRepository.GetByIdAsync(team.Id);
            var competitionDTO = await _competitionRepository.GetByIdAsync(competition.Id);

            if (teamDTO.RunningCompetitions == null)
            {
                teamDTO.RunningCompetitions = new List<Competition>();
            }

            if (competitionDTO.Teams == null)
            {
                competitionDTO.Teams = new List<Team>();
            }

            if (!teamDTO.RunningCompetitions.Any(c => c.Id == competitionDTO.Id))
            {
                teamDTO.RunningCompetitions.Add(competitionDTO);
            }

            if (!competitionDTO.Teams.Any(t => t.Id == teamDTO.Id))
            {
                competitionDTO.Teams.Add(teamDTO);
            }

            await _teamRepository.EditAsync(teamDTO);
            await _competitionRepository.EditAsync(competitionDTO);
        }
    }
}
