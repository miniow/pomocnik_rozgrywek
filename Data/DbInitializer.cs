using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Areas.Any())
            {
                return;
            }

            var europe = new Area
            {
                Name = "Europe",
                Code = "EUR",
                Flag = "https://flagcdn.com/16x12/pl.webp",
                ParentAreaId = null,
                ParentArea = "World",
                ChildAreas = new List<Area>
            {
                new Area
                {
                    Name = "Albania",
                    Code = "ALB",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Andorra",
                    Code = "AND",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Armenia",
                    Code = "ARM",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Austria",
                    Code = "AUT",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Wales",
                    Code = "WAL",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                }
            }
            };

            context.Areas.Add(europe);
            context.SaveChanges();
        }
    }
}
