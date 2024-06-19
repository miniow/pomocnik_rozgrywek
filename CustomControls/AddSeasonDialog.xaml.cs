using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy AddSeasonDialog.xaml
    /// </summary>
    public partial class AddSeasonDialog : Window
    {
        public AddSeasonDialog()
        {
            InitializeComponent();
        }

        public Season NewSeason { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewSeason = new Season
            {
                StartDate = new DateOnly(startDate_dp.SelectedDate.Value.Year, startDate_dp.SelectedDate.Value.Month, startDate_dp.SelectedDate.Value.Day),
                EndDate = new DateOnly(endDate_dp.SelectedDate.Value.Year, endDate_dp.SelectedDate.Value.Month, endDate_dp.SelectedDate.Value.Day),
            };

            DialogResult = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
