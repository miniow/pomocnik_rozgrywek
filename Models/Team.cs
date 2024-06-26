﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pomocnik_Rozgrywek.Models
{
    public class Team
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public string? Tla { get; set; }
        public string? Crest { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public int? Founded { get; set; }
        public string? ClubColors { get; set; }
        public string? Venue { get; set; }
        public ICollection<Competition>? RunningCompetitions { get; set; }
        public ICollection<Person>? Squad { get; set; }
        public int? CoachId { get; set; }
        public Person? Coach { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
