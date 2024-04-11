using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class TournamentTeam
    {
        public int TournamentID { get; set; }
        public Tournament Tournament { get; set; }

        public int TeamID { get; set; }
        public Team Team { get; set; }
    }
}
