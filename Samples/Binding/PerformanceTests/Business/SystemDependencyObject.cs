
namespace PerformanceTests.Business
{
    internal class SystemDependencyObject : System.Windows.DependencyObject, INumberName
    {
        public static readonly System.Windows.DependencyProperty NumberProperty =
            System.Windows.DependencyProperty.Register("Number", typeof (int), typeof (SystemDependencyObject));

        public int Number
        {
            get { return (int) GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly System.Windows.DependencyProperty FullNameProperty =
            System.Windows.DependencyProperty.Register("FullName", typeof (string), typeof (SystemDependencyObject));

        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }
    }
}
