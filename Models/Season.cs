using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public class Season
    {
        public int Id { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int CurrentMatchday { get; set; }
        public Team? Winner {  get; set; }
        public CompetitionStage? Stages { get; set; }
    }
}
