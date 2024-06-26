﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public string? Position { get; set; }
        public int? ShirtNumber { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CurrentTeamId { get; set; }
        public Team? CurrentTeam { get; set; }
    }
}
