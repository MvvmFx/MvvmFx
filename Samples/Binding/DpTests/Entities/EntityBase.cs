using System.ComponentModel;

namespace DpTests.Entities
{
    public abstract class EntityBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            //thread safe
            PropertyChangedEventHandler handler;
            lock (this)
            {
                handler = PropertyChanged;
            }

            if (handler != null)
            {
                handler(this, e);
            }

            /*var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, e);
            }*/
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
