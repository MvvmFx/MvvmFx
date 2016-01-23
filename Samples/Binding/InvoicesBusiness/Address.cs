using System.ComponentModel;

namespace InvoicesBusiness
{
    public abstract class BusinessObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            //thread safe
            PropertyChangedEventHandler handler;
            lock (this)
            {
                handler = PropertyChanged;
            }

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }

            /*var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }*/
        }
    }

    public class Address : BusinessObject
    {
        private string _street = "Elm Street";
        private string _state = "Ohio";
        private string _country = "USA";
        private string _zipCode = "91211";

        public string Street
        {
            get { return _street; }
            set
            {
                if (_street != value)
                {
                    _street = value;
                    OnPropertyChanged("Street");
                }
            }
        }

        public string State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (_zipCode != value)
                {
                    _zipCode = value;
                    OnPropertyChanged("ZipCode");
                }
            }
        }
    }
}
