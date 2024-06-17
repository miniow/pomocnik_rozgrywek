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
    public class AreaViewModel : ViewModelBase
    {
        private readonly IAreaService _areaService;
        private ObservableCollection<Area> _areas;
        public ObservableCollection<Area> Areas
        {
            get { return _areas; }
            set
            {
                _areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }
        private Area _selectedArea;
        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
            }
        }
        private ObservableCollection<Area> _areaRoot;
        public ObservableCollection<Area> AreaRoot
        {
            get { return _areaRoot; }
            set
            {
                _areaRoot = value;
                OnPropertyChanged(nameof(AreaRoot));
            }
        }
        public ICommand AddCompetitonToAreaCommand { get; }
        public ICommand LoadAreasCommand { get; }
        public ICommand AddAreaCommand { get; }
        public ICommand UpdateAreaCommand { get; }
        public ICommand DeleteAreaCommand { get; }
        public AreaViewModel()
        {
            AddCompetitonToAreaCommand = new ViewModelCommand(async param => await AddCompetitonToArea(param as Tuple<Competition, Area>));
            LoadAreasCommand = new ViewModelCommand(async param => await LoadAreas());
            AddAreaCommand = new ViewModelCommand(async param => await AddMatch(param as Area));
            UpdateAreaCommand = new ViewModelCommand(async param => await UpdateMatch(param as Area));
            DeleteAreaCommand = new ViewModelCommand(async param => await DeleteMatch(param as Area));
            _areaService = new AreaService();

            LoadAreas();
        }

        private Task DeleteMatch(Area? area)
        {
            throw new NotImplementedException();
        }

        private Task UpdateMatch(Area? area)
        {
            throw new NotImplementedException();
        }

        private Task AddMatch(Area? area)
        {
            throw new NotImplementedException();
        }

        private async Task AddCompetitonToArea(Tuple<Competition, Area> param)
        {
            if (param == null || param.Item1 == null || param.Item2 == null)
            {
                throw new NullReferenceException();
            }
            var competition = param.Item1;
            var area = param.Item2;

            await _areaService.AddCompetitonToArea(competition,area);
        }

        private async Task LoadAreas()
        {
            var areas = await _areaService.GetAllAreasAsync();
            var hierarchy = BuildHierarchy(areas);
            AreaRoot = new ObservableCollection<Area>(hierarchy);
            Areas = new ObservableCollection<Area>(areas);

            //var root = areas.FirstOrDefault(a => a.ParentAreaId == null);
            //if (root != null)
            //{
 
            //}
            //Areas = new ObservableCollection<Area>(areas);

        }
        private List<Area> BuildHierarchy(IEnumerable<Area> areas)
        {
            var lookup = areas.ToLookup(a => a.ParentAreaId);
            foreach (var area in areas)
            {
                area.ChildAreas = lookup[area.Id].ToList();
            }
            return lookup[null].ToList();
        }
    }
}
