using Pomocnik_Rozgrywek.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pomocnik_Rozgrywek.Messanger
{

    public abstract class Message
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public Message() {
            this.Date = DateTime.Now;
        }
    }

    public class ValidationMessage : Message
    {
    }
    public class ErrorMessage : Message
    {
    }
    public class WarningMessage : Message
    {
    }
    public class SuccessMessage : Message
    {
    }
    public class InfoMessage : Message
    {
    }
}
