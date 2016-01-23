namespace MvvmFx.Windows.Specifications.Support.Entities.MvvmFxDOs
{
    public class Address : DependencyObject, IAddress
    {
        public static readonly DependencyProperty Line1Property =
            DependencyProperty.Register("Line1", typeof (string), typeof (Address));

        public static readonly DependencyProperty Line2Property =
            DependencyProperty.Register("Line2", typeof (string), typeof (Address));

        public static readonly DependencyProperty Line3Property =
            DependencyProperty.Register("Line3", typeof (string), typeof (Address));

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
