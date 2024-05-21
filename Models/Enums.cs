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
        GROUP_I,
        GROUP_J,
        GROUP_K,
        GROUP_L
    }
    public enum Stage
    {
        FINAL,
        THIRD_PLACE,
        SEMI_FINALS,
        QUARTER_FINALS,
        LAST_16,
        LAST_32,
        LAST_64,
        ROUND_4,
        ROUND_3,
        ROUND_2,
        ROUND_1,
        GROUP_STAGE,
        PRELIMINARY_ROUND,
        QUALIFICATION,
        QUALIFICATION_ROUND_1,
        QUALIFICATION_ROUND_2,
        QUALIFICATION_ROUND_3,
        PLAYOFF_ROUND_1,
        PLAYOFF_ROUND_2,
        PLAYOFFS,
        REGULAR_SEASON,
        CLAUSURA,
        APERTURA,
        CHAMPIONSHIP_ROUND,
        RELEGATION_ROUND
    }
    public enum Status
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
