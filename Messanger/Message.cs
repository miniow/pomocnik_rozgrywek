using Pomocnik_Rozgrywek.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;

namespace Pomocnik_Rozgrywek.Messanger
{

    public abstract class Message
    {
        public string? Text { get; set; }
        public DateTime Date { get; set; }
        public Message() {
            this.Date = DateTime.Now;
        }
        public override string ToString()
        {
            return new string (Date.ToString() + " "+ this.Text + "\n");
        }
    }

    public class ValidationMessage : Message
    {
        public ValidationMessage() : base() { }
        public ValidationMessage(string text) : base() { this.Text = text; }
    }
    public class ErrorMessage : Message
    {
        public ErrorMessage() : base() { }
        public ErrorMessage(string text) : base() { this.Text = text; }
    }
    public class WarningMessage : Message
    {
        public WarningMessage() : base() { }
        public WarningMessage(string text) : base() { this.Text = text; }
    }
    public class SuccessMessage : Message
    {
        public SuccessMessage() : base() { }
        public SuccessMessage(string text) : base() { this.Text = text; }
    }
    public class InfoMessage : Message
    {
        public InfoMessage() : base() { }
        public InfoMessage(string text) : base() { this.Text = text; }
    }
}
