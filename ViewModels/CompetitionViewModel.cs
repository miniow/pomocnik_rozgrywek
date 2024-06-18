using Azure.Identity;
using Castle.Components.DictionaryAdapter.Xml;
using Pomocnik_Rozgrywek.CustomControls;
using Pomocnik_Rozgrywek.Messanger;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly ICompetitionService _competitionService;
        private readonly IAreaService _areaService;
        private ObservableCollection<Competition> _competitions;
        private Competition _selectedCompetition;
        private Area _selectedArea;
        private string _searchText;
        private ObservableCollection<Area> _areas;
        private ObservableCollection<Competition> _filteredCompetitions;
        public ObservableCollection<Competition> FilteredCompetitions
        {
            get { return _filteredCompetitions; }
            set
            {
                _filteredCompetitions = value;
                OnPropertyChanged(nameof(FilteredCompetitions));
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchCompetitionsAsync();
            }
        }
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
        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
                FilterByArea(SelectedArea);
            }
        } 
        public ObservableCollection<Area> Areas
        {
            get { return _areas; }
            set
            {
                _areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }

        public ICommand LoadCompetitionsCommand { get; }
        public ICommand AddCompetitionCommand { get; }
        public ICommand UpdateCompetitionCommand { get; }
        public ICommand DeleteCompetitionCommand { get; }
        public ICommand AddToAreaCommand { get; }

        public CompetitionViewModel()
        {
            messageService = GlobalMessageService.GetMessageService();
            _competitionService = new CompetitionService();
            _areaService = new AreaService();
            LoadCompetitionsCommand = new ViewModelCommand(async param => await LoadCompetitions());
            AddCompetitionCommand = new ViewModelCommand(async param => await AddCompetition(param as Competition));
            UpdateCompetitionCommand = new ViewModelCommand(async param => await UpdateCompetition(param as Competition));
            DeleteCompetitionCommand = new ViewModelCommand(async param => await DeleteCompetition(param as Competition));
            AddToAreaCommand = new ViewModelCommand(async param => await AddToArea(param as Competition));

            LoadCompetitions();
        }

        private void FilterByArea(Area? area)
        {
            if (SelectedArea == null)
            {
                FilteredCompetitions = new ObservableCollection<Competition>(Competitions);
            }
            else
            {
                FilteredCompetitions = new ObservableCollection<Competition>(
                Competitions.Where(c => c.Area != null && c.Area.Id == SelectedArea.Id));
            }
        }

        private async Task AddToArea(Competition? competition)
        {
            Areas = new  ObservableCollection<Area>( await _areaService.GetAllAreasAsync());

            if(competition.Area != null)
            {
                MessageBoxResult result = MessageBox.Show("The person is already a coach of another team. Are you sure you want to reassign them?",
                                                     "Warning",
                                                     MessageBoxButton.YesNo,
                                                     MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                    return;
            }
            Areas = new ObservableCollection<Area>(await _areaService.GetAllAreasAsync());
            AreaSelectionDialog asd = new AreaSelectionDialog(Areas);
                if (asd.ShowDialog() == true)
            {
                var area = asd.SelectedArea;
                await _competitionService.AddToArea(competition, area);
                await LoadCompetitions();
            }
        }

        private async Task DeleteCompetition(Competition? competition)
        {
            try
            {
                await _competitionService.DeleteCompetitionAsync(competition.Id);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot delete competition" + ex.ToString()));

            }
            messageService.AddMessage(new InfoMessage("Competition deleted succesfully"));
            await LoadCompetitions();
        }

        private async Task UpdateCompetition(Competition? competition)
        {
            try
            {
                await _competitionService.UpdateCompetitionAsync(competition);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot update competition" + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Competition updated succesfully"));
            await LoadCompetitions();
        }
        private async Task SearchCompetitionsAsync()
        {
            await Task.Run(() =>
            {
                if (string.IsNullOrEmpty(SearchText) && SelectedArea == null)
                {
                    FilteredCompetitions = new ObservableCollection<Competition>(Competitions);
                }
                else
                {
                    var filtered = Competitions.Where(c =>
                        (string.IsNullOrEmpty(SearchText) || c.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)) &&
                        (SelectedArea == null || c.Area == SelectedArea)).ToList();

                    FilteredCompetitions = new ObservableCollection<Competition>(filtered);
                }
            });
        }

        private async Task AddCompetition(Competition? competition)
        {
            var addTeamDialog = new AddCompetitionDialog();

            addTeamDialog.OnCompetitionCreated += async (newCompetiton) =>
            {
                try
                {
                    await _competitionService.CreateCompetitionAsync(newCompetiton);
                }
                catch (Exception ex)
                {
                    messageService.AddMessage(new ErrorMessage("Cannot add team: " + ex.ToString()));
                    return;
                }
                messageService.AddMessage(new SuccessMessage("Team added successfully"));
                await LoadCompetitions();
            };
            addTeamDialog.Show();
            return;
        }

        private async Task LoadCompetitions()
        {
            Competitions = new ObservableCollection<Competition>(await _competitionService.GetAllCompetitionsAsync());
            FilteredCompetitions = Competitions;
            Areas = new ObservableCollection<Area> (await _areaService.GetAllAreasAsync());
        }
    }
}
