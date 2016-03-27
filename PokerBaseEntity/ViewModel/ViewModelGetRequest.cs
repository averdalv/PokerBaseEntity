using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        private string _nameFilter;
        private string _lastNameFilter;
        private string _cityFilter;
        private string _dobFilter;

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

        public string NameFilter
        {
            get
            {
                return _nameFilter;
            }
            set
            {
                if (value != _nameFilter)
                {
                    _nameFilter = value;
                    OnPropertyChanged("NameFilter");
                }
            }
        }
        public string LastNameFilter
        {
            get
            {
                return _lastNameFilter;
            }
            set
            {
                if (value != _lastNameFilter)
                {
                    _lastNameFilter = value;
                    OnPropertyChanged("LastNameFilter");
                }
            }
        }
        public string CityFilter
        {
            get
            {
                return _cityFilter;
            }
            set
            {
                if (value != _cityFilter)
                {
                    _cityFilter = value;
                    OnPropertyChanged("CityFilter");
                }
            }
        }
        public string DOBFilter
        {
            get
            {
                return _dobFilter;
            }
            set
            {
                if (value != _dobFilter)
                {
                    _dobFilter = value;
                    OnPropertyChanged("DOBFilter");
                }
            }
        }
        public ObservableCollection<DataBaseViewModel> Collection { get; set; }
        
        public ICommand ShowList { get; set; }
        public ICommand ShowAll { get; set; }

        public ViewModelGetRequest()
        {
            ShowList=new RelayCommand(arg=>OpenList());
            ShowAll=new RelayCommand(arg=>OpenAll());
            Collection = new ObservableCollection<DataBaseViewModel>();
        }

        

        private void OpenList()
        {
            Collection.Clear();
            
            List<DataBase> list = DataBase.GetPlayers(Name,LastName,City,DOB);
            foreach (var a in list)
            {
                DataBaseViewModel db = new DataBaseViewModel(a);
                Collection.Add(db);
            }
             
           
        }

        private void OpenAll()
        {
            Collection.Clear();
            List<DataBase> list = DataBase.GetAll();
            foreach (var a in list)
            {
                DataBaseViewModel db = new DataBaseViewModel(a);
                Collection.Add(db);
            }
             //Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));     
        }       
    }
}
