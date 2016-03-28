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
        private readonly DataBase dataBase;

        public DataBaseViewModel(DataBase dBase)
        {
            dataBase = dBase;
            Name = dataBase.Name;
            LastName = dataBase.LastName;
            City = dataBase.City;
            DOB = dataBase.DOB;
            DateOfBirth = DOB.Date.ToShortDateString();
            Image = dataBase.Image;
        }

        private string _name;
        private string _lastName;
        private string _city;
        private DateTime _dob;
        private string _image;
        private string _dateOfBirth;
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
    }
}
