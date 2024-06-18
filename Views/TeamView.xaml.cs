using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pomocnik_Rozgrywek.Views
{
    /// <summary>
    /// Logika interakcji dla klasy TeamView.xaml
    /// </summary>
    public partial class TeamView : UserControl
    {
        public TeamView()
        {
            InitializeComponent();
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var row = DataGridRow.GetRowContainingElement(button);
                if (row != null)
                {
                    dataGrid.BeginEdit();
                }
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var row = DataGridRow.GetRowContainingElement(button);
                if (row != null)
                {
                    dataGrid.CommitEdit();
                    var viewModel = DataContext as TeamViewModel;
                    if (viewModel != null)
                    {
                        var team = row.Item as Team;
                        if (team!= null)
                        {
                            viewModel.UpdateTeamCommand.Execute(team);
                        }
                    }
                }
            }
        }
        private void TeamDetailsFlyout_ClosingFinished(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as TeamViewModel;
            if (viewModel != null)
            {
                viewModel.IsTeamDetailsFlyoutOpen = false;
            }
        }
    }
}
