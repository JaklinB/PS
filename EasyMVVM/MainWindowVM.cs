using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EasyMVVM
{
    public class MainWindowVM : DependencyObject, INotifyPropertyChanged
    {
        private ObservableCollection<string> _BackingProperty;

        public MainWindowVM()
        {
            Model m = new Model();
            BoundProperty = m.GetData();
        }

        public ObservableCollection<string> BackingProperty {
            get { return _BackingProperty; } 
        }

        public ObservableCollection<string> BoundProperty
        {
            get { return _BackingProperty; }
            set { _BackingProperty = value;
                    PropChanged("BoundProperty"); }
        }

        public void PropChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
