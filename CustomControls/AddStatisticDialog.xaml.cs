using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pomocnik_Rozgrywek.CustomControls
{
    /// <summary>
    /// Logika interakcji dla klasy AddStatisticDialog.xaml
    /// </summary>
    public partial class AddStatisticDialog : Window, INotifyPropertyChanged
    {
        private DispatcherTimer _timer;
        private int _timeRemaining;
        public int HomeGoals { get; set; }
        public int HomeYellowCards { get; set; }
        public int HomeRedCards { get; set; }

        public int AwayGoals { get; set; }
        public int AwayYellowCards { get; set; }
        public int AwayRedCards { get; set; }
        public ObservableCollection<EventType> EventTypes { get; set; }
        public string TimerValue { get; set; }
        private ObservableCollection<Person> _homeTeam;
        private ObservableCollection<Person> _awayTeam;
        private Person _selectedHomePlayer;
        private Person _selectedAwayPlayer;

        public ObservableCollection<Person> HomeTeam { get { return _homeTeam; } set { _homeTeam = value; OnPropertyChanged(nameof(HomeTeam)); } }
        public ObservableCollection<Person> AwayTeam { get { return _awayTeam; } set { _awayTeam = value; OnPropertyChanged(nameof(AwayTeam)); } }
        public Person SelectedHomePlayer
        {
            get { return _selectedHomePlayer; }
            set { _selectedHomePlayer = value; OnPropertyChanged(nameof(SelectedHomePlayer)); }
        }

        public Person SelectedAwayPlayer
        {
            get { return _selectedAwayPlayer; }
            set { _selectedAwayPlayer = value; OnPropertyChanged(nameof(SelectedAwayPlayer)); }
        }
        public MatchStatistic HomeStatistic { get; private set ; }
        public MatchStatistic AwayStatistic { get; private set; }
        public Match match { get; set; }
        public AddStatisticDialog(Match matchl)
        {
            InitializeComponent();
            DataContext = this;

            HomeGoals = 0;
            HomeYellowCards = 0;
            HomeRedCards = 0;

            AwayGoals = 0;
            AwayYellowCards = 0;
            AwayRedCards = 0;
            try
            {
                HomeTeam = new ObservableCollection<Person>(matchl.HomeTeam.Squad);
                AwayTeam = new ObservableCollection<Person>(matchl.AwayTeam.Squad);
            }
            catch (Exception ex)
            {
                HomeTeam = new ObservableCollection<Person>();
                AwayTeam = new ObservableCollection<Person>();
            }

            EventTypes = new ObservableCollection<EventType>(Enum.GetValues(typeof(EventType)) as EventType[]);
            _timeRemaining = 90;
            TimerValue = _timeRemaining.ToString();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();

            HomeStatistic = new MatchStatistic();
            AwayStatistic = new MatchStatistic();
            this.match = matchl;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timeRemaining--;
            TimerValue = _timeRemaining.ToString();
            OnPropertyChanged(nameof(TimerValue));

            if (_timeRemaining == 0)
            {
                _timer.Stop();
                MessageBox.Show("Time's up! Please save your statistics.", "Timer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddAwayEventButton_Click(object sender, RoutedEventArgs e)
        {
            var eventType = (EventType)awayEventType_cb.SelectedItem;
            var minute = _timeRemaining;

            var matchEvent = new MatchEvent
            {
                Minute = minute,
                Type = eventType,
                Player = SelectedAwayPlayer 
            };
            switch (eventType)
            {
                case EventType.Goal:
                    AwayGoals++;
                    awayGoalKicks_tb.Text = AwayGoals.ToString();
                    break;
                case EventType.YellowCard:
                    AwayYellowCards++;
                    awayYellowCards_tb.Text = AwayYellowCards.ToString();
                    break;
                case EventType.RedCard:
                    AwayRedCards++;
                    awayRedCards_tb.Text = AwayRedCards.ToString();
                    break;
            }
            AwayStatistic.Events.Add(matchEvent);
        }

        private void AddHomeEventButton_Click(object sender, RoutedEventArgs e)
        {
            var eventType = (EventType)homeEventType_cb.SelectedItem;
            var minute = _timeRemaining;

            var matchEvent = new MatchEvent
            {
                Minute = minute,
                Type = eventType,
                Player = SelectedHomePlayer 
            };
            switch (eventType)
            {
                case EventType.Goal:
                    HomeGoals++;
                    homeGoalKicks_tb.Text = HomeGoals.ToString();
                    break;
                case EventType.YellowCard:
                    HomeYellowCards++;
                    homeYellowCards_tb.Text = HomeYellowCards.ToString();
                    break;
                case EventType.RedCard:
                    HomeRedCards++;
                    homeRedCards_tb.Text = HomeRedCards.ToString();
                    break;
            }
            HomeStatistic.Events.Add(matchEvent);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            HomeStatistic.Goals = HomeGoals;
            //HomeStatistic.BallPossession = 
            HomeStatistic.YellowCards = HomeYellowCards;
            HomeStatistic.RedCards = HomeRedCards;

            AwayStatistic.Goals = AwayGoals;
            //AwayStatistic.BallPossession = 
            AwayStatistic.YellowCards = AwayYellowCards;
            AwayStatistic.RedCards = AwayRedCards;

            DialogResult = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
