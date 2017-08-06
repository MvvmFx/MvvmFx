using System;
using System.Collections.Generic;
using MvvmFx.CaliburnMicro;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
#endif

namespace AcyncUpdate.UI
{
    public class BusyResult : IResult
    {
        private readonly bool _hide;
        private readonly string _message;

        public BusyResult(bool hide)
            : this(hide, string.Empty)
        {
        }

        public BusyResult(bool hide, string message)
        {
            _hide = hide;
            _message = message;
        }

        public void Execute(ActionExecutionContext context)
        {
            var view = context.View.Object as Control;
            while (view != null)
            {
                var indicator = view as IHaveBusyIndicator;
                if (indicator != null)
                {
                    indicator.Indicator.IsBusy = !_hide;
                    indicator.Indicator.BusyContent = _message;
                    break;
                }
                view = view.Parent;
            }

            if (view == null)
            {
                var queue = new Queue<Control>();
                queue.Enqueue(Form.ActiveForm);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    if (current == null)
                        continue;

                    var indicator = current as BusyIndicator;
                    if (indicator != null)
                    {
                        indicator.IsBusy = !_hide;
                        break;
                    }

                    var count = current.Controls.Count;
                    for (var i = 0; i < count; i++)
                    {
                        queue.Enqueue(current.Controls[i]);
                    }
                }
            }

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}