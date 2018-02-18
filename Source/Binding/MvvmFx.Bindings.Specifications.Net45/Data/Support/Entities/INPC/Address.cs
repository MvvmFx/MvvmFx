namespace MvvmFx.Bindings.Specifications.Support.Entities.INPC
{
    public class Address : EntityBase, IAddress
    {
        private string _line1;
        private string _line2;
        private string _line3;

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
    }
}
