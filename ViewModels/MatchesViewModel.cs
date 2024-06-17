﻿using Pomocnik_Rozgrywek.Models;
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
    public static class EnumHelper
    {
        public static ObservableCollection<T> GetEnumValues<T>() where T : Enum
        {
            var values = new ObservableCollection<T>();
            foreach (var value in Enum.GetValues(typeof(T)))
            {
                values.Add((T)value);
            }
            return values;
        }
    }
    public class MatchesViewModel : ViewModelBase
    {
        private readonly IMatchService _matchService;
        private ObservableCollection<Match> _matches;
        private Match _selectedMatch;
        private CompetitionStage _selectedStage;
        private ObservableCollection<Competition> _competitions;
        private ObservableCollection<CompetitionStage> _stages;
        private ObservableCollection<Match> allMatches; 
        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }
        private Competition _selectedCompetition;
        public Competition SelectedCompetition
        {
            get { return _selectedCompetition; }
            set
            {
                _selectedCompetition = value;
                OnPropertyChanged(nameof(SelectedCompetition));
                FilterbyCompetitonsc();
            }
        }
        public ObservableCollection<Competition> Competitions 
        { get { return _competitions; } set { _competitions = value; OnPropertyChanged(nameof(Competitions)); } }
        public ObservableCollection<CompetitionStage> Stages { get { return _stages; } set { _stages = value; OnPropertyChanged(nameof(Stages)); } }
        public CompetitionStage SelectedStage
        {
            get { return _selectedStage; }
            set
            {
                _selectedStage = value;
                OnPropertyChanged(nameof(SelectedStage));
                FilterBystages();
            }
        }
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

            Stages = EnumHelper.GetEnumValues<CompetitionStage>();
            LoadMatches();
        }
        private async Task LoadMatches()
        {
            allMatches = new ObservableCollection<Match>(await _matchService.GetAllMatchsAsync());
            Matches = allMatches;
            Competitions = new ObservableCollection<Competition>(Matches.Select(m => m.Competition).Distinct());
           // Stages = new ObservableCollection<CompetitionStage>(Matches.Select(m => m.Stage).Distinct());
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
        private void FilterbyCompetitonsc()
        {
            if (_matches == null) return;

            var filteredMatches = allMatches.AsEnumerable();

            if (SelectedCompetition != null)
            {
                filteredMatches = filteredMatches.Where(m => m.Competition.Id == SelectedCompetition.Id);
            }
            Matches = new ObservableCollection<Match>(filteredMatches);

        }
        private void FilterBystages()
        {
            if (_matches == null) return;
            var filteredMatches = allMatches.AsEnumerable();
            filteredMatches = filteredMatches.Where(m => m.Stage == SelectedStage);
            Matches = new ObservableCollection<Match>(filteredMatches);

        }
    }
}
