using Pomocnik_Rozgrywek.CustomControls;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly ICompetitionService _competitionService;
        private ObservableCollection<Competition> _competitions;
        private Competition _selectedCompetition;

        public ObservableCollection<Competition> Competitions
        {
            get { return _competitions; }
            set
            {
                _competitions = value;
                OnPropertyChanged(nameof(Competitions));
            }
        }

        public Competition SelectedCompetition
        {
            get { return _selectedCompetition; }
            set
            {
                _selectedCompetition = value;
                OnPropertyChanged(nameof(SelectedCompetition));
            }
        }


        public ICommand LoadCompetitionsCommand { get; }
        public ICommand AddCompetitionCommand { get; }
        public ICommand UpdateCompetitionCommand { get; }
        public ICommand DeleteCompetitionCommand { get; }
        public ICommand OpenAddCompetitionDialogCommand { get; }


        public CompetitionViewModel()
        {
            _competitionService = new CompetitionService();
            OpenAddCompetitionDialogCommand = new ViewModelCommand(async param => await OpenAddCompetitionDialog(param));
            LoadCompetitionsCommand = new ViewModelCommand(async param => await LoadCompetitions());
            AddCompetitionCommand = new ViewModelCommand(async param => await AddCompetition(param as Competition));
            UpdateCompetitionCommand = new ViewModelCommand(async param => await UpdateCompetition(param as Competition));
            DeleteCompetitionCommand = new ViewModelCommand(async param => await DeleteCompetition(param as Competition));
            LoadCompetitions();
        }
        private async Task OpenAddCompetitionDialog(object parameter)
        {
            var seasons = new ObservableCollection<Season>( await _competitionService.GetSeasonsAsync());
            var dialog = new AddCompetitionDialog(seasons);
            dialog.OnCompetitionCreated += competition =>
            {
                AddCompetition(competition).Wait();
            };
            dialog.ShowDialog();
        }
        private Task DeleteCompetition(Competition? competition)
        {
            throw new NotImplementedException();
        }

        private Task UpdateCompetition(Competition? competition)
        {
            throw new NotImplementedException();
        }

        private async Task AddCompetition(Competition? competition)
        {
            await _competitionService.CreateTournamentAsync(competition);
        }

        private async Task LoadCompetitions()
        {
            Competitions = new ObservableCollection<Competition>(await _competitionService.GetAllCompetitionsAsync());
            var a = "dsagf";
        }
    }
}
