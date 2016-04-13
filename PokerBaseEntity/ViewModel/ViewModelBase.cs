using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokerBaseEntity.ViewModel
{
    class ViewModelBase: DependencyObject,INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        /*protected Window _window=null;
        protected virtual void Show(ViewModelBase viewModel,Window wnd)
        {
            viewModel._window = wnd;
            viewModel._window.Show();
        }
    */
    }
}
