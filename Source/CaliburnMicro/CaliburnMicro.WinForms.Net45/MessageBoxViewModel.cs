namespace MvvmFx.CaliburnMicro
{
    public class MessageBoxViewModel : Screen, IMessageBox
    {
        private MessageBoxOptions _selection;

        public bool OkVisible
        {
            get { return IsVisible(MessageBoxOptions.OK); }
        }

        public bool CancelVisible
        {
            get { return IsVisible(MessageBoxOptions.Cancel); }
        }

        public bool YesVisible
        {
            get { return IsVisible(MessageBoxOptions.Yes); }
        }

        public bool NoVisible
        {
            get { return IsVisible(MessageBoxOptions.No); }
        }

        public string Message { get; set; }

        public MessageBoxOptions Options { get; set; }

        public void OK()
        {
            Select(MessageBoxOptions.OK);
        }

        public void Cancel()
        {
            Select(MessageBoxOptions.Cancel);
        }

        public void Yes()
        {
            Select(MessageBoxOptions.Yes);
        }

        public void No()
        {
            Select(MessageBoxOptions.No);
        }

        public bool WasSelected(MessageBoxOptions option)
        {
            return (_selection & option) == option;
        }

        private bool IsVisible(MessageBoxOptions option)
        {
            return (Options & option) == option;
        }

        private void Select(MessageBoxOptions option)
        {
            _selection = option;
            TryClose();
        }
    }
}