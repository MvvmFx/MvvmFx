namespace DpTests.Entities.SystemDOs
{
    public class Person : System.Windows.DependencyObject, IPerson
    {
        public static readonly System.Windows.DependencyProperty NameProperty =
            System.Windows.DependencyProperty.Register("Name", typeof (string), typeof (Person));

        public static readonly System.Windows.DependencyProperty AgeProperty =
            System.Windows.DependencyProperty.Register("Age", typeof (int), typeof (Person));

        public static readonly System.Windows.DependencyProperty GenderProperty =
            System.Windows.DependencyProperty.Register("Gender", typeof (Gender), typeof (Person));

        public static readonly System.Windows.DependencyProperty DetailsProperty =
            System.Windows.DependencyProperty.Register("Details", typeof (string), typeof (Person));

        private static readonly System.Windows.DependencyPropertyKey _addressPropertyKey =
            System.Windows.DependencyProperty.RegisterReadOnly("Address", typeof (IAddress), typeof (Person),
                                                               new System.Windows.FrameworkPropertyMetadata());

        public static readonly System.Windows.DependencyProperty AddressProperty =
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
