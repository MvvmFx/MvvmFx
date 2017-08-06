using System;

namespace MvvmFx.CaliburnMicro
{
  /// <summary>
  ///
  /// </summary>
  public interface IDialogManager
  {
    /// <summary>
    /// Shows the dialog.
    /// </summary>
    /// <param name="dialogModel">The dialog model.</param>
    void ShowDialog(IScreen dialogModel);

    /// <summary>
    /// Shows the message box.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="title">The message box title.</param>
    /// <param name="options">The message box options.</param>
    /// <param name="callback">The callback method.</param>
    void ShowMessageBox(string message, string title = null, MessageBoxOptions options = MessageBoxOptions.OK,
      Action<IMessageBox> callback = null);
  }
}