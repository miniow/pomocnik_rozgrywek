using Azure.Identity;
using Microsoft.Identity.Client;
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
using System.Windows;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public class PearsonViewModel : ViewModelBase
    {
        private readonly IPersonService _personService;
        private readonly ITeamService _teamService;

        private ObservableCollection<Person> _persons;
        private ObservableCollection<Team> _teams;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                OnPropertyChanged(nameof(Persons));
            }
        }
        public ObservableCollection<Team> Teams
        {
            get { return _teams; }
            set
            {
                _teams = value;
                OnPropertyChanged(nameof(Teams));
            }
        }

        public ICommand LoadPeopleCommand { get; }
        public ICommand AddPersonCommand { get; }
        public ICommand UpdatePersonCommand { get; }
        public ICommand DeletePersonCommand { get; }
        public ICommand AddToTeamCommand { get; }
        public ICommand AppointAsCoachCommand { get; }

        public PearsonViewModel()
        {
            _personService = new PersonService();
            _teamService = new TeamService();

            messageService = GlobalMessageService.GetMessageService();

            LoadPeopleCommand = new ViewModelCommand(async param => await LoadPeople());
            AddPersonCommand = new ViewModelCommand(async param => await AddPerson());
            UpdatePersonCommand = new ViewModelCommand(async param => await UpdatePerson(param as Person));
            DeletePersonCommand = new ViewModelCommand(async param => await DeletePerson(param as Person));
            AddToTeamCommand = new ViewModelCommand(async param => await AddToTeam(param as Person));
            AppointAsCoachCommand = new ViewModelCommand(async param => await AppointAsCoach(param as Person));


            LoadPeople();

        }

        private async Task AppointAsCoach(Person? person)
        {
            if (person.CurrentTeam != null)
            {
                MessageBoxResult result = MessageBox.Show("The person is already a coach of another team. Are you sure you want to reassign them?",
                                                     "Warning",
                                                     MessageBoxButton.YesNo,
                                                     MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                    return;
            }

            Teams = new ObservableCollection<Team>(await _teamService.GetAllTeamsAsync());
            TeamSelectionDialog tsd = new TeamSelectionDialog(Teams);
            if (tsd.ShowDialog() == true)
            {
                var team = tsd.SelectedTeam;
                await _personService.AppointAsCoach(person, team);
                await LoadPeople();
            }


        }

        private async Task AddToTeam(Person? person)
        {
            if (person.CurrentTeam != null)
            {
                MessageBoxResult result = MessageBox.Show("The person is already in another team. Are you sure you want to reassign them?",
                                                     "Warning",
                                                     MessageBoxButton.YesNo,
                                                     MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                    return;
            }
            Teams = new ObservableCollection<Team>(await _teamService.GetAllTeamsAsync());
            TeamSelectionDialog tsd = new TeamSelectionDialog(Teams);
            if (tsd.ShowDialog() == true)
            {
                var team = tsd.SelectedTeam;
                await _personService.AppointAsCoach(person, team);
                await LoadPeople();
            }
        }

        private async Task DeletePerson(Person person)
        {
            try
            {
                await _personService.DeletePersonAsync(person.Id);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot delete person" + ex.ToString()));

            }
            messageService.AddMessage(new SuccessMessage("Perosn deleted succesfully"));
            await LoadPeople();
        }

        private async Task UpdatePerson(Person person)
        {
            try
            {
                await _personService.UpdatePersonAsync(person);
            }
            catch (Exception ex)
            {
                messageService.AddMessage(new ErrorMessage("Cannot update person" + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Perosn updated succesfully"));
            await LoadPeople();
        }

        private async Task AddPerson()
        {
            var addPersonDialog = new AddPersonDialog();
            addPersonDialog.OnPersonCreated += async (newPerson) =>
            {
                try
                {
                    await _personService.CreatePersonAsync(newPerson);
                }
                catch (Exception ex)
                {
                    messageService.AddMessage(new ErrorMessage("Cannot add person" + ex.ToString()));
                }
                messageService.AddMessage(new SuccessMessage("Perosn addded succesfully"));
                await LoadPeople();
            };
            addPersonDialog.Show();
            return;
        }

        private async Task LoadPeople()
        {
            Persons = new ObservableCollection<Person>(await _personService.GetAllPersonAsync());

        }
    }
}
