using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PokerBaseEntity.View;
using PokerBaseEntity.Model;
namespace PokerBaseEntity.ViewModel
{
    class ViewModelGetRequest:ViewModelBase
    {
        private string _name;
        private string _lastName;
        private string _city;
        private DateTime _dob;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                if (value != _dob)
                {
                    _dob = value;
                    OnPropertyChanged("DOB");
                }
            }
        }

        public ObservableCollection<DataBase> Collection { get; set; }
        public ICommand ShowList { get; set; }
        public ICommand ShowAll { get; set; }

        public ViewModelGetRequest()
        {
            ShowList=new RelayCommand(arg=>OpenList());
            ShowAll=new RelayCommand(arg=>OpenAll());
            Collection = DataBase.GetAll();

        }

        private void OpenList()
        {
            Collection = DataBase.GetPlayers(Name, LastName, City, DOB);
        }

        private void OpenAll()
        {
            Collection = DataBase.GetAll();
            
        }

       
    }
}
