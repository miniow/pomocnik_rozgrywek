using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public enum MatchType
    {
        QuaterFinal,
        SemiFinal,
        Final
    }
    public class Match
    {
        public int MatchID { get; set; }
        public MatchType Type {  get; set; }
        public Team TeamA { get; set; }
        public Team TeamB { get; set; }
        public int TeamAScore { get; set; }
        public int TeamBScore { get; set; }
        public DateTime Time { get; set; }

        public Tournament Tournament { get; set; }
        public int TournamentID { get; set; }
    }
}
