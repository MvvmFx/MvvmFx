using System;

namespace PerformanceTests.Business
{
    internal class XxxChanged : INumberName
    {
        private int _number;
        private string _fullName;

        public int Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnNumberChanged();
                }
            }
        }

        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnNameChanged();
                }
            }
        }

        #region binding stuff

        public event EventHandler NumberChanged;

        public event EventHandler FullNameChanged;

        protected virtual void OnNumberChanged()
        {
            //thread safe
            EventHandler handler;
            lock (this)
            {
                handler = NumberChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            /*var handler = NumberChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }*/
        }

        protected virtual void OnNameChanged()
        {
            //thread safe
            EventHandler handler;
            lock (this)
            {
                handler = FullNameChanged;
            }

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            /*var handler = FullNameChanged;

            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }*/
        }

        #endregion
    }
}
