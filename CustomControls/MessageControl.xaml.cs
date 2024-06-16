using Pomocnik_Rozgrywek.Messanger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Pomocnik_Rozgrywek.CustomControls
{
    /// <summary>
    /// Logika interakcji dla klasy MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public MessageControl()
        {
            InitializeComponent();
        }

        public void SetMessage(Message message)
        {
            MessageTextBlock.Text = message.Text;
            switch (message)
            {
                case ValidationMessage _:
                    ApplyStyle((SolidColorBrush)FindResource("ValidationColorBorder"),
                               (SolidColorBrush)FindResource("ValidationColorBackground"),
                               (SolidColorBrush)FindResource("ValidationColorText"));
                    break;
                case ErrorMessage _:
                    ApplyStyle((SolidColorBrush)FindResource("ErrorColorBorder"),
                               (SolidColorBrush)FindResource("ErrorColorBackground"),
                               (SolidColorBrush)FindResource("ErrorColorText"));
                    break;
                case WarningMessage _:
                    ApplyStyle((SolidColorBrush)FindResource("WarningColorBorder"),
                               (SolidColorBrush)FindResource("WarningColorBackground"),
                               (SolidColorBrush)FindResource("WarningColorText"));
                    break;
                case SuccessMessage _:
                    ApplyStyle((SolidColorBrush)FindResource("SuccessColorBorder"),
                               (SolidColorBrush)FindResource("SuccessColorBackground"),
                               (SolidColorBrush)FindResource("SuccessColorText"));
                    break;
                case InfoMessage _:
                    ApplyStyle((SolidColorBrush)FindResource("InfoColorBorder"),
                               (SolidColorBrush)FindResource("InfoColorBackground"),
                               (SolidColorBrush)FindResource("InfoColorText"));
                    break;
            }
        }
        private void ApplyStyle(SolidColorBrush borderBrush, SolidColorBrush backgroundBrush, SolidColorBrush textBrush)
        {
            MessageBorder.BorderBrush = borderBrush;
            MessageBorder.Background = backgroundBrush;
            MessageTextBlock.Foreground = textBrush;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var parentPopup = this.Parent as Popup;
            if (parentPopup != null)
            {
                parentPopup.IsOpen = false;
            }
        }
    }
}
