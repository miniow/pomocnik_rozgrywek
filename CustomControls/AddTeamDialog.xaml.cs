using Pomocnik_Rozgrywek.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy AddTeamDialog.xaml
    /// </summary>
    public partial class AddTeamDialog : Window, INotifyPropertyChanged
    {
        public delegate void TeamCreatedHandler(Team team);
        public event TeamCreatedHandler OnTeamCreated;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public Team Team { get; set; }

        public AddTeamDialog()
        {
            InitializeComponent();
            DataContext = this;
            Team = new Team();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
            {
                ErrorMessage = "Name is required.";
                return;
            }
            if (string.IsNullOrEmpty(shortName_tb.Text))
            {
                ErrorMessage = "Short Name is required.";
                return;
            }
            if (string.IsNullOrEmpty(tla_tb.Text))
            {
                ErrorMessage = "TLA is required.";
                return;
            }
            if (string.IsNullOrEmpty(address_tb.Text))
            {
                ErrorMessage = "Address is required.";
                return;
            }
            if (string.IsNullOrEmpty(founded_tb.Text) || !int.TryParse(founded_tb.Text, out var founded))
            {
                ErrorMessage = "Valid Founded year is required.";
                return;
            }
            if (clubColors_cp.SelectedColor == null)
            {
                ErrorMessage = "Club Colors are required.";
                return;
            }
            if (string.IsNullOrEmpty(venue_tb.Text))
            {
                ErrorMessage = "Venue is required.";
                return;
            }

            Team.Name = name_tb.Text;
            Team.ShortName = shortName_tb.Text;
            Team.Tla = tla_tb.Text;
            Team.Address = address_tb.Text;
            Team.Website = website_tb.Text;
            Team.ClubColors = clubColors_cp.SelectedColor.ToString();
            Team.Founded = founded;
            Team.Venue = venue_tb.Text;

            OnTeamCreated?.Invoke(Team);
            Close();
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select an Emblem Image"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                crest_tb.Text = openFileDialog.FileName;
                Team.Crest = openFileDialog.FileName;
            }
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
