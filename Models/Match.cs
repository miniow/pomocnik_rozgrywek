using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Match
    {
        public Area Area { get; set; }
        public Competition Competition { get; set; }
        public Season Season { get; set; }

        public int Id { get; set; }
        public DateTime utcDate { get; set; }
        public Status Status { get; set; }
        public int Minute {  get; set; }
        public int InjuryTime {  get; set; }
        public int Attendance { get; set; }
        public string Venue { get; set; }
        public int Matchday { get; set; }
        public Stage Stage { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

    }
}
