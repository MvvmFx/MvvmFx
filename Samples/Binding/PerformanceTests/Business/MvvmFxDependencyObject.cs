
namespace PerformanceTests.Business
{
    internal class MvvmFxDependencyObject : MvvmFx.Windows.DependencyObject, INumberName
    {
        public static readonly MvvmFx.Windows.DependencyProperty NumberProperty =
            MvvmFx.Windows.DependencyProperty.Register("Number", typeof (int), typeof (MvvmFxDependencyObject));

        public int Number
        {
            get { return (int) GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly MvvmFx.Windows.DependencyProperty FullNameProperty =
            MvvmFx.Windows.DependencyProperty.Register("FullName", typeof (string), typeof (MvvmFxDependencyObject));

        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }
    }
}
