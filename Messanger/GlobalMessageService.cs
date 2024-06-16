using Pomocnik_Rozgrywek.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Pomocnik_Rozgrywek.Messanger
{
    public class GlobalMessageService
    {
        private static GlobalMessageService _instance;
        private static List<Message> _messages; 
        private GlobalMessageService()
        {
            _messages = new List<Message>();
        }
        public static GlobalMessageService GetMessageService()
        {
            if (_instance == null)
            {
                _instance = new GlobalMessageService();
            }
            return _instance;
        }
        public static void AddMessage(Window context, Message message)
        {
            _messages.Add(message);
            ShowMessage(context, message);
        }
        public static void ShowMessage(Window context, Message message)
        {
            var messageControl = new MessageControl();
            messageControl.SetMessage(message);
            var popup = new Popup
            {
                Child = messageControl,
                PlacementTarget = context,
                Placement = PlacementMode.Top,
                StaysOpen = false,
                AllowsTransparency = true,
                VerticalOffset = 10,
                HorizontalOffset = context.ActualWidth / 2 - 200
            };

            popup.IsOpen = true;
        }
        public static List<Message> GetMessages()
        {
            return _messages;
        }
    }
}
