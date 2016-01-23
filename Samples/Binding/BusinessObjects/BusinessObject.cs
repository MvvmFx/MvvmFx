using System.ComponentModel;

namespace BusinessObjects
{
    //base class for all business objects
    public abstract class BusinessObject : INotifyPropertyChanged
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
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
