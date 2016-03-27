using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerBaseEntity.Model;

namespace PokerBaseEntity.ViewModel
{
    class DataBaseViewModel : ViewModelBase
    {
        public DataBase dataBase;

        public DataBaseViewModel(DataBase dBase)
        {
            dataBase = dBase;
            Name = dataBase.Name;
            LastName = dataBase.LastName;
            City = dataBase.City;
            DOB = dataBase.DOB;
            Image = dataBase.Image;
        }

        private string _name;
        private string _lastName;
        private string _city;
        private DateTime _dob;
        private string _image;
        public string Name
        {
            get { return _name; }
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
            get { return _lastName; }
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
            get { return _city; }
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
            get { return _dob; }
            set
            {
                if (value != _dob)
                {
                    _dob = value;
                    OnPropertyChanged("DOB");
                }
            }
        }

        public string Image
        {
            get { return _image; }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
    }
}
