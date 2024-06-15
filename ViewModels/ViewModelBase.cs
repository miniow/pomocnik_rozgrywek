﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Pomocnik_Rozgrywek.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public delegate void ChangeViewEventHandler(object sender, EventArgs e);
        public event ChangeViewEventHandler ChangeViewRequested;

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
