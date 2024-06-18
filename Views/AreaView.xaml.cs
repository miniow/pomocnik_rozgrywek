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
using Svg;
using SkiaSharp;
using System.IO;
using System.Windows.Media.Imaging;
using System.Net;
using System.Net.Http;
namespace Pomocnik_Rozgrywek.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AreaView.xaml
    /// </summary>
    public partial class AreaView : UserControl
    {
        public AreaView()
        {
            InitializeComponent();
        }
        private async void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Area selectedArea)
            {
                var viewModel = (AreaViewModel)DataContext;
                viewModel.SelectedArea = selectedArea;
            }
        }

        private void addChildAreaClick(object sender, RoutedEventArgs e)
        {
            var viewmodel = (AreaViewModel)DataContext;
            viewmodel.AddChildAreaCommand.Execute(null);
        }

        private void deleteAreaClick(object sender, RoutedEventArgs e)
        {
            var viewmodel = (AreaViewModel)DataContext;
            viewmodel.DeleteAreaCommand.Execute(null);
        }
    }
}
