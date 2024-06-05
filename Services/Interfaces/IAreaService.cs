using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IAreaService
    {
        Area GetAreaById(int id);
        IEnumerable<Area> GetAllAreas();
        void CreateArea(Area area);
        void UpdateArea(Area area);
        void DeleteArea(int id);
    }
}
