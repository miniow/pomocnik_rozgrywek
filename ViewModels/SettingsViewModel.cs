using Pomocnik_Rozgrywek.Messanger;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Pomocnik_Rozgrywek.ViewModels
{
    class SettingsViewModel: ViewModelBase
    {
        private ObservableCollection<Message> _logs;
        private FlowDocument _logDocument;
        public ObservableCollection<Message> Logs
        {
            get { return _logs; }
            set
            {
                _logs = value;
                OnPropertyChanged(nameof(Logs));
            }
        }
        public ICommand PrintLogsCommand { get; }
        public FlowDocument LogDocument
        {
            get { return _logDocument; }
            set
            {
                _logDocument = value;
                OnPropertyChanged(nameof(LogDocument));
            }
        }
        public SettingsViewModel() 
        {
            messageService = GlobalMessageService.GetMessageService();
            PrintLogsCommand = new ViewModelCommand(PrintLogs);
            LoadLogs();
        }
        private void LoadLogs()
        {
            Logs = messageService.GetMessages();
            UpdateLogDocument();
        }
        private void UpdateLogDocument()
        {
            FlowDocument doc = new FlowDocument();

            foreach (var log in Logs)
            {
                doc.Blocks.Add(new Paragraph(new Run(log.ToString())));
            }

            LogDocument = doc;
        }

        private void PrintLogs(object obj)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource idpSource = LogDocument;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Printing Logs");
            }
        }
    }
}
