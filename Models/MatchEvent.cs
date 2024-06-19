using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    public enum EventType
    {
        Goal,
        YellowCard,
        RedCard
    }
    public class MatchEvent
    {
        public int Id { get; set; }
        public int Minute { get; set; }
        public EventType Type { get; set; }
        public Person Player { get; set; }
    }

    
}
