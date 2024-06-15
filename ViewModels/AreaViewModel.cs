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

        public AreaViewModel()
        {
            _areaService = new AreaService();
            LoadAreas();
        }
        private async void LoadAreas()
        {
            Areas = new ObservableCollection<Area>(await _areaService.GetAllAreasAsync());
        }
        private List<Area> BuildHierarchy(IEnumerable<Area> areas)
        {
            var lookup = areas.ToLookup(a => a.ParentAreaId);
            foreach (var area in areas)
            {
                area.ChildAreas = lookup[area.Id].ToList();
            }
            return lookup[0].ToList();
        }
    }
}
