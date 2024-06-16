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
    public class PearsonViewModel : ViewModelBase
    {
        private readonly IPersonService _personService;
        private Person _selectedPerson;
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
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }
        public PearsonViewModel()
        {
            _personService = new PersonService();
            LoadPerson();
        }

        private async void LoadPerson()
        {
            Persons = new ObservableCollection<Person>(await _personService.GetAllPersonAsync());
        }
    }
}
