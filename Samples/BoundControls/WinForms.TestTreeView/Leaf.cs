using System.ComponentModel;

namespace WinForms.TestTreeView
{
    public class LeafList : BindingList<Leaf>
    {
        #region Factory methods

        public static LeafList GetLeafList()
        {
            var leafList = new LeafList();
            leafList.Add(new Leaf(10, 5, "Child 2.1.5 RO", "Description 10", true));
            leafList.Add(new Leaf(1, null, "A Root", "Description 1", false));
            leafList.Add(new Leaf(11, 4, "Child 1.2.1 RO", "Description 11", true));
            leafList.Add(new Leaf(2, null, "Z Another Root", "Description 2", false));
            leafList.Add(new Leaf(3, 1, "Child 1.1", "Description 3", false));
            leafList.Add(new Leaf(4, 1, "DRAG ME < < <", "Description 4", true));
            leafList.Add(new Leaf(15, 2, "Child 2.4 RO", "Description 15", true));
            leafList.Add(new Leaf(6, 5, "Child 2.1.1", "Description 6", false));
            leafList.Add(new Leaf(7, 5, "Child 2.1.2 RO", "Description 7", true));
            leafList.Add(new Leaf(8, 5, "Child 2.1.3", "Description 8", false));
            leafList.Add(new Leaf(9, 5, "Child 2.1.4 RO", "Description 9", true));
            leafList.Add(new Leaf(5, 2, "Child 2.1", "Description 5", false));
            leafList.Add(new Leaf(12, 4, "DROP HERE < < <", "Description 12", true));
            leafList.Add(new Leaf(13, 2, "Child 2.2 RO", "Description 13", true));
            leafList.Add(new Leaf(14, 2, "Child 2.3", "Description 14", false));

            return leafList;
        }

        public static LeafList GetLeafListWithErrors()
        {
            var leafList = new LeafList();
            leafList.Add(new Leaf(21, 21, "Selfie", "Description 21", true)); //Selfie
            leafList.Add(new Leaf(10, 5, "Child 2.1.5 RO", "Description 10", true));
            leafList.Add(new Leaf(1, null, "A Root", "Description 1", false));
            leafList.Add(new Leaf(11, 4, "Child 1.2.1 RO", "Description 11", true));
            leafList.Add(new Leaf(16, 17, "Inexistant parent", "Description 16", true)); //Inexistant parent
            leafList.Add(new Leaf(2, null, "Z Another Root", "Description 2", false));
            leafList.Add(new Leaf(2, null, "DUPLICATE", "Description 2", false)); //Duplicate
            leafList.Add(new Leaf(3, 1, "Child 1.1", "Description 3", false));
            leafList.Add(new Leaf(4, 1, "Child 1.2 RO", "Description 4", true));
            leafList.Add(new Leaf(15, 2, "Child 2.4 RO", "Description 15", true));
            leafList.Add(new Leaf(6, 5, "Child 2.1.1", "Description 6", false));
            leafList.Add(new Leaf(7, 5, "Child 2.1.2 RO", "Description 7", true));
            leafList.Add(new Leaf(8, 5, "Child 2.1.3", "Description 8", false));
            leafList.Add(new Leaf(9, 5, "Child 2.1.4 RO", "Description 9", true));
            leafList.Add(new Leaf(5, 2, "Child 2.1", "Description 5", false));
            leafList.Add(new Leaf(12, 4, "Child 1.2.2 RO", "Description 12", true));
            leafList.Add(new Leaf(13, 2, "Child 2.2 RO", "Description 13", true));
            leafList.Add(new Leaf(14, 2, "Child 2.3", "Description 14", false));

            return leafList;
        }

        #endregion
    }

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
        private string _leafDescription;
        private bool _leafIsReadOnly;
        private string _leafName;
        private int? _leafParentId;

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