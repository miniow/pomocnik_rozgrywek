using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IPearsonService
    {
        Pearson GetPearsonById(int id);
        IEnumerable<Pearson> GetAllPearsons();
        void CreatePearson(Pearson pearson);
        void UpdatePearson(Pearson pearson);
        void DeletePearson(int id);
    }
}
