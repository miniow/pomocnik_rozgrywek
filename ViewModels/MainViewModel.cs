using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FontAwesome.Sharp;


namespace Pomocnik_Rozgrywek.ViewModels
{
    public class ChangeViewEventArgs : EventArgs
    {
        public string ViewName { get; set; }
    }
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;  
        private IconChar _icon;

        public ViewModelBase CurrentChildView { get { return _currentChildView; } set { _currentChildView = value; OnPropertyChanged(nameof(CurrentChildView)); }}
        public string Caption { get { return _caption; } set { _caption = value; OnPropertyChanged(nameof(Caption)); } }
        public IconChar Icon { get { return _icon; } set { _icon = value;OnPropertyChanged(nameof(Icon)); } }

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowAreaViewCommand { get; }
        public ICommand ShowCompetitionViewCommand { get; }
        public ICommand ShowTeamViewCommand { get; }
        public ICommand ShowPearsonViewCommand { get; }
        public ICommand ShowMatchViewCommand { get; }
        public ICommand ShowSeasonViewCommand { get; }

        public MainViewModel()
        {
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowAreaViewCommand = new ViewModelCommand(ExecuteShowAreaViewCommand);
            ShowCompetitionViewCommand = new ViewModelCommand(ExecuteShowCompetitionViewCommand);
            ShowTeamViewCommand = new ViewModelCommand(ExecuteShowTeamViewCommand);
            ShowPearsonViewCommand = new ViewModelCommand(ExecuteShowPearsonViewCommand);
            ShowMatchViewCommand = new ViewModelCommand(ExecuteShowMatchViewCommand);
            ShowSeasonViewCommand = new ViewModelCommand(ExecuteShowSeasonViewCommand);

        }

        private void ExecuteShowSeasonViewCommand(object obj)
        {
            CurrentChildView = new SeasonViewModel();
            Caption = "Season";
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Home";
            Icon = IconChar.Home;
        }

        private void ExecuteShowMatchViewCommand(object obj)
        {
            CurrentChildView = new MatchesViewModel();
            Caption = "Matches";
            Icon = IconChar.Futbol;
        }

        private void ExecuteShowPearsonViewCommand(object obj)
        {
            CurrentChildView = new PearsonViewModel();
            Caption = "Pearson";
            Icon = IconChar.Person;
        }

        private void ExecuteShowTeamViewCommand(object obj)
        {
            CurrentChildView = new TeamViewModel();
            Caption = "Teams";
            Icon = IconChar.PeopleGroup;
        }

        private void ExecuteShowCompetitionViewCommand(object obj)
        {
            CurrentChildView = new CompetitionViewModel();
            Caption = "Competition";
            Icon = IconChar.Trophy;
        }

        private void ExecuteShowAreaViewCommand(object obj)
        {
            CurrentChildView = new AreaViewModel();
            Caption = "Areas";
            Icon = IconChar.Globe;
        }
    }
}
