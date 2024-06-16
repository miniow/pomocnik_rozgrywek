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
    public class TeamViewModel : ViewModelBase
    {
        private readonly ITeamService _teamService;
        private Team _selectedTeam;
        private ObservableCollection<Team> _teams;


        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }
        public Team SelectedTeam
        {
            get { return _selectedTeam; }
            set
            {
                _selectedTeam = value;
                OnPropertyChanged(nameof(SelectedTeam));
            }
        }
        public TeamViewModel()
        {
            _teamService = new TeamService();
            LoadTeams();
        }
        private async void LoadTeams()
        {
            Teams = new ObservableCollection<Team>(await _teamService.GetAllTeamsAsync());
        }
    }
}
