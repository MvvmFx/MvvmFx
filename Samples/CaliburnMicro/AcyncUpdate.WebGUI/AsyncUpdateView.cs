using System;
using Gizmox.WebGUI.Forms;
using MvvmFx.CaliburnMicro;

namespace AcyncUpdate.UI
{
    public interface IAsyncUpdateView : IHaveDataContext, IHaveBusyIndicator
    {
    }

    public partial class AsyncUpdateView : Form, IAsyncUpdateView
    {
        private IAsyncUpdateViewModel _viewModel;

        public AsyncUpdateView()
        {
            InitializeComponent();
            new AppBootstrapper(this).Run();
            ActiveControl = customerName;
        }

        public BusyIndicator Indicator
        {
            get { return busyIndicator; }
        }

        private void Bind()
        {
            customerName.DataBindings.Add(new Binding("ReadOnly", DataContext, "IsCustomerNameReadOnly", true,
                DataSourceUpdateMode.OnPropertyChanged));
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as IAsyncUpdateViewModel;
                    Bind();
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion
    }
}