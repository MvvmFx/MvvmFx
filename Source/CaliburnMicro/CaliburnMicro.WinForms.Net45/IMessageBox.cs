namespace MvvmFx.CaliburnMicro
{
    public interface IMessageBox : IScreen
    {
        string Message { get; set; }
        MessageBoxOptions Options { get; set; }

        void OK();
        void Cancel();
        void Yes();
        void No();

        bool WasSelected(MessageBoxOptions option);
    }
}