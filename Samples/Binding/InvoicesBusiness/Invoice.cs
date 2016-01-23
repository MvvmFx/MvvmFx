using System;

namespace InvoicesBusiness
{
    public class Invoice
    {
        private int _invoiceNumber = 100;
        private DateTime _invoiceDate = new DateTime(2000, 1, 1);

        //MvvmFx supports both generic delegate
        public event EventHandler<EventArgs> InvoiceNumberChanged;

        //and non-generic
        public event EventHandler InvoiceDateChanged;

        public int InvoiceNumber
        {
            get { return _invoiceNumber; }
            set
            {
                if (_invoiceNumber != value)
                {
                    _invoiceNumber = value;
                    OnInvoiceNumberChanged();
                }
            }
        }

        public DateTime InvoiceDate
        {
            get { return _invoiceDate; }
            set
            {
                if (_invoiceDate != value)
                {
                    _invoiceDate = value;
                    OnInvoiceDateChanged();
                }
            }
        }

        protected virtual void OnInvoiceNumberChanged()
        {
            //thread safe
            EventHandler<EventArgs> handler;
            lock (this)
            {
                handler = InvoiceNumberChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            /*var handler = InvoiceNumberChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }*/
        }

        protected virtual void OnInvoiceDateChanged()
        {
            //thread safe
            EventHandler handler;
            lock (this)
            {
                handler = InvoiceDateChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            /*var handler = InvoiceDateChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }*/
        }
    }
}
