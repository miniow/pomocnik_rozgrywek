using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Data
{
    public class Database
    {
        private static Database? _instance;
        private static readonly object _lock = new object();

        public List<Area> Areas { get; private set; } = new List<Area>();
        public List<Competition> Competitions { get; private set; } = new List<Competition>();
        public List<Match> Matches { get; private set; } = new List<Match>();
        public List<MatchStatistic> MatchStatistics { get; private set; } = new List<MatchStatistic>();
        public List<Person> People { get; private set; } = new List<Person>();
        public List<Season> Seasons { get; private set; } = new List<Season>();
        public List<Team> Teams { get; private set; } = new List<Team>();

        private Database() { }

        public static Database Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Database();
                    }
                    return _instance;
                }
            }
        }
    }

    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            var db = Database.Instance;

            var area1 = new Area { Id = 1, Name = "Europe", Code = "EU", Flag = "https://esport.grypciocraft.pl/static/img/grp-esports-logo.png" };
            var area2 = new Area { Id = 2, Name = "Asia", Code = "AS", Flag = "asia_flag.png" };
            db.Areas.AddRange(new[] { area1, area2 });

            // Initialize Competitions
            var competition1 = new Competition { Id = 1, Name = "UEFA Champions League", Code = "UCL", Type = "League", Emblem = "ucl_emblem.png", Area = area1 };
            var competition2 = new Competition { Id = 2, Name = "AFC Champions League", Code = "AFC", Type = "League", Emblem = "afc_emblem.png", Area = area2 };
            db.Competitions.AddRange(new[] { competition1, competition2 });

            // Initialize Teams
            var team1 = new Team { Id = 1, Name = "Real Madrid", ShortName = "RMA", Tla = "RMA", Crest = "real_madrid.png", Founded = 1902, ClubColors = "White", Venue = "Santiago Bernabéu" };
            var team2 = new Team { Id = 2, Name = "Al Hilal", ShortName = "HIL", Tla = "HIL", Crest = "al_hilal.png", Founded = 1957, ClubColors = "Blue", Venue = "King Fahd Stadium" };
            var team3 = new Team { Id = 1, Name = "Real Madrid", ShortName = "RMA", Tla = "RMA", Crest = "real_madrid.png", Founded = 1902, ClubColors = "White", Venue = "Santiago Bernabéu" };
            var team4 = new Team { Id = 2, Name = "Al Hilal", ShortName = "HIL", Tla = "HIL", Crest = "al_hilal.png", Founded = 1957, ClubColors = "Blue", Venue = "King Fahd Stadium" };
            db.Teams.AddRange(new[] { team1, team2 ,team3, team4});

            // Initialize People (Players and Coaches)
            var player1 = new Person { Id = 1, FirstName = "Karim", LastName = "Benzema", DateOfBirth = "1987-12-19", Nationality = "French", Position = "Forward", ShirtNumber = 9, CurrentTeam = team1 };
            var player2 = new Person { Id = 2, FirstName = "Salem", LastName = "Al-Dawsari", DateOfBirth = "1991-08-19", Nationality = "Saudi Arabian", Position = "Midfielder", ShirtNumber = 29, CurrentTeam = team2 };
            db.People.AddRange(new[] { player1, player2 });

            // Initialize Seasons
            var season1 = new Season { Id = 1, StartDate = new DateOnly(2023, 8, 1), EndDate = new DateOnly(2024, 5, 31), CurrentMatchday = 1, Competitions = new List<Competition> { competition1 } };
            var season2 = new Season { Id = 2, StartDate = new DateOnly(2023, 9, 1), EndDate = new DateOnly(2024, 4, 30), CurrentMatchday = 1, Competitions = new List<Competition> { competition2 } };
            db.Seasons.AddRange(new[] { season1, season2 });

            // Initialize Matches
            var match1 = new Match
            {
                Id = 1,
                Competition = competition1,
                UtcDate = DateTime.UtcNow,
                Status = MatchStatus.SCHEDULED,
                Minute = 0,
                InjuryTime = 0,
                Attendance = 0,
                Venue = "Santiago Bernabéu",
                Matchday = 1,
                Stage = CompetitionStage.FINAL,
                HomeTeam = team1,
                AwayTeam = team2,
                HomeStatistic = new MatchStatistic { Id = 1 },
                AwayStatistic = new MatchStatistic { Id = 2 }
            };

            db.Matches.Add(match1);

            // Initialize Match Statistics
            var matchStatistic1 = new MatchStatistic { Id = 1, CornerKicks = 0, FreeKicks = 0, GoalKicks = 0, Offsides = 0, Fouls = 0, BallPossession = 50, Saves = 0, ThrowIns = 0, Shots = 0, ShotsOnGoal = 0, ShotsOffGoal = 0, YellowCards = 0, RedCards = 0 };
            var matchStatistic2 = new MatchStatistic { Id = 2, CornerKicks = 0, FreeKicks = 0, GoalKicks = 0, Offsides = 0, Fouls = 0, BallPossession = 50, Saves = 0, ThrowIns = 0, Shots = 0, ShotsOnGoal = 0, ShotsOffGoal = 0, YellowCards = 0, RedCards = 0 };
            db.MatchStatistics.AddRange(new[] { matchStatistic1, matchStatistic2 });

            // Assign statistics to the match
            match1.HomeStatistic = matchStatistic1;
            match1.AwayStatistic = matchStatistic2;
        }

    }
}
