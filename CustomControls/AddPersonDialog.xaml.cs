using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pomocnik_Rozgrywek.CustomControls
{
    /// <summary>
    /// Logika interakcji dla klasy AddPersonDialog.xaml
    /// </summary>
    public partial class AddPersonDialog : Window, INotifyPropertyChanged
    {
        public delegate void PersonCreatedHandler(Person person);
        public event PersonCreatedHandler OnPersonCreated;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public Person Person { get; set; }

        public AddPersonDialog()
        {
            InitializeComponent();
            DataContext = this;
            Person = new Person();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(firstName_tb.Text))
            {
                ErrorMessage = "First Name is required.";
                return;
            }
            if (string.IsNullOrEmpty(lastName_tb.Text))
            {
                ErrorMessage = "Last Name is required.";
                return;
            }
            if (string.IsNullOrEmpty(dateOfBirth_tb.Text))
            {
                ErrorMessage = "Date of Birth is required.";
                return;
            }
            if (string.IsNullOrEmpty(nationality_tb.Text))
            {
                ErrorMessage = "Nationality is required.";
                return;
            }
            if (string.IsNullOrEmpty(position_tb.Text))
            {
                ErrorMessage = "Position is required.";
                return;
            }

            Person.FirstName = firstName_tb.Text;
            Person.LastName = lastName_tb.Text;
            Person.DateOfBirth = dateOfBirth_tb.Text;
            Person.Nationality = nationality_tb.Text;
            Person.Position = position_tb.Text;


            Person.ShirtNumber = int.TryParse(shirtNumber_tb.Text, out var shirtNumber) ? shirtNumber : (int?)null;


            OnPersonCreated?.Invoke(Person);
            Close();
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
