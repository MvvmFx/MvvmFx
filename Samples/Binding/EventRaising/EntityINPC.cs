using System;
using System.ComponentModel;

namespace EventRaising
{
    public class EntityINPC : INotifyPropertyChanged
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
                Console.WriteLine("INPC get {0}", "OneWayToTarget");
                return _oneWayToTarget;
            }
            set
            {
                if (_oneWayToTarget != value)
                {
                    _oneWayToTarget = value;
                    Console.WriteLine("INPC SET {0}", "OneWayToTarget");
                    OnPropertyChanged("OneWayToTarget");
                }
            }
        }

        public int OneWayToSource
        {
            get
            {
                Console.WriteLine("INPC get {0}", "OneWayToSource");
                return _oneWayToSource;
            }
            set
            {
                if (_oneWayToSource != value)
                {
                    _oneWayToSource = value;
                    Console.WriteLine("INPC SET {0}", "OneWayToSource");
                    OnPropertyChanged("OneWayToSource");
                }
            }
        }

        public string TwoWay
        {
            get
            {
                Console.WriteLine("INPC get {0}", "TwoWay");
                return _twoWay;
            }
            set
            {
                if (_twoWay != value)
                {
                    _twoWay = value;
                    Console.WriteLine("INPC SET {0}", "TwoWay");
                    OnPropertyChanged("TwoWay");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                Console.WriteLine("Raised event PropertyChanged {0}", propertyName);
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}