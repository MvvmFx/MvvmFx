using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.ViewModels;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace SimpleParameters.UI
{
    public class ShellViewModelClass : PropertyChangedBase
    {
        private string _buttonDescription = string.Empty;

        public string ButtonDescription
        {
            get { return _buttonDescription; }
            set
            {
                if (value != _buttonDescription)
                {
                    _buttonDescription = value;
                    NotifyOfPropertyChange(() => ButtonDescription);
                }
            }
        }
    }

    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        private ButtonViewModel _buttonViewModel;
        private ButtonParameterViewModel _buttonParameterViewModel;
        private MenuStripViewModel _menuStripViewModel;
        private ToolStripViewModel _toolStripViewModel;

        private string _buttonNr = string.Empty;

        public string ButtonNr
        {
            get { return _buttonNr; }
            set
            {
                if (value != _buttonNr)
                {
                    _buttonNr = value;
                    NotifyOfPropertyChange(() => ButtonNr);
                }
            }
        }

        public ShellViewModel()
        {
            DisplayName = "Simple Parameter Demo";
            Model = new ShellViewModelClass();
            ((ShellViewModelClass) Model).ButtonDescription = "This is a property on the Model object.";
            ButtonNr = "0";
        }

        public void ShowButtonTest()
        {
            ((ShellViewModelClass) Model).ButtonDescription = "showButtonTest pressed.";
            ButtonNr = "1";
            if (_buttonViewModel == null)
                _buttonViewModel = new ButtonViewModel();
            ActiveItem = _buttonViewModel;
        }

        public void ShowButtonParameterTest()
        {
            ((ShellViewModelClass) Model).ButtonDescription = "showButtonParameterTest pressed.";
            ButtonNr = "2";
            if (_buttonParameterViewModel == null)
                _buttonParameterViewModel = new ButtonParameterViewModel();
            ActiveItem = _buttonParameterViewModel;
        }

        public void ShowMenuStripTest()
        {
            ((ShellViewModelClass) Model).ButtonDescription = "showMenuStripTest pressed.";
            ButtonNr = "3";
            if (_menuStripViewModel == null)
                _menuStripViewModel = new MenuStripViewModel();
            ActiveItem = _menuStripViewModel;
        }

        public void ShowToolStripTest()
        {
            ((ShellViewModelClass) Model).ButtonDescription = "showToolStripTest pressed.";
            ButtonNr = "4";
#if !WISEJ
            if (_toolStripViewModel == null)
                _toolStripViewModel = new ToolStripViewModel();
            ActiveItem = _toolStripViewModel;
#else
            MessageBox.Show("Option disabled under Wisej.","Alert");
#endif
        }

        public object Model { get; set; }
    }
}