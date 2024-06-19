using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Pomocnik_Rozgrywek.CustomControls;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Services;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public class SeasonViewModel : ViewModelBase
    {
        private readonly ISeasonService _seasonService;
        private ObservableCollection<Season> _seasons;
        private Season _selectedSeason;
        private SeriesCollection _ganttSeries;
        private List<string> _seasonLabels;
        public Func<double, string> Formatter { get; set; }

        public ObservableCollection<Season> Seasons
        {
            get { return _seasons; }
            set
            {
                _seasons = value;
                OnPropertyChanged(nameof(Seasons));
                SetupGanttSeries();
            }
        }

        public Season SelectedSeason
        {
            get { return _selectedSeason; }
            set
            {
                _selectedSeason = value;
                OnPropertyChanged(nameof(SelectedSeason));
            }
        }

        public SeriesCollection GanttSeries
        {
            get { return _ganttSeries; }
            set
            {
                _ganttSeries = value;
                OnPropertyChanged(nameof(GanttSeries));
            }
        }
        
        public List<string> SeasonLabels
        {
            get { return _seasonLabels; }
            set
            {
                _seasonLabels = value;
                OnPropertyChanged(nameof(SeasonLabels));
            }
        }
        public ICommand AddSeasonCommand { get; }
        public ICommand UpdateSeasonCommand { get; }
        public ICommand DeleteSeasonCommand { get; }
        public SeasonViewModel()
        {
            _seasonService = new SeasonService();
            LoadSeasons();
            Formatter = value => DateTime.FromOADate(value).ToString("dd MMM yyyy");

            AddSeasonCommand = new ViewModelCommand(async param => await AddSeason());
            UpdateSeasonCommand = new ViewModelCommand(async param => await UpdateSeason());
            DeleteSeasonCommand = new ViewModelCommand(async param => await DeleteSeason());
        }

        private async void LoadSeasons()
        {
            Seasons = new ObservableCollection<Season>(await _seasonService.GetAllSeasonsAsync());
        }

        private void SetupGanttSeries()
        {
            SeasonLabels = Seasons.Select(s => $"Season {s.Id}").ToList();
            GanttSeries = new SeriesCollection();

            foreach (var season in Seasons)
            {
                GanttSeries.Add(new RowSeries
                {
                    Title = $"Season {season.Id}",
                    Values = new ChartValues<GanttPoint>
                    {
                        new GanttPoint(season.StartDate.ToDateTime(TimeOnly.MinValue).ToOADate(), season.EndDate.ToDateTime(TimeOnly.MinValue).ToOADate())
                    }
                });
            }
        }

        private async Task AddSeason()
        {
            var addSeasonDialog = new AddSeasonDialog();
            if (addSeasonDialog.ShowDialog() == true)
            {
                var newSeason = addSeasonDialog.NewSeason;
                await _seasonService.CreateSeasonAsync(newSeason);
                LoadSeasons();
            }
        }

        private async Task UpdateSeason()
        {
            if (SelectedSeason == null) return;
            await _seasonService.UpdateSeasonAsync(SelectedSeason);
            LoadSeasons();
        }

        private async Task DeleteSeason()
        {
            if (SelectedSeason == null) return;
            await _seasonService.DeleteSeasonAsync(SelectedSeason.Id);
            LoadSeasons();
        }
    }
}
