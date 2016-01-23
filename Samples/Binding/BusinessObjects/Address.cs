namespace BusinessObjects
{
    public class Address : BusinessObject
    {
        private string _line1;
        private string _line2;
        private string _line3;
        private string _line4;
        private string _postCode;

        public string Line1
        {
            get { return _line1; }
            set
            {
                if (_line1 != value)
                {
                    _line1 = value;
                    OnPropertyChanged("Line1");
                }
            }
        }

        public string Line2
        {
            get { return _line2; }
            set
            {
                if (_line2 != value)
                {
                    _line2 = value;
                    OnPropertyChanged("Line2");
                }
            }
        }

        public string Line3
        {
            get { return _line3; }
            set
            {
                if (_line3 != value)
                {
                    _line3 = value;
                    OnPropertyChanged("Line3");
                }
            }
        }

        public string Line4
        {
            get { return _line4; }
            set
            {
                if (_line4 != value)
                {
                    _line4 = value;
                    OnPropertyChanged("Line4");
                }
            }
        }

        public string PostCode
        {
            get { return _postCode; }
            set
            {
                if (_postCode != value)
                {
                    _postCode = value;
                    OnPropertyChanged("PostCode");
                }
            }
        }
    }
}
