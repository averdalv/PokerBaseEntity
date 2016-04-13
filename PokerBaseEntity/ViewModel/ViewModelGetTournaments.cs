using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using PokerBaseEntity.Model;
using PokerBaseEntity.View;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
namespace PokerBaseEntity.ViewModel
{
    class ViewModelGetTournaments:ViewModelBase,IDataErrorInfo
    {
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
                    case "Date":
                        {
                            DateTime t;

                            if (!string.IsNullOrWhiteSpace(Date) && !DateTime.TryParse(Date, out t))
                            {
                                error = "Incorrect date format";
                            }
                            else error = null;

                            break;
                        }
                   /* case "Payment":
                        {
                            int p;

                            if (!Int32.TryParse(Payment, out p) || p < 0 || p > Int32.MaxValue) { error = "Incorrect payment"; }
                            else error = null;
                            break;
                        }*/
                }
                return error;
            }
        }
        string _name;
        string _organization;
        string _city;
        string _date;
        public string TournamentName
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
                   OnPropertyChanged("TournamentName");
                }
            }
        }
        public string Organization
        {
            get
            {
                return _organization;
            }
            set
            {
                if (value != _organization)
                {
                    _organization = value;
                    OnPropertyChanged("Organization");
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
        public string Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        private ObservableCollection<DataBaseTournament> _tournaments;
        private ObservableCollection<DataBaseTournament> _fullTournaments;
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
        public ObservableCollection<DataBaseTournament> FullTournaments
        {
            get { return _fullTournaments; }

            set
            {
                if (_fullTournaments != value)
                {
                    _fullTournaments = value;
                    OnPropertyChanged("FullTournaments");
                }
            }
        }
        public ICommand ShowAllTournaments { get; set; }
        public ICommand ShowList { get; set; }
        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }


        public static readonly DependencyProperty FilterProperty =
            DependencyProperty.Register("Filter", typeof(string), typeof(ViewModelGetTournaments), new PropertyMetadata(null, Filter_Changed));

        private static void Filter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as ViewModelGetTournaments;
            if (current != null)
            {
                string str = current.Filter;
                string[] split = str.Split(new Char[] { ' ' });
                string nameFlt = split.Length >= 1 ? split[0] : "";
                string cityFlt = split.Length >= 2 ? split[1] : "";
                string dateFlt = split.Length >= 3 ? split[2] : "";
                string orgFlt = split.Length >= 4 ? split[3] : "";
                current.Tournaments = new ObservableCollection<DataBaseTournament>(current.FullTournaments.Where(b => b.TournamentName.Contains(nameFlt) &&
                    b.City.Contains(cityFlt) && b.DATE.Contains(dateFlt) && b.Organization.Contains(orgFlt)));
            }
        }


        public int Payment
        {
            get { return (int)GetValue(PaymentProperty); }
            set { SetValue(PaymentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Payment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PaymentProperty =
            DependencyProperty.Register("Payment", typeof(int), typeof(ViewModelGetTournaments), new PropertyMetadata(0, Payment_Changed));

        private static void Payment_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as ViewModelGetTournaments;
            if(current!=null)
            {
                current.Tournaments = new ObservableCollection<DataBaseTournament>(current.FullTournaments.Where(b => b.Payment >=current.Payment));
            }
        }
        
        public ViewModelGetTournaments()
        {
            Tournaments = new ObservableCollection<DataBaseTournament>();
            FullTournaments = new ObservableCollection<DataBaseTournament>();
            ShowAllTournaments = new RelayCommand(arg => ShowAll());
            ShowList = new RelayCommand(arg => Show(), arg => CanShow());
        }
        private void Show()
        {
            try
            {
                DateTime DOB;
                if (Date == null) DOB = default(DateTime);
                else DOB = DateTime.Parse(Date);
                List<DataBaseTournament> list = DataBaseTournament.GetTourtnaments(Payment, false, DOB, City, Organization, TournamentName);
                Tournaments = new ObservableCollection<DataBaseTournament>(list);
                FullTournaments = Tournaments;
              
            }
            catch(Exception ex)
            {
                List<DataBaseTournament> list = DataBaseTournament.GetTourtnaments();
                Tournaments = new ObservableCollection<DataBaseTournament>(list);
                FullTournaments = Tournaments;
            }
        }
        private void ShowAll()
        {
            List<DataBaseTournament> list = DataBaseTournament.GetTourtnaments();
            Tournaments = new ObservableCollection<DataBaseTournament>(list);
            FullTournaments = Tournaments;
        }
        private bool CanShow()
        {
            return (error==null) && (!string.IsNullOrWhiteSpace(TournamentName) || !string.IsNullOrWhiteSpace(City) || !string.IsNullOrWhiteSpace(Date) || !string.IsNullOrWhiteSpace(Organization));
        }
    }
}
