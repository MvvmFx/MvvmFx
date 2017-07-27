using System.ComponentModel;

namespace BoundControls.Business
{
    public class StatusCollection : BindingList<Status>
    {
        #region Factory methods

        public static StatusCollection GetStatusCollection()
        {
            var collection = new StatusCollection();
            collection.Add(new Status("statusLabel1", "Running...", "Application status", true, true));
            return collection;
        }

        #endregion
    }
}