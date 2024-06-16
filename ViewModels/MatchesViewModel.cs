using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public class MatchesViewModel : ViewModelBase
    {
        private readonly IMatchService _matchService;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }
        private ObservableCollection<Match> _matches;
        private Match _selectedMatch;
        public Match SelectedMatch
        {
            get { return _selectedMatch; }
            set
            {
                _selectedMatch = value;
                OnPropertyChanged(nameof(SelectedMatch));
            }
        }
        public ICommand LoadMatchesCommand { get; }
        public ICommand AddMatchCommand { get; }
        public ICommand UpdateMatchCommand { get; }
        public ICommand DeleteMatchCommand { get; }
        public MatchesViewModel() {
            _matchService = new MatchService();

            LoadMatchesCommand = new ViewModelCommand(async param => await LoadMatches());
            AddMatchCommand = new ViewModelCommand(async param => await AddMatch(param as Match));
            UpdateMatchCommand = new ViewModelCommand(async param => await UpdateMatch(param as Match));
            DeleteMatchCommand = new ViewModelCommand(async param => await DeleteMatch(param as Match));
            LoadMatches();
        }
        private async Task LoadMatches()
        {
            Matches = new ObservableCollection<Match>(await _matchService.GetAllMatchsAsync());
        }

        private async Task AddMatch(Match match)
        {

            var addedMatch = await _matchService.CreateMatchAsync(match);
            Matches.Add(addedMatch);
        }

        private async Task UpdateMatch(Match match)
        {
            if (SelectedMatch != null)
            {
                var updatedMatch = await _matchService.UpdateMatchAsync(SelectedMatch);
            }
        }

        private async Task DeleteMatch(Match match)
        {
            if (SelectedMatch != null)
            {
                await _matchService.DeleteMatchAsync(SelectedMatch.Id);
                Matches.Remove(SelectedMatch);
            }
        }
    }
}
