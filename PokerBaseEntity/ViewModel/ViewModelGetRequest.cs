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
using Microsoft.Win32;
using System.Windows.Controls;
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
        private bool _additionalParam;
        public bool AdditionalParam
        {
            get
            {
                return _additionalParam;
            }
            set
            {
                if (value != _additionalParam)
                {
                    _additionalParam = value;
                    OnPropertyChanged("AdditionalParam");
                }
            }
        }
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

        private string imageSave;


        public string Filter
        {
                get { return (string)GetValue(FilterProperty); }
                set { SetValue(FilterProperty, value); }
        }

       
        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(ViewModelGetRequest), new PropertyMetadata(null,Filter_Changed));

        private static void Filter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as ViewModelGetRequest;
            if (current != null)
            {
                string str = current.Filter;
                string []split = str.Split(new Char[]{' '});
                string nameFlt = split.Length >= 1 ? split[0] : "";
                string LnameFlt = split.Length >= 2 ? split[1] : "";
                string cityFlt = split.Length >= 3 ? split[2] : "";
                string dobFlt = split.Length >= 4 ? split[3] : "";
                current.Collection = new ObservableCollection<DataBaseViewModel>(current.FullCollection.Where(b => b.Name.Contains(nameFlt)&&
                    b.LastName.Contains(LnameFlt)&&b.City.Contains(cityFlt)&&b.DateOfBirth.Contains(dobFlt)));
            }
        }     
        
        private ObservableCollection<DataBaseViewModel> _collection;
        private ObservableCollection<DataBaseViewModel> _fullCollection;
        private ObservableCollection<DataBaseTournament> _tournaments;
        public ObservableCollection<DataBaseTournament> Tournaments
        {
            get { return _tournaments; }

            set
            {
                if (_tournaments != value)
                {
                    _tournaments = value;
                    OnPropertyChanged("Tournaments");
                }
            }
        }
        public ObservableCollection<DataBaseViewModel> FullCollection
        {
            get { return _fullCollection; }

            set
            {
                if (_fullCollection != value)
                {
                    _fullCollection = value;
                    OnPropertyChanged("FullCollection");
                }
            }
        }
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
        public ICommand SavePlayer { get; set; }
        public ICommand SelectPhoto { get; set; }
        public ICommand DeletePlayer { get; set; }
        public ICommand SelectedCellChangedCommand { get; set; }
        public ViewModelGetRequest()
        {
            ShowList=new RelayCommand(arg=>OpenList(),arg=>CanOpenList());
            ShowAll=new RelayCommand(arg=>OpenAll());
            SelectPhoto = new RelayCommand(arg => SelectPh());
            SavePlayer = new RelayCommand(arg => Save(),arg=>CanSave());
            DeletePlayer = new RelayCommand(arg => Delete(), arg => CanDelete());
            Collection = new ObservableCollection<DataBaseViewModel>();
            FullCollection = Collection;
            Tournaments = new ObservableCollection<DataBaseTournament>();
            var lst = DataBaseTournament.GetTourtnaments();
            Tournaments = new ObservableCollection<DataBaseTournament>(lst);
            //SelectedCellChangedCommand = new MyCommand(SelectedCellChanged);

        }
        private void Delete()
        {
            try
            {   
                if (DateOfBirth == null) DOB = default(DateTime);
                else DOB = DateTime.Parse(DateOfBirth);
               
                DataBase.DeletePlayer(Name,LastName,City,DOB);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error during adding");
            }
        }
        private bool CanDelete()
        {
            return (error == null) && (!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(LastName) || !string.IsNullOrWhiteSpace(City) || !string.IsNullOrWhiteSpace(DateOfBirth));
        }
        private void SelectedCellChanged(DataGridCellInfo cell)
        {
            DataBaseViewModel DB = cell.Item as DataBaseViewModel;
            MessageBox.Show(DB.Name + " " + DB.LastName);

        }

        private bool CanSave()
        {
            return (error == null) && (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(City) && !string.IsNullOrWhiteSpace(DateOfBirth));
        }
        private void Save()
        {   
            try{
            DateTime dt=DateTime.Parse(DateOfBirth);
                List<DataBaseTournament> DbT;
                if (AdditionalParam)
                    DbT = new List<DataBaseTournament>(Tournaments.Where(p => p.isChecked == true));
                else DbT = null;
                if(imageSave==null)
                    DataBase.SavePlayer(Name, LastName, City, dt, DbT);
                else
            DataBase.SavePlayer(Name, LastName, City, dt, DbT, imageSave);
                imageSave = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error during adding");
            }
        }

        private void SelectPh()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.PNG)|*.JPG;*.PNG" + "|Все файлы (*.*)|*.*";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                imageSave = myDialog.FileName;
                if (imageSave.Substring(imageSave.LastIndexOf(".")+1) != "jpg" && imageSave.Substring(imageSave.LastIndexOf(".")+1) != "png") imageSave = null; ;
            }
        }
        private bool CanOpenList()
        {
            return  (error==null)&&(!string.IsNullOrWhiteSpace(Name) || !string.IsNullOrWhiteSpace(LastName) || !string.IsNullOrWhiteSpace(City) || !string.IsNullOrWhiteSpace(DateOfBirth)||AdditionalParam);
        }
        private void OpenList()
        {
            try
            {
                if (DateOfBirth == null) DOB = default(DateTime);   
                else DOB = DateTime.Parse(DateOfBirth);
                List<DataBaseTournament> tournam=new List<DataBaseTournament>();
                if (AdditionalParam)
                    tournam = new List<DataBaseTournament>(Tournaments.Where(p => p.isChecked == true));
                else tournam = null;
            List<DataBase> list = DataBase.GetPlayers(Name,LastName,City,DOB,tournam);
            Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));
            FullCollection = Collection;
            }
            catch(ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (FormatException ex)
            {
                List<DataBase> list = DataBase.GetPlayers(Name, LastName, City);
                Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));
                FullCollection = Collection;
                
            }

        }

        private void OpenAll()
        {
           
            List<DataBase> list = DataBase.GetPlayers();
            Collection = new ObservableCollection<DataBaseViewModel>(list.Select(b => new DataBaseViewModel(b)));
            FullCollection = Collection;
        }       
    }
}
