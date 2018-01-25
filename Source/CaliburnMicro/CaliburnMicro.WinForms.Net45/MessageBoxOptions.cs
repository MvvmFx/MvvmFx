namespace MvvmFx.CaliburnMicro
{
    using System;

    [Flags]
    public enum MessageBoxOptions
    {
        OK = 2,
        Cancel = 4,
        Yes = 8,
        No = 16,

        OKCancel = OK | Cancel,
        YesNo = Yes | No,
        YesNoCancel = Yes | No | Cancel
    }
}