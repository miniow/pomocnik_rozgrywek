using Pomocnik_Rozgrywek.Models;
using System;
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
    /// Logika interakcji dla klasy AddAreaDialog.xaml
    /// </summary>
    public partial class AddAreaDialog : Window, INotifyPropertyChanged
    {
        public delegate void AreaCreatedHandler(Area area);
        public event AreaCreatedHandler OnAreaCreated;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _errorMessage = "";
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public Area Area { get; set; }

        public AddAreaDialog()
        {
            InitializeComponent();
            DataContext = this;
            Area = new Area();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Select a Flag Image"
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                flag_tb.Text = openFileDialog.FileName;
                Area.Flag = openFileDialog.FileName;
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

            Area.Name = name_tb.Text;
            Area.Code = code_tb.Text;
            Area.Flag = flag_tb.Text;

            OnAreaCreated?.Invoke(Area);
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
