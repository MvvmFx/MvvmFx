using System;
using Kent.Boogaart.HelperTrinity.Extensions;

namespace MvvmFx.Windows.Specifications.Support.Entities.XxxChanged
{
    public class Address : IAddress
    {
        private string _line1;
        private string _line2;
        private string _line3;

        public event EventHandler<EventArgs> Line1Changed;

        public event EventHandler Line2Changed;

        public event EventHandler<EventArgs> Line3Changed;

        public string Line1
        {
            get { return _line1; }
            set
            {
                if (_line1 != value)
                {
                    _line1 = value;
                    Line1Changed.Raise(this, EventArgs.Empty);
                }
            }
        }

        public string Line2
        {
            get { return _line2; }
            set
            {
                if (_line2 != value)
                {
                    _line2 = value;
                    Line2Changed.Raise(this, EventArgs.Empty);
                }
            }
        }

        public string Line3
        {
            get { return _line3; }
            set
            {
                if (_line3 != value)
                {
                    _line3 = value;
                    Line3Changed.Raise(this, EventArgs.Empty);
                }
            }
        }
    }
}
