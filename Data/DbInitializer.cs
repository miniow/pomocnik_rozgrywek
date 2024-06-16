using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            if (!context.Areas.Any())
            {
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
                var usa = new Area
                {
                    Name = "North America",
                    Code = "NA",
                    Flag = "https://flagcdn.com/16x12/pl.webp",
                    ParentAreaId = null,
                    ParentArea = "World",
                    ChildAreas = new List<Area>
            {
                new Area
                {
                    Name = "USA",
                    Code = "US",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Mexico",
                    Code = "MEX",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                },
                new Area
                {
                    Name = "Canada",
                    Code = "CN",
                    Flag = "https://flagcdn.com/16x12/pl.webp"
                }
            }
                };
                context.Areas.Add(europe);
                context.Areas.Add(usa);
                context.SaveChanges();
            }
            if (!context.Seasons.Any())
            {
                var seasons = new Season[]
                {
                    new Season { StartDate = new DateOnly(2024, 11, 11), EndDate = new DateOnly(2024, 12, 12), CurrentMatchday = 14, Stages = CompetitionStage.QUARTER_FINALS },
                    new Season { StartDate = new DateOnly(2024, 9, 9), EndDate = new DateOnly(2025, 6, 3), CurrentMatchday = 0, Stages = CompetitionStage.GROUP_STAGE }
                };
                foreach (Season s in seasons)
                {
                    context.Seasons.Add(s);
                }
                context.SaveChanges();
            }

            



        }
    }
}
