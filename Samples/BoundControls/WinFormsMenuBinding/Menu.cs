using System.ComponentModel;

namespace BoundControls.Business
{
    public class Menu : INotifyPropertyChanged
    {
        #region Constructor

        public Menu(string name, string text, string toolTipText, bool enabled, bool visible)
        {
            Name = name;
            Text = text;
            ToolTipText = toolTipText;
            Enabled = enabled;
            Visible = visible;
        }

        #endregion

        #region private fields

        private string _name;
        private string _text;
        private string _toolTipText;
        private bool _enabled;
        private bool _visible;

        #endregion

        #region Properties

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

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string ToolTipText
        {
            get { return _toolTipText; }
            set
            {
                if (_toolTipText != value)
                {
                    _toolTipText = value;
                    OnPropertyChanged("ToolTipText");
                }
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                if (_enabled != value)
                {
                    _enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}