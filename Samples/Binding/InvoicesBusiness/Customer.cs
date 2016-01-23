using System.ComponentModel;

namespace InvoicesBusiness
{
    public class Customer : INotifyPropertyChanged
    {
        private string _name = "Antoine Cadillac";
        private Address _address;
        private Invoice _invoice;

        public Customer()
        {
            _address = new Address();
            _invoice = new Invoice();
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

        public Address Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }

        public Invoice Invoice
        {
            get { return _invoice; }
            set
            {
                if (_invoice != value)
                {
                    _invoice = value;
                    OnPropertyChanged("Invoice");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName)
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
}
