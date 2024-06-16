using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
   
    public enum Group
    {
        GROUP_A,
        GROUP_B,
        GROUP_C,
        GROUP_D,
        GROUP_E,
        GROUP_F,
        GROUP_G,
        GROUP_H,
    }
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
        SCHEDULED,
        TIMED,
        IN_PLAY,
        PAUSED,
        FINISHED,
        SUSPENDED,
        POSTPONED,
        CANCELLED,
        AWARDED
    }
}
