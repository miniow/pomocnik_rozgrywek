using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public ICollection<Player> Players { get; set; }

        public ICollection<TournamentTeam> Tournaments { get; set; }
    }
}
