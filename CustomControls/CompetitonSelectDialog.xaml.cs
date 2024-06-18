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
    /// Logika interakcji dla klasy CompetitonSelectDialog.xaml
    /// </summary>
    public partial class CompetitonSelectDialog : Window
    {
        public Competition SelectedCompetition { get; private set; }

        public CompetitonSelectDialog(ObservableCollection<Competition> competitions)
        {
            InitializeComponent();
            CompetitionsListBox.ItemsSource = competitions;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedCompetition = CompetitionsListBox.SelectedItem as Competition;
            if (SelectedCompetition != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a competition.");
            }
        }
    }
}
