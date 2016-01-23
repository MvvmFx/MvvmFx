namespace MvvmFx.Windows.Specifications.Support.Entities.MvvmFxDOs
{
    public class Person : DependencyObject, IPerson
    {
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof (string), typeof (Person));

        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register("Age", typeof (int), typeof (Person));

        public static readonly DependencyProperty GenderProperty =
            DependencyProperty.Register("Gender", typeof (Gender), typeof (Person));

        public static readonly DependencyProperty DetailsProperty =
            DependencyProperty.Register("Details", typeof (string), typeof (Person));

        private static readonly DependencyPropertyKey _addressPropertyKey =
            DependencyProperty.RegisterReadOnly("Address", typeof (IAddress), typeof (Person), new PropertyMetadata());

        public static readonly DependencyProperty AddressProperty =
            _addressPropertyKey.DependencyProperty;

        public Person()
        {
            Address = new Address();
        }

        public string Name
        {
            get { return GetValue(NameProperty) as string; }
            set { SetValue(NameProperty, value); }
        }

        public int Age
        {
            get { return (int) GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public Gender Gender
        {
            get { return (Gender) GetValue(GenderProperty); }
            set { SetValue(GenderProperty, value); }
        }

        public string Details
        {
            get { return GetValue(DetailsProperty) as string; }
            set { SetValue(DetailsProperty, value); }
        }

        public IAddress Address
        {
            get { return GetValue(AddressProperty) as IAddress; }
            private set { SetValue(_addressPropertyKey, value); }
        }
    }
}
