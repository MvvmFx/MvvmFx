namespace MvvmFx.Bindings.Specifications.Support.Entities.INPC
{
    public sealed class Person : EntityBase, IPerson
    {
        private string _name;
        private int _age;
        private Gender _gender;
        private string _details;
        private readonly Address _address;

        public Person()
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

        public int Age
        {
            get { return _age; }
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged("Age");
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

        public string Details
        {
            get { return _details; }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged("Details");
                }
            }
        }

        public IAddress Address
        {
            get { return _address; }
        }
    }
}
