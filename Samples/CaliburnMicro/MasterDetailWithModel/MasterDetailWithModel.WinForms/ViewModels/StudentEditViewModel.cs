using System.ComponentModel;
using MasterDetailWithModel.Framework;
using MvvmFx.Bindings.Data;
using StudentsBusiness;
using Binding = MvvmFx.Bindings.Data.Binding;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace MasterDetailWithModel.ViewModels
{
    public class StudentEditViewModel : Screen, IStudentEdit
    {
        #region Fields and properties

        private static readonly BindingManager BindingManager = new BindingManager();

        private MainFormViewModel _menuObject;

        private Student _model;

        public object Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = (Student) value;
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        #endregion

        #region Initializers

        internal StudentEditViewModel()
        {
            // force to use parametrized constructor
            DisplayName = "Edit Student #";
        }

        public StudentEditViewModel(int studentId) : this()
        {
            DisplayName += studentId;
            PropertyChanged += OnStudentEditViewModelPropertyChanged;
            Model = Student.GetStudentById(studentId);
        }

        private void OnStudentEditViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                PropertyChanged -= OnStudentEditViewModelPropertyChanged;
                if (Parent != null)
                {
                    var parent = Parent as StudentListViewModel;
                    if (parent != null)
                        _menuObject = parent.Parent as MainFormViewModel;
                }
                Bind();
            }
        }

        #endregion

        #region Binders

        private void Bind()
        {
            // clear old bindings
            BindingManager.Bindings.Clear();

            // bind to main form properties
            BindMenuItem("CanSaveStudent", "CanSave");
            BindMenuItem("CanCreateStudent", "CanCreate");
            BindMenuItem("CanDeleteStudent", "CanDelete");

            CanCreate = true;
            CanSave = false;
            CanDelete = false;

            if (_model != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreate", _model, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
                    Mode = BindingMode.OneWayToTarget
                });

                BindingManager.Bindings.Add(new Binding(this, "CanSave", _model, "IsSavable")
                {
                    Mode = BindingMode.OneWayToTarget
                });

                CanDelete = true;
            }
        }

        private void BindMenuItem(string target, string source)
        {
            BindingManager.Bindings.Add(new Binding(_menuObject, target, this, source)
            {
                Mode = BindingMode.OneWayToTarget
            });
        }

        #endregion

        #region Actions methods and guard properties

        public void Create()
        {
            var student = Student.AddNewStudent();
            if (Parent != null)
            {
                var parent = Parent as StudentListViewModel;
                if (parent != null)
                    parent.ListItemId = student.StudentId;
            }

            TryClose();
        }

        private bool _canCreate;

        public bool CanCreate
        {
            get { return _canCreate; }
            set
            {
                if (_canCreate != value)
                {
                    _canCreate = value;
                    NotifyOfPropertyChange("CanCreate");
                }
            }
        }

        public void Save()
        {
            _model.Save();
        }

        private bool _canSave;

        public bool CanSave
        {
            get { return _canSave; }
            set
            {
                if (_canSave != value)
                {
                    _canSave = value;
                    NotifyOfPropertyChange("CanSave");
                }
            }
        }

        public void Delete()
        {
            StudentListViewModel parent = null;
            var newItem = -1;

            if (Parent != null)
            {
                parent = Parent as StudentListViewModel;
                newItem = ItemToShowAfterDelete(parent);
            }

            _model.Delete();

            CanCreate = true;
            CanSave = false;
            CanDelete = false;

            TryClose();

            if (parent != null)
                parent.ListItemId = newItem;
        }

        private int ItemToShowAfterDelete(StudentListViewModel parent)
        {
            var result = -1;

            if (parent != null)
            {
                StudentInfoList parentModel = (StudentInfoList) parent.Model;
                for (var index = 0; index < parentModel.Count; index++)
                {
                    var info = parentModel[index];
                    if (info.StudentId == _model.StudentId)
                    {
                        if (parentModel.Count > index + 1)
                            result = parentModel[index + 1].StudentId;
                        else if (parentModel.Count > 1)
                            result = parentModel[index - 1].StudentId;

                        break;
                    }
                }
            }

            return result;
        }

        private bool _canDelete = true;

        public bool CanDelete
        {
            get { return _canDelete; }
            set
            {
                if (_canDelete != value)
                {
                    _canDelete = value;
                    NotifyOfPropertyChange("CanDelete");
                }
            }
        }

        public void Close()
        {
            TryClose();
            ((StudentListViewModel) Parent).ListItemId = -1;
            BindingManager.Bindings.Clear();
        }

        #endregion
    }
}