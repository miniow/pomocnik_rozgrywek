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
        public int CornerKicks { get; set; }
        public int FreeKicks { get; set; }
        public int GoalKicks { get; set; }
        public int Offsides { get; set; }
        public int Fouls { get; set; }
        public int BallPossession { get; set; }
        public int Saves { get; set; }
        public int ThrowIns { get; set; }
        public int Shots { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }

    }

}
