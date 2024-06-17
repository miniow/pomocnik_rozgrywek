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
    /// Logika interakcji dla klasy AddCompetitionDialog.xaml
    /// </summary>
    public partial class AddCompetitionDialog : Window, INotifyPropertyChanged
    {
        public delegate void CompetitionCreatedHandler(Competition competition);
        public event CompetitionCreatedHandler OnCompetitionCreated;
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _errorMessage = "";
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public Competition Competition { get; set; }
        public ObservableCollection<Season> Seasons { get; set; }
        public Season SelectedSeason { get; set; }

        public AddCompetitionDialog(ObservableCollection<Season> seasons)
        {
            InitializeComponent();
            DataContext = this;
            Competition = new Competition();
            Seasons = seasons;
            season_cb.ItemsSource = Seasons;
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
                emblem_tb.Text = openFileDialog.FileName;
                Competition.Emblem = openFileDialog.FileName;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name_tb.Text))
            {
                ErrorMessage = "Name is required.";
                return;
            }
            if (string.IsNullOrEmpty(code_tb.Text))
            {
                ErrorMessage = "Code is required.";
                return;
            }
            if (string.IsNullOrEmpty(type_tb.Text))
            {
                ErrorMessage = "Trype is required.";
                return;
            }
            if(season_cb.SelectedItem == null)
            {
                ErrorMessage = "Trye is required.";
                return;
            }

            Competition.Name = name_tb.Text;
            Competition.Code = code_tb.Text;
            Competition.Type = type_tb.Text;
            Competition.Emblem = emblem_tb.Text;
            Competition.CurrentSeason = (Season)season_cb.SelectedItem;
            OnCompetitionCreated?.Invoke(Competition);
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
