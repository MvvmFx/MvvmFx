using System;
using MvvmFx.CaliburnMicro;

namespace CslaSample.Framework
{
    public class ApplicationCloseCheck : IResult
    {
        private readonly Action<Action<bool>> _closeCheck;

        public ApplicationCloseCheck(IChild screen, Action<Action<bool>> closeCheck)
        {
            _closeCheck = closeCheck;
        }

        public void Execute(ActionExecutionContext context)
        {
            _closeCheck(result => Completed(this, new ResultCompletionEventArgs {WasCancelled = !result}));
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}