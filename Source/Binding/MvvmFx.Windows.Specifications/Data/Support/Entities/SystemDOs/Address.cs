namespace MvvmFx.Windows.Specifications.Support.Entities.SystemDOs
{
    public class Address : System.Windows.DependencyObject, IAddress
    {
        public static readonly System.Windows.DependencyProperty Line1Property =
            System.Windows.DependencyProperty.Register("Line1", typeof (string), typeof (Address));

        public static readonly System.Windows.DependencyProperty Line2Property =
            System.Windows.DependencyProperty.Register("Line2", typeof (string), typeof (Address));

        public static readonly System.Windows.DependencyProperty Line3Property =
            System.Windows.DependencyProperty.Register("Line3", typeof (string), typeof (Address));

        public string Line1
        {
            get { return GetValue(Line1Property) as string; }
            set { SetValue(Line1Property, value); }
        }

        public string Line2
        {
            get { return GetValue(Line2Property) as string; }
            set { SetValue(Line2Property, value); }
        }

        public string Line3
        {
            get { return GetValue(Line3Property) as string; }
            set { SetValue(Line3Property, value); }
        }
    }
}
