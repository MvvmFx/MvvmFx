using System;
using System.Collections.Generic;
using System.Linq;
using CslaSample.Documents;
using MvvmFx.CaliburnMicro;

namespace CslaSample.Framework
{
    public class ApplicationCloseStrategy : ICloseStrategy<DocumentListViewModel>
    {
        private IEnumerator<DocumentListViewModel> _enumerator;
        private bool _finalResult;
        private Action<bool, IEnumerable<DocumentListViewModel>> _callback;

        public void Execute(IEnumerable<DocumentListViewModel> toClose,
            Action<bool, IEnumerable<DocumentListViewModel>> callback)
        {
            _enumerator = toClose.GetEnumerator();
            _callback = callback;
            _finalResult = true;

            Evaluate(_finalResult);
        }

        private void Evaluate(bool result)
        {
            _finalResult = _finalResult && result;

            if (!_enumerator.MoveNext() || !result)
                _callback(_finalResult, new List<DocumentListViewModel>());
            else
            {
                var current = _enumerator.Current;
                var conductor = (IConductor) current;
                if (conductor != null)
                {
                    var tasks = conductor.GetChildren()
                        .OfType<IHaveShutdownTask>()
                        .Select(x => x.GetShutdownTask())
                        .Where(x => x != null);

                    var sequential = new SequentialResult(tasks.GetEnumerator());
                    sequential.Completed += (s, e) =>
                    {
                        if (!e.WasCancelled)
                            Evaluate(!e.WasCancelled);
                    };
                    sequential.Execute(new ActionExecutionContext());
                }
                else
                {
                    Evaluate(true);
                }
            }
        }
    }
}