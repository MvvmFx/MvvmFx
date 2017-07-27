using System.ComponentModel;

namespace BoundControls.Business
{
    public class Leaf : INotifyPropertyChanged
    {
        #region Constructor

        public Leaf(int leafId, int? leafParentId, string leafName, string leafDescription, bool leafIsReadOnly)
        {
            LeafId = leafId;
            LeafParentId = leafParentId;
            LeafName = leafName;
            LeafDescription = leafDescription;
            LeafIsReadOnly = leafIsReadOnly;
        }

        #endregion

        #region private fields

        private int _leadId;
        private int? _leafParentId;
        private string _leafName;
        private string _leafDescription;
        private bool _leafIsReadOnly;

        #endregion

        #region Properties

        public int LeafId
        {
            get { return _leadId; }
            set
            {
                if (_leadId != value)
                {
                    _leadId = value;
                    OnPropertyChanged("LeafId");
                }
            }
        }

        public int? LeafParentId
        {
            get { return _leafParentId; }
            set
            {
                if (_leafParentId != value)
                {
                    _leafParentId = value;
                    OnPropertyChanged("LeafParentId");
                }
            }
        }

        public string LeafName
        {
            get { return _leafName; }
            set
            {
                if (_leafName != value)
                {
                    _leafName = value;
                    OnPropertyChanged("LeafName");
                }
            }
        }

        public string LeafDescription
        {
            get { return _leafDescription; }
            set
            {
                if (_leafDescription != value)
                {
                    _leafDescription = value;
                    OnPropertyChanged("LeafDescription");
                }
            }
        }

        public bool LeafIsReadOnly
        {
            get { return _leafIsReadOnly; }
            set
            {
                if (_leafIsReadOnly != value)
                {
                    _leafIsReadOnly = value;
                    OnPropertyChanged("LeafIsReadOnly");
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}