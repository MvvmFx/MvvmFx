using System;

namespace EventRaising
{
    public class EntityXxxChanged
    {
        #region Backing fields

        private string _oneWayToTarget;
        private int _oneWayToSource;
        private string _twoWay;

        #endregion

        #region Properties

        public string OneWayToTarget
        {
            get
            {
                Console.WriteLine("XXX get {0}", "OneWayToTarget");
                return _oneWayToTarget;
            }
            set
            {
                if (_oneWayToTarget != value)
                {
                    _oneWayToTarget = value;
                    Console.WriteLine("XXX SET {0}", "OneWayToTarget");
                    OnOneWayToTargetChanged();
                }
            }
        }

        public int OneWayToSource
        {
            get
            {
                Console.WriteLine("XXX get {0}", "OneWayToSource");
                return _oneWayToSource;
            }
            set
            {
                if (_oneWayToSource != value)
                {
                    _oneWayToSource = value;
                    Console.WriteLine("XXX SET {0}", "OneWayToSource");
                    OnOneWayToSourceChanged();
                }
            }
        }

        public string TwoWay
        {
            get
            {
                Console.WriteLine("XXX get {0}", "TwoWay");
                return _twoWay;
            }
            set
            {
                if (_twoWay != value)
                {
                    _twoWay = value;
                    Console.WriteLine("XXX SET {0}", "TwoWay");
                    OnTwoWayChanged();
                }
            }
        }

        #endregion

        #region Event raising

        public event EventHandler<EventArgs> OneWayToTargetChanged;

        public event EventHandler OneWayToSourceChanged;

        public event EventHandler TwoWayChanged;

        private void OnOneWayToTargetChanged()
        {
            var handler = OneWayToTargetChanged;

            if (handler != null)
            {
                Console.WriteLine("Raised event OneWayToTargetChanged");
                handler(this, new EventArgs());
            }
        }

        private void OnOneWayToSourceChanged()
        {
            var handler = OneWayToSourceChanged;

            if (handler != null)
            {
                Console.WriteLine("Raised event OneWayToSourceChanged");
                handler(this, new EventArgs());
            }
        }

        private void OnTwoWayChanged()
        {
            var handler = TwoWayChanged;

            if (handler != null)
            {
                Console.WriteLine("Raised event TwoWayChanged");
                handler(this, new EventArgs());
            }
        }

        #endregion
    }
}