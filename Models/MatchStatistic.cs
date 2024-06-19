using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
   public class MatchStatistic
    {
        public int Id { get; set; }
        public int Goals { get; set; }
        public int BallPossession { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public List<MatchEvent> Events { get; set; }
        public MatchStatistic()
        {
            Events = new List<MatchEvent>();
        }

    }

}
