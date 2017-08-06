using System;
using System.Collections.Generic;
#if WINFORMS
using System.Windows.Forms;
#else
using Wisej.Web;
using Wisej.Base;
#endif
using MvvmFx.CaliburnMicro;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace AcyncUpdate.UI
{
    public interface IAsyncUpdateViewModel : IScreen
    {
    }

    public class AsyncUpdateViewModel : Screen, IAsyncUpdateViewModel
    {
        protected override void OnInitialize()
        {
            DisplayName = "Async Update Demo";
        }

        private bool _close = false;

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            if (_close)
                TryClose();
        }

        private bool _customerNameReadOnly = false;

        public bool IsCustomerNameReadOnly
        {
            get { return _customerNameReadOnly; }
            set
            {
                if (value != _customerNameReadOnly)
                {
                    _customerNameReadOnly = value;
                    NotifyOfPropertyChange(() => IsCustomerNameReadOnly);
                }
            }
        }

        private bool _canDataEntry = true;

        public bool CanDataEntry
        {
            get { return _canDataEntry; }
            set
            {
                if (value != _canDataEntry)
                {
                    _canDataEntry = value;
                    NotifyOfPropertyChange(() => CanDataEntry);
                }
            }
        }

        public void DataEntry()
        {
        }

        private string _customerId;

        public string CustomerId
        {
            get { return _customerId; }
            set
            {
                if (value != _customerId)
                {
                    _customerId = value;
                    NotifyOfPropertyChange(() => CustomerId);
                }
            }
        }

        private string _customerNumber;

        public string CustomerNumber
        {
            get { return _customerNumber; }
            set
            {
                if (value != _customerNumber)
                {
                    _customerNumber = value;
                    NotifyOfPropertyChange(() => CustomerNumber);
                    NotifyOfPropertyChange(() => CanGetId);
                }
            }
        }

        private string _customerName;

        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                if (value != _customerName)
                {
                    _customerName = value;
                    NotifyOfPropertyChange(() => CustomerName);
                    NotifyOfPropertyChange(() => CanGetId);
                }
            }
        }

        public bool CanQuit(string customerId)
        {
            return !string.IsNullOrEmpty(customerId);
        }

        public void Quit(string customerId)
        {
            Exit(customerId);
        }

        public bool CanExit(string customerId)
        {
            return !string.IsNullOrEmpty(customerId);
        }

        public void Exit(string customerId)
        {
            // not very MVVM friendly MessageBox. Don't do this at work.
            MessageBox.Show("Closing Customer Id: " + customerId);
            TryClose();
        }

        public bool CanGetId
        {
            get { return !string.IsNullOrEmpty(CustomerName) && !string.IsNullOrEmpty(CustomerNumber); }
        }

        public IEnumerable<IResult> GetId()
        {
            IsCustomerNameReadOnly = true;
            CustomerIdResult result;
#if WINFORMS
            result = new CustomerIdResult();
#else
            result = new CustomerIdResult((Form) GetView());
#endif

            CanDataEntry = false;
            yield return Show.Busy("Generating Customer Id");
            yield return result;

            CustomerId = result.Response.ToString();
            yield return Show.NotBusy();
            CanDataEntry = true;
        }
    }

    public class CustomerIdResult : IResult
    {
#if WISEJ
        private Form _view;

        public CustomerIdResult(Form view)
        {
            _view = view;
        }
#endif

        public Guid Response { get; set; }

        public void Execute(ActionExecutionContext context)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(state =>
            {
                System.Threading.Thread.Sleep(2000);

                Response = Guid.NewGuid();
                Completed(this, new ResultCompletionEventArgs());
#if WISEJ
                ApplicationBase.Update(_view);
#endif
            });
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };
    }
}