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
    /// Logika interakcji dla klasy AreaSelectionDialog.xaml
    /// </summary>
    public partial class AreaSelectionDialog : Window
    {
        public Area SelectedArea { get; private set; }
        public ObservableCollection<Area> Areas { get; set; }
        public AreaSelectionDialog(ObservableCollection<Area> areas)
        {
            InitializeComponent();
            Areas = areas;
            AreasListView.ItemsSource = Areas;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedArea = AreasListView.SelectedItem as Area;
            if (SelectedArea != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a team.");
            }
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
