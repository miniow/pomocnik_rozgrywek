using Pomocnik_Rozgrywek.CustomControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace Pomocnik_Rozgrywek.Messanger
{
    public class GlobalMessageService
    {
        private static GlobalMessageService _instance;
        private ObservableCollection<Message> _messages;
        private readonly string _messageFilePath = "messages.txt";

        private GlobalMessageService()
        {
            _messages = new ObservableCollection<Message>();
            LoadMessagesAsync().Wait();
        }
        ~GlobalMessageService()
        {
            SaveMessagesAsync();
        }
        public static GlobalMessageService GetMessageService()
        {
            if (_instance == null)
            {
                _instance = new GlobalMessageService();
            }
            return _instance;
        }

        public void AddMessage(Message message)
        {
            _messages.Add(message);
            ShowMessage(message);
        }

        private void ShowMessage(Message message)
        {
            var messageControl = new MessageControl();
            messageControl.SetMessage(message);
            var popup = new Popup
            {
                Child = messageControl,
                Placement = PlacementMode.Top,
                StaysOpen = false,
                AllowsTransparency = true,
                VerticalOffset = 10,
                HorizontalOffset = SystemParameters.WorkArea.Width / 2 - 200 
            };

            popup.IsOpen = true;
        }

        public ObservableCollection<Message> GetMessages()
        {
            return new ObservableCollection<Message>(_messages.TakeLast(40));
        }
        private async Task SaveMessageAsync(Message message)
        {
            try
            {
                var messageLine = $"{message.GetType().Name}|{message.Date:O}|{message.Text}\n";
                await File.AppendAllTextAsync(_messageFilePath, messageLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving message: {ex.Message}");
            }
        }

        private async Task SaveMessagesAsync()
        {
            try
            {
                var messageLines = _messages.Select(m => $"{m.GetType().Name}|{m.Date:O}|{m.Text}\n");
                await File.WriteAllLinesAsync(_messageFilePath, messageLines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving messages: {ex.Message}");
            }
        }
        private async Task LoadMessagesAsync()
        {
            try
            {
                if (File.Exists(_messageFilePath))
                {
                    var lines = await File.ReadAllLinesAsync(_messageFilePath);
                    var messages = lines.Select(line =>
                    {
                        var parts = line.Split('|');
                        var messageType = parts[0];
                        var date = DateTime.Parse(parts[1]);
                        var text = parts[2];

                        return CreateMessage(messageType, date, text);
                    }).TakeLast(40);

                    foreach (var message in messages)
                    {
                        _messages.Add(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading messages: {ex.Message}");
            }
        }
        private Message CreateMessage(string messageType, DateTime date, string text)
        {
            Message message = messageType switch
            {
                nameof(ValidationMessage) => new ValidationMessage { Date = date, Text = text },
                nameof(ErrorMessage) => new ErrorMessage { Date = date, Text = text },
                nameof(WarningMessage) => new WarningMessage { Date = date, Text = text },
                nameof(SuccessMessage) => new SuccessMessage { Date = date, Text = text },
                nameof(InfoMessage) => new InfoMessage { Date = date, Text = text },
                _ => throw new InvalidOperationException($"Unknown message type: {messageType}")
            };

            return message;
        }
    }
}

