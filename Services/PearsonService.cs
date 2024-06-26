﻿using Microsoft.IdentityModel.Tokens;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;

using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services
{
    class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITeamRepository _teamRepository;
        public PersonService()
        {
            _personRepository = new PersonRepository();
            _teamRepository = new TeamRepository();
        }
        public async Task<Person> CreatePersonAsync(Person player)
        {
            return await _personRepository.AddAsync(player);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAllPersonAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task<Person> UpdatePersonAsync(Person player)
        {
            return await _personRepository.EditAsync(player);
        }

        public async Task AddToTeam(Person player, Team team)
        {
            if (team.Squad.IsNullOrEmpty())
            {
                team.Squad = new List<Person>();
            }
            player.CurrentTeam = team;
            team.Squad.Add(player);
            await _teamRepository.EditAsync(team);
            await _personRepository.EditAsync(player);
            return;
        }

        public async Task AppointAsCoach(Person person, Team team)
        {
            team.Coach = person;
            person.CurrentTeam = team;
            await _teamRepository.EditAsync(team);
            await _personRepository.EditAsync(person);
            return;
        }
    }
}
