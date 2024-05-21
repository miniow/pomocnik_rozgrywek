using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Models
{
    
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Flag { get; set; }
        public int ParentAreaId { get; set; }
        public string ParentArea { get; set; }
        public ICollection<Area> ChildAreas { get; set;}
    }
}
