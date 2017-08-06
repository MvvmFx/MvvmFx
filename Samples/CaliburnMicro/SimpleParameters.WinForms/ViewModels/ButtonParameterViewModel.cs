using System;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MvvmFx.CaliburnMicro;
using SimpleParameters.UI.Views;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace SimpleParameters.UI.ViewModels
{
    public class ButtonParameterViewModel : Screen
    {
        private string _boundLabel;

        public string BoundLabel
        {
            get { return _boundLabel; }
            private set
            {
                if (value != _boundLabel)
                {
                    _boundLabel = value;
                    NotifyOfPropertyChange(() => BoundLabel);
                }
            }
        }

        private string _actionDescription;

        public string ActionDescription
        {
            get { return _actionDescription; }
            private set
            {
                if (value != _actionDescription)
                {
                    _actionDescription = value;
                    NotifyOfPropertyChange(() => ActionDescription);
                }
            }
        }

        private string _actionDetail;

        public string ActionDetail
        {
            get { return _actionDetail; }
            private set
            {
                if (value != _actionDetail)
                {
                    _actionDetail = value;
                    NotifyOfPropertyChange(() => ActionDetail);
                }
            }
        }

        public ButtonParameterViewModel()
        {
            DisplayName = "Button Parameter Test Screen";
        }

        public void ShowBindingContext(object obj)
        {
            string helper;

            var dataContext = obj as BindingContext;
            if (dataContext == null)
                helper = "BindingContext is null";
            else
                helper = "Type: " + dataContext.GetType();

            ActionDetail = helper;
            ActionDescription = "BindingContext";
        }

        public void ShowDataContext(object obj)
        {
            string helper;

            var dataContext = obj as IHaveDataContext;
            if (dataContext == null)
                helper = "DataContext is null";
            else
                helper = "Type: " + dataContext.GetType();

            ActionDetail = helper;
            ActionDescription = "DataContext";
        }

        public void ShowEventArgs(object obj)
        {
            string helper;

            var mouseEventArgs = (MouseEventArgs) obj;
            if (mouseEventArgs == null)
                helper = "MouseEventArgs is null";
            else
                helper = "Type: " + mouseEventArgs + Environment.NewLine +
                         "X: " + mouseEventArgs.X + Environment.NewLine +
                         "Y: " + mouseEventArgs.Y;

            ActionDetail = helper;
            ActionDescription = "eventArgs";
        }

        public void ShowSource(object obj)
        {
            string helper;

            var source = (Control) obj;
            if (source == null)
                helper = "source is null";
            else
                helper = "Type: " + source.GetType() + Environment.NewLine +
                         "Name: " + source.Name;

            ActionDetail = helper;
            ActionDescription = "Source";
        }

        public void ShowExecutionContext(object obj)
        {
            string helper;

            var executionContext = (ActionExecutionContext) obj;
            if (executionContext == null)
                helper = "ActionExecutionContext is null";
            else
                helper = "Type: " + executionContext.GetType().Name + Environment.NewLine +
                         "Method name: " + executionContext.Message.MethodName + Environment.NewLine +
                         "Parameter: " + executionContext.Message.Parameters[0].Value;

            ActionDetail = helper;
            ActionDescription = "ActionExecutionContext";
        }

        public void ShowView(object obj)
        {
            string helper;

            var view = (ButtonParameterView) obj;
            if (view == null)
                helper = "View is null";
            else
            {
                helper = "View" + Environment.NewLine +
                         "Type: " + view + Environment.NewLine +
                         "Name: " + view.Name + Environment.NewLine +
                         "ViewModel" + Environment.NewLine +
                         "Type: " + ((IHaveDataContext) view).DataContext.GetType() + Environment.NewLine +
                         "Display name: " + ((Screen) ((IHaveDataContext) view).DataContext).DisplayName;

                if (view.button7.Text == "This.Text")
                {
                    view.button7.Text = "This Text";
                    helper += Environment.NewLine + Environment.NewLine + "This Text button is disabled";
                }
                else
                {
                    view.button7.Text = "This.Text";
                    helper += Environment.NewLine + Environment.NewLine + "This.Text button is ENABLED";
                }
            }

            ActionDetail = helper;
            ActionDescription = "View";
        }

        public bool CanShowThis(object text)
        {
            return text as string == "This.Text";
        }

        public void ShowThis(object obj)
        {
            string helper;

            var text = obj as string;
            if (text == null)
                helper = "$this is null";
            else
                helper = "Button.Text: " + text;

            ActionDetail = helper;
            ActionDescription = "$this.Text";
        }

        public bool CanShowBound(string parameter)
        {
            if (string.IsNullOrWhiteSpace(parameter))
            {
                BoundLabel = "Type here to activate the Bound button";
                return false;
            }

            BoundLabel = "Clear to inactivate the Bound button";
            return true;
        }

        public void ShowBound(string parameter)
        {
            ActionDetail = parameter;
            ActionDescription = "Bound (to the value in the TextBox above)";
        }
    }
}