using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy TeamSelectionDialog.xaml
    /// </summary>
    public partial class TeamSelectionDialog : Window
    {
        public Team SelectedTeam { get; private set; }

        public TeamSelectionDialog(ObservableCollection<Team> teams)
        {
            InitializeComponent();
            TeamsListBox.ItemsSource = teams;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedTeam = TeamsListBox.SelectedItem as Team;
            if (SelectedTeam != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a team.");
            }
        }
    }
}
