using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PokerBaseEntity.View;
using PokerBaseEntity.Model;
namespace PokerBaseEntity.ViewModel
{
    class ViewModelGetRequest:ViewModelBase,IDataErrorInfo
    {
        #region IDataErrorInfo implementation
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        private string error;
        public string this[string columnName]
        {
            get
            {
               
                switch (columnName)
                {
                    case "DateOfBirth":
                    {
                        DateTime t;
                        
                        if (!string.IsNullOrWhiteSpace(DateOfBirth) && !DateTime.TryParse(DateOfBirth, out t))
                        {
                            error = "Incorrect date format";
                        }
                        else error = null;
                        
                            break;
                    }
                }
                return error;
            }
        }
        #endregion
        private string _name;
        private string _lastName;
        private string _city;
        private DateTime _dob;
        private string _dateOfBirth;

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
        public string DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value != _dateOfBirth)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
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

        private ObservableCollection<DataBaseViewModel> _collection;

        public ObservableCollection<DataBaseViewModel> Collection
        {
            get { return _collection; }

            set
            {
                if (_collection != value)
                {
                    _collection = value;
                    OnPropertyChanged("Collection");
                }
            }
        }
        
        public ICommand ShowList { get; set; }
        public ICommand ShowAll { get; set; }

        public ViewModelGetRequest()
        {
            ShowList=new RelayCommand(arg=>OpenList(),arg=>CanOpenList());
            ShowAll=new RelayCommand(arg=>OpenAll());
            Collection = new ObservableCollection<DataBaseViewModel>();
        }


        private bool CanOpenList()
        {
            return  (error==null)&&(!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(LastName) || !string.IsNullOrWhiteSpace(City) || !string.IsNullOrWhiteSpace(DateOfBirth));
        }
        private void OpenList()
        {
            try
            {
                if (DateOfBirth == null) DOB = default(DateTime);   
                else DOB = DateTime.Parse(DateOfBirth);
            
            List<DataBase> list = DataBase.GetPlayers(Name,LastName,City,DOB);
            Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b))); 
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                List<DataBase> list = DataBase.GetPlayers(Name, LastName, City);
                Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));
                
            }

        }

        private void OpenAll()
        {
           
            List<DataBase> list = DataBase.GetPlayers();
            Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));     
            /*Collection.Clear();
            foreach (var a in list)
            {
                DataBaseViewModel db = new DataBaseViewModel(a);
                Collection.Add(db);
            }*/
             
        }       
    }
}
