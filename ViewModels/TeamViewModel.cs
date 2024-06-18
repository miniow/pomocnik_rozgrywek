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
    public class TeamViewModel : ViewModelBase
    {
        private readonly ITeamService _teamService;
        private ObservableCollection<Team> _teams;
        private Team _selectedTeam;
        private bool _isTeamDetailsFlyoutOpen;


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
        public bool IsTeamDetailsFlyoutOpen
        {
            get { return _isTeamDetailsFlyoutOpen; }
            set
            {
                _isTeamDetailsFlyoutOpen = value;
                OnPropertyChanged(nameof(IsTeamDetailsFlyoutOpen));
            }
        }


        public ICommand LoadTeamCommand { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand UpdateTeamCommand { get; }
        public ICommand DeleteTeamCommand { get; }
        public ICommand ShowTeamDetailsCommand { get; }

        public TeamViewModel()
        {
            _teamService = new TeamService();
            messageService = GlobalMessageService.GetMessageService();

            LoadTeamCommand = new ViewModelCommand(async param => await LoadTeams());
            AddTeamCommand = new ViewModelCommand(async param => await AddTeam(param as Team));
            UpdateTeamCommand = new ViewModelCommand(async param => await UpdateTeam(param as Team));
            DeleteTeamCommand = new ViewModelCommand(async param => await DeleteTeam(param as Team));
            ShowTeamDetailsCommand = new ViewModelCommand(param => ShowTeamDetails(param as Team));

            LoadTeams();
        }

        private async Task DeleteTeam(Team team)
        {
            try
            {
                await _teamService.DeleteTeamAsync(team.Id);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot delete team: " + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Team deleted successfully"));
            await LoadTeams();
        }

        private async Task UpdateTeam(Team team)
        {
            try
            {
                await _teamService.UpdateTeamAsync(team);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot update team: " + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Team updated successfully"));
            await LoadTeams();
        }

        private async Task AddTeam(Team team)
        {
            var addTeamDialog = new AddTeamDialog();
            addTeamDialog.OnTeamCreated += async (newTeam) =>
            {
                try
                {
                    await _teamService.CreateTeamAsync(newTeam);
                }
                catch (Exception ex)
                {
                    messageService.AddMessage(new ErrorMessage("Cannot add team: " + ex.ToString()));
                    return;
                }
                messageService.AddMessage(new SuccessMessage("Team added successfully"));
                await LoadTeams();
            };
            addTeamDialog.Show();
            return;
        }

        private async Task LoadTeams()
        {
            Teams = new ObservableCollection<Team>(await _teamService.GetAllTeamsAsync());
        }
        private void ShowTeamDetails(Team team)
        {
            SelectedTeam = team;
            IsTeamDetailsFlyoutOpen = true;
        }
    }
}
