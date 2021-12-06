using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceDapper.Domain.ViewModels
{
    public class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public static event PropertyChangedEventHandler PropChan;

        protected static void OnPropChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropChan;
            if (handler != null)
            {
                handler(new BaseViewModel(), new PropertyChangedEventArgs(name));
            }
        }
    }
}
