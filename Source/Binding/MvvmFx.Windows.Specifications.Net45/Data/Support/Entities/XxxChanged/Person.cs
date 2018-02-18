using System;
using Kent.Boogaart.HelperTrinity.Extensions;

namespace MvvmFx.Bindings.Specifications.Support.Entities.XxxChanged
{
    public class Person : IPerson
    {
        private string _name;
        private int _age;
        private Gender _gender;
        private string _details;
        private readonly IAddress _address;

        public Person()
        {
            _address = new Address();
        }

        public event EventHandler<EventArgs> NameChanged;

        public event EventHandler AgeChanged;

        public event EventHandler<EventArgs> GenderChanged;

        public event EventHandler DetailsChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NameChanged.Raise(this, EventArgs.Empty);
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
                    AgeChanged.Raise(this, EventArgs.Empty);
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
                    GenderChanged.Raise(this, EventArgs.Empty);
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
                    DetailsChanged.Raise(this, EventArgs.Empty);
                }
            }
        }

        public IAddress Address
        {
            get { return _address; }
        }
    }
}
