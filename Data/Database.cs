using Newtonsoft.Json;
using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

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
        public List<MatchEvent> MatchEvents { get; private set; } = new List<MatchEvent> { };
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

        public void SaveToFile()
        {
            var filePath = "C:\\Users\\jonta\\OneDrive\\Pulpit\\database.json";
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };
            var json = JsonConvert.SerializeObject(this, settings);
            File.WriteAllText(filePath, json);
        }

        public static void LoadFromFile()
        {
            var filePath = "C:\\Users\\jonta\\OneDrive\\Pulpit\\database.json";
            var json = File.ReadAllText(filePath);
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            _instance = JsonConvert.DeserializeObject<Database>(json, settings);

        }



    }


    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            var db = Database.Instance;

            var area1 = new Area { Id = 1, Name = "Europe", Code = "EU", Flag = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//Flag_of_Europe.svg.png" };
            var area2 = new Area { Id = 2, Name = "Asia", Code = "AS", Flag = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//Flag_of_Asia.png"};
            db.Areas.AddRange(new[] { area1, area2 });

            // Initialize Competitions
            var competition1 = new Competition { Id = 1, Name = "UEFA Champions League", Code = "UCL", Type = "League", Emblem = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//ucl_emblem.png", Area = area1 };
            var competition2 = new Competition { Id = 2, Name = "AFC Champions League", Code = "AFC", Type = "League", Emblem = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//afc-emblem.jpg", Area = area2 };
            db.Competitions.AddRange(new[] { competition1, competition2 });

            // Initialize Teams
            var team1 = new Team { Id = 1, Name = "Real Madrid", ShortName = "RMA", Tla = "RMA", Crest = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//Real-Madryt-logo.jpg", Founded = 1902, ClubColors = "White", Venue = "Santiago Bernabéu" };
            var team2 = new Team { Id = 2, Name = "Al Hilal", ShortName = "HIL", Tla = "HIL", Crest = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//alhilal.png", Founded = 1957, ClubColors = "Blue", Venue = "King Fahd Stadium" };
            var team3 = new Team { Id = 3, Name = "Barcelona", ShortName = "BAR", Tla = "BAR", Crest = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//FC_Barcelona.svg.png", Founded = 1899, ClubColors = "Blue and Claret", Venue = "Camp Nou" };
            var team4 = new Team { Id = 4, Name = "Bayern Munich", ShortName = "BAY", Tla = "BAY", Crest = "C://Users//jonta//OneDrive//Pulpit//śmieszne pliki//FC_Bayern.svg.png", Founded = 1900, ClubColors = "Red and White", Venue = "Allianz Arena" };



            var player1 = new Person { Id = 1, FirstName = "Karim", LastName = "Benzema", DateOfBirth = "1987-12-19", Nationality = "French", Position = "Forward", ShirtNumber = 9, CurrentTeam = team1 };
            var player2 = new Person { Id = 2, FirstName = "Luka", LastName = "Modrić", DateOfBirth = "1985-09-09", Nationality = "Croatian", Position = "Midfielder", ShirtNumber = 10, CurrentTeam = team1 };
            var player3 = new Person { Id = 3, FirstName = "Thibaut", LastName = "Courtois", DateOfBirth = "1992-05-11", Nationality = "Belgian", Position = "Goalkeeper", ShirtNumber = 1, CurrentTeam = team1 };
            var player4 = new Person { Id = 4, FirstName = "Sergio", LastName = "Ramos", DateOfBirth = "1986-03-30", Nationality = "Spanish", Position = "Defender", ShirtNumber = 4, CurrentTeam = team1 };
            var player5 = new Person { Id = 5, FirstName = "Federico", LastName = "Valverde", DateOfBirth = "1998-07-22", Nationality = "Uruguayan", Position = "Midfielder", ShirtNumber = 15, CurrentTeam = team1 };

            var player6 = new Person { Id = 6, FirstName = "Salem", LastName = "Al-Dawsari", DateOfBirth = "1991-08-19", Nationality = "Saudi Arabian", Position = "Midfielder", ShirtNumber = 29, CurrentTeam = team2 };
            var player7 = new Person { Id = 7, FirstName = "Bafétimbi", LastName = "Gomis", DateOfBirth = "1985-08-06", Nationality = "French", Position = "Forward", ShirtNumber = 18, CurrentTeam = team2 };
            var player8 = new Person { Id = 8, FirstName = "Mohammed", LastName = "Al-Breik", DateOfBirth = "1992-09-15", Nationality = "Saudi Arabian", Position = "Defender", ShirtNumber = 2, CurrentTeam = team2 };
            var player9 = new Person { Id = 9, FirstName = "Abdullah", LastName = "Otayf", DateOfBirth = "1992-08-03", Nationality = "Saudi Arabian", Position = "Midfielder", ShirtNumber = 8, CurrentTeam = team2 };
            var player10 = new Person { Id = 10, FirstName = "Salman", LastName = "Al-Faraj", DateOfBirth = "1989-08-01", Nationality = "Saudi Arabian", Position = "Midfielder", ShirtNumber = 7, CurrentTeam = team2 };

            var player11 = new Person { Id = 11, FirstName = "Lionel", LastName = "Messi", DateOfBirth = "1987-06-24", Nationality = "Argentinian", Position = "Forward", ShirtNumber = 10, CurrentTeam = team3 };
            var player12 = new Person { Id = 12, FirstName = "Sergio", LastName = "Busquets", DateOfBirth = "1988-07-16", Nationality = "Spanish", Position = "Midfielder", ShirtNumber = 5, CurrentTeam = team3 };
            var player13 = new Person { Id = 13, FirstName = "Gerard", LastName = "Piqué", DateOfBirth = "1987-02-02", Nationality = "Spanish", Position = "Defender", ShirtNumber = 3, CurrentTeam = team3 };
            var player14 = new Person { Id = 14, FirstName = "Marc-André", LastName = "ter Stegen", DateOfBirth = "1992-04-30", Nationality = "German", Position = "Goalkeeper", ShirtNumber = 1, CurrentTeam = team3 };
            var player15 = new Person { Id = 15, FirstName = "Antoine", LastName = "Griezmann", DateOfBirth = "1991-03-21", Nationality = "French", Position = "Forward", ShirtNumber = 17, CurrentTeam = team3 };

            var player16 = new Person { Id = 16, FirstName = "Robert", LastName = "Lewandowski", DateOfBirth = "1988-08-21", Nationality = "Polish", Position = "Forward", ShirtNumber = 9, CurrentTeam = team4 };
            var player17 = new Person { Id = 17, FirstName = "Joshua", LastName = "Kimmich", DateOfBirth = "1995-02-08", Nationality = "German", Position = "Midfielder", ShirtNumber = 6, CurrentTeam = team4 };
            var player18 = new Person { Id = 18, FirstName = "Manuel", LastName = "Neuer", DateOfBirth = "1986-03-27", Nationality = "German", Position = "Goalkeeper", ShirtNumber = 1, CurrentTeam = team4 };
            var player19 = new Person { Id = 19, FirstName = "Thomas", LastName = "Müller", DateOfBirth = "1989-09-13", Nationality = "German", Position = "Forward", ShirtNumber = 25, CurrentTeam = team4 };
            var player20 = new Person { Id = 20, FirstName = "Alphonso", LastName = "Davies", DateOfBirth = "2000-11-02", Nationality = "Canadian", Position = "Defender", ShirtNumber = 19, CurrentTeam = team4 };

            var players = new List<Person>();
            var players2 = new List<Person>();
            players.AddRange(new[]
 {
    player1, player2, player3, player4, player5, player6, player7,
    player8, player9, player10, player11, player12, player13,
    player14, player15, player16, player17, player18, player19, player20
});

            team1.Squad = players;
            team2.Squad = players2;
            db.Teams.AddRange(new[] { team1, team2, team3, team4 });
            db.People.AddRange(new[]
{
    player1, player2, player3, player4, player5, player6, player7,
    player8, player9, player10, player11, player12, player13,
    player14, player15, player16, player17, player18, player19, player20
});

            // Initialize Seasons
            var season1 = new Season { Id = 1, StartDate = new DateOnly(2023, 8, 1), EndDate = new DateOnly(2024, 5, 31), CurrentMatchday = 1, Competitions = new List<Competition> { competition1 } };
            var season2 = new Season { Id = 2, StartDate = new DateOnly(2023, 9, 1), EndDate = new DateOnly(2024, 4, 30), CurrentMatchday = 1, Competitions = new List<Competition> { competition2 } };
            db.Seasons.AddRange(new[] { season1, season2 });
        



       
        }


    }
}
