using MvvmFx.CaliburnMicro;

namespace AcyncUpdate.UI
{
    public static class Show
    {
        public static IResult Busy(string message)
        {
            return new BusyResult(false, message);
        }

        public static IResult NotBusy()
        {
            return new BusyResult(true);
        }
    }
}