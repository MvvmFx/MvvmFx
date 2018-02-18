
namespace PerformanceTests.Business
{
    internal class MvvmFxDependencyObject : MvvmFx.Bindings.DependencyObject, INumberName
    {
        public static readonly MvvmFx.Bindings.DependencyProperty NumberProperty =
            MvvmFx.Bindings.DependencyProperty.Register("Number", typeof (int), typeof (MvvmFxDependencyObject));

        public int Number
        {
            get { return (int) GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly MvvmFx.Bindings.DependencyProperty FullNameProperty =
            MvvmFx.Bindings.DependencyProperty.Register("FullName", typeof (string), typeof (MvvmFxDependencyObject));

        public string FullName
        {
            get { return (string)GetValue(FullNameProperty); }
            set { SetValue(FullNameProperty, value); }
        }
    }
}
