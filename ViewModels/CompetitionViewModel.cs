using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public CompetitionViewModel()
        {
            _competitionService = new CompetitionService();
            LoadCompetitions();
        }
        private async void LoadCompetitions()
        {

            Competitions = new ObservableCollection<Competition>(await _competitionService.GetAllCompetitionsAsync());
        }
    }
}
