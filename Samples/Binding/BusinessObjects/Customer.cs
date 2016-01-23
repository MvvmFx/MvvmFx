using System;

namespace BusinessObjects
{
    public class Customer : BusinessObject
    {
        private string _name;
        private Gender _gender;
        private DateTime _birthDate;
        private readonly Address _address;

        public Customer()
        {
            _address = new Address();
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public Gender Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                value = value.Date;

                if (_birthDate != value)
                {
                    _birthDate = value;
                    OnPropertyChanged("BirthDate");
                }
            }
        }

        public Address Address
        {
            get { return _address; }
        }
    }
}
