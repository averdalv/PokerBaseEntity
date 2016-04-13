using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PokerBaseEntity.View;
using System.Windows;

namespace PokerBaseEntity.ViewModel
{
    class ViewModelMainWindow:ViewModelBase
    {
        Window wnd;
        public ICommand OpenGetRequest { get; set; }
        public ICommand OpenGetTournaments { get; set; }

        public ViewModelMainWindow()
        {
            OpenGetRequest=new RelayCommand(arg=>ShowGetRequest());
            OpenGetTournaments = new RelayCommand(arg => ShowTournaments());
        }

        private void ShowGetRequest()
        {
            wnd=new GetRequestWindow();
            ViewModelGetRequest Vm=new ViewModelGetRequest();
            wnd.DataContext = Vm;
            wnd.Show();
        }
        private void ShowTournaments()
        {
            wnd = new GetTournamWindow();
            ViewModelGetTournaments Vm = new ViewModelGetTournaments();
            wnd.DataContext = Vm;
            wnd.Show();
        } 
    }
}
