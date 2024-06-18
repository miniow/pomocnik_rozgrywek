using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Match
    {
        public Competition Competition { get; set; }

        public int Id { get; set; }
        public DateTime utcDate { get; set; }
        public MatchStatus Status { get; set; }
        public int Minute { get; set; }
        public int InjuryTime { get; set; }
        public int Attendance { get; set; }
        public string Venue { get; set; }
        public int Matchday { get; set; }
        public CompetitionStage Stage { get; set; }
        public Team HomeTeam { get; set; }
        public MatchStatistic? HomeStatistic { get; set; }
        public int HomeStatisticId { get; set; }
        public Team AwayTeam { get; set; }
        public MatchStatistic? AwayStatistic { get; set; }
        public int AwayStatisticId { get; set; }

    }
}
