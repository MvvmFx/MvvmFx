using System.ComponentModel;
using System.Threading;

// class by Marc Gravell - 2011 Jan 28
// http://stackoverflow.com/questions/4825225/inotifypropertychanged-and-threading/4825540#4825540

namespace StudentsBusiness
{
    public class ThreadedBindingList<T> : BindingList<T>
    {
        private readonly SynchronizationContext ctx;

        public ThreadedBindingList()
        {
            ctx = SynchronizationContext.Current;
        }

        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            var ctx = SynchronizationContext.Current;
            if (ctx == null)
            {
                BaseAddingNew(e);
            }
            else
            {
                ctx.Send(delegate { BaseAddingNew(e); }, null);
            }
        }

        private void BaseAddingNew(AddingNewEventArgs e)
        {
            base.OnAddingNew(e);
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (ctx == null)
            {
                BaseListChanged(e);
            }
            else
            {
                ctx.Send(delegate { BaseListChanged(e); }, null);
            }
        }

        private void BaseListChanged(ListChangedEventArgs e)
        {
            base.OnListChanged(e);
        }
    }
}