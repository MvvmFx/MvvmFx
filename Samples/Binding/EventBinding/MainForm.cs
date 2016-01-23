using System;
using System.Windows.Forms;
using MvvmFx.Windows.Data;
using MvvmFx.Windows.Input;
//using BoundCommand = MvvmFx.Windows.Input.BoundCommand;
//using Binding = MvvmFx.Windows.Data.Binding;

namespace EventBinding
{
    public partial class MainForm : Form
    {
        private BoundCommand _saveCommandButton;
        private BoundCommand _saveCommandToolStrip;
        private BoundCommand _closeComamand;
        private string _text = string.Empty;

        public string FullNameText
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    _saveCommandButton.RaiseCanExecuteChanged();
                    _saveCommandToolStrip.RaiseCanExecuteChanged();
                }
            }
        }

        public bool FullNameTextLength
        {
            get { return FullNameText.Length > 0; }
        }

        private bool _saved;

        public bool Saved
        {
            get { return _saved; }
            set
            {
                if (_saved != value)
                {
                    _saved = value;
                    _closeComamand.RaiseCanExecuteChanged();
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Load += OnLoad;
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            try
            {
                var commandBindingManager = new CommandBindingManager();
                var commandBinding = new CommandBinding();
                _saveCommandButton = new BoundCommand(SaveMessage, CanSave, "Button");
                commandBinding.SourceObject = Save;
                commandBinding.SourceEvent = ControlEvent.Click.ToString();
                commandBinding.Command = _saveCommandButton;
                commandBindingManager.CommandBindings.Add(commandBinding);
                _saveCommandToolStrip = new BoundCommand(SaveMessage, CanSave, "ToolStrip");
                commandBindingManager.CommandBindings.Add(new CommandBinding(_saveCommandToolStrip, Tool, ToolStripItemEvent.Click.ToString()));
                _closeComamand = new BoundCommand(Close, CanClose, null);
                commandBindingManager.CommandBindings.Add(new CommandBinding(_closeComamand, CloseForm, ControlEvent.Click.ToString()));

                var bindingManager = new BindingManager();
                bindingManager.Bindings.Add(new TypedBinding<MainForm, TextBox>(this, t => t.FullNameText, FullName, s => s.Text));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool CanSave(object parameter)
        {
            return _text != string.Empty;
        }

        private void SaveMessage(object parameter)
        {
            FullName.Text += " " + parameter;
            MessageBox.Show(parameter + " control triggered", "Command", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Saved = true;
        }

        private bool CanClose(object parameter)
        {
            return _saved;
        }

        private void Close(object parameter)
        {
            Close();
        }
    }
}
