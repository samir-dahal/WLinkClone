using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WLinkClone
{
    public class ObservableBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void Dispose()
        {
        }

        public void OnPropertyChanged(string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
