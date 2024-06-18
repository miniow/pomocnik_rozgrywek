using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
   
    public enum CompetitionStage
    {
        FINAL,
        THIRD_PLACE,
        SEMI_FINALS,
        QUARTER_FINALS,
        GROUP_STAGE,
        REGULAR_SEASON, 
    }
    public enum MatchStatus
    {
        NONE,
        SCHEDULED,
        PLAYING,
        ENDED
    }
}
