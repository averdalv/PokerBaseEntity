using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PokerBaseEntity.View;

namespace PokerBaseEntity.ViewModel
{
    class ViewModelMainWindow:ViewModelBase
    {
        public ICommand OpenGetRequest { get; set; }

        public ViewModelMainWindow()
        {
            OpenGetRequest=new RelayCommand(arg=>ShowGetRequest());
        }

        private void ShowGetRequest()
        {
            GetRequestWindow wnd=new GetRequestWindow();
            ViewModelGetRequest Vm=new ViewModelGetRequest();
            Show(Vm, wnd);
        }
    }
}
