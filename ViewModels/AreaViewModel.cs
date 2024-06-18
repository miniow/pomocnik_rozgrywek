using Pomocnik_Rozgrywek.CustomControls;
using Pomocnik_Rozgrywek.Messanger;
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
        private Area _selectedArea;
        private ObservableCollection<Area> _areaRoot;

        public ObservableCollection<Area> Areas
        {
            get { return _areas; }
            set
            {
                _areas = value;
                OnPropertyChanged(nameof(Areas));
            }
        }
        public Area SelectedArea
        {
            get { return _selectedArea; }
            set
            {
                _selectedArea = value;
                OnPropertyChanged(nameof(SelectedArea));
            }
        }
        public ObservableCollection<Area> AreaRoot
        {
            get { return _areaRoot; }
            set
            {
                _areaRoot = value;
                OnPropertyChanged(nameof(AreaRoot));
            }
        }

        public ICommand AddChildAreaCommand { get; }
        public ICommand LoadAreasCommand { get; }
        public ICommand AddAreaCommand { get; }
        public ICommand UpdateAreaCommand { get; }
        public ICommand DeleteAreaCommand { get; }
        public AreaViewModel()
        {

            messageService = GlobalMessageService.GetMessageService();
            AddChildAreaCommand = new ViewModelCommand(async param => await AddChildArea());
            LoadAreasCommand = new ViewModelCommand(async param => await LoadAreas());
            AddAreaCommand = new ViewModelCommand(async param => await AddArea(param as Area));
            UpdateAreaCommand = new ViewModelCommand(async param => await UpdateArea(param as Area));
            DeleteAreaCommand = new ViewModelCommand(async param => await DeleteArea(param as Area));
            _areaService = new AreaService();

            LoadAreas();
        }

        private async Task DeleteArea(Area? area)
        {
            try
            {
                await _areaService.DeleteAreaAsync(SelectedArea.Id);
            }catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot delete Area" + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Area deleted succesfully"));
            await LoadAreas();
        }

        private async Task UpdateArea(Area? area)
        {
            await _areaService.UpdateAreaAsync(SelectedArea);
            await LoadAreas();
        }

        private async Task AddArea(Area? area)
        {
            if(SelectedArea.ChildAreas == null)
            {
                SelectedArea.ChildAreas = new ObservableCollection<Area>();
            }
            SelectedArea.ChildAreas.Add(area);
            area.ParentArea = SelectedArea.Name;
            await _areaService.CreateAreaAsync(area);
            await _areaService.UpdateAreaAsync(SelectedArea);
        }

        private async Task AddChildArea()
        {
            var addAreaDialog = new AddAreaDialog();
            addAreaDialog.OnAreaCreated += async (newArea) =>
            {
                await AddArea(newArea);
            };
            addAreaDialog.Show();
            return;
        }

        private async Task LoadAreas()
        {
            var areas = await _areaService.GetAllAreasAsync();
            var hierarchy = BuildHierarchy(areas);
            AreaRoot = new ObservableCollection<Area>(hierarchy);
            Areas = new ObservableCollection<Area>(areas);
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
