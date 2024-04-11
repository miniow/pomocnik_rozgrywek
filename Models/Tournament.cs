using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Tournament
    {

        public int TournamentID { get; set; }
        public string TournamentName { get; set; }

        public ICollection<Team> Teams { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
