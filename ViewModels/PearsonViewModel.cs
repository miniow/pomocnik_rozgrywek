using Azure.Identity;
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
    public class PearsonViewModel : ViewModelBase
    {
        private readonly IPersonService _personService;

        private ObservableCollection<Person> _persons;

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons= value;
                OnPropertyChanged(nameof(Persons));
            }
        }

        public ICommand LoadPeopleCommand { get; }
        public ICommand AddPersonCommand { get; }
        public ICommand UpdatePersonCommand { get; }
        public ICommand DeletePersonCommand { get; }

        public PearsonViewModel()
        {
            _personService = new PersonService();

            messageService = GlobalMessageService.GetMessageService();

            LoadPeopleCommand = new ViewModelCommand(async param => await LoadPeople());
            AddPersonCommand = new ViewModelCommand(async param => await AddPerson(param as Person));
            UpdatePersonCommand = new ViewModelCommand(async param => await UpdatePerson(param as Person));
            DeletePersonCommand = new ViewModelCommand(async param => await DeletePerson(param as Person));

            
            LoadPeople();
        }

        private async Task DeletePerson(Person person)
        {
            try
            {
                await _personService.DeletePersonAsync(person.Id);
            }catch(Exception ex)
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
            catch(Exception ex) {
                messageService.AddMessage(new ErrorMessage("Cannot update person" + ex.ToString()));
                return;
            }
            messageService.AddMessage(new SuccessMessage("Perosn updated succesfully"));
            await LoadPeople();
        }

        private async Task AddPerson(Person perosn)
        {
            var addPersonDialog = new AddPersonDialog();
            addPersonDialog.OnPersonCreated += async (newPerson) =>
            {
                try
                {
                    await _personService.CreatePersonAsync(newPerson);
                }catch (Exception ex) {
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
