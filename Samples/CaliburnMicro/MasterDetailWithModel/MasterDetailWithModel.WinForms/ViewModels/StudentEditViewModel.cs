using System.ComponentModel;
using MasterDetailWithModel.Framework;
using MvvmFx.Windows.Data;
using StudentsBusiness;
using Binding = MvvmFx.Windows.Data.Binding;
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
                var parent = Parent as StudentListViewModel;
                _menuObject = parent.Parent as MainFormViewModel;
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
            BindMenuItem("CanCreateNewStudent", "CanCreateNew");
            BindMenuItem("CanDeleteStudent", "CanDelete");
            BindMenuItem("CanCloseStudent", "CanClose");

            CanCreateNew = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

            if (_model != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreateNew", _model as Student, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
                    Mode = BindingMode.OneWayToTarget
                });

                BindingManager.Bindings.Add(new Binding(this, "CanSave", _model as Student, "IsSavable")
                {
                    Mode = BindingMode.OneWayToTarget
                });

                CanDelete = true;
                CanClose = true;
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

        public void CreateNew()
        {
            var student = Student.AddNewStudent();
            (Parent as StudentListViewModel).ListItemId = student.StudentId;

            TryClose();
        }

        private bool _canCreateNew;

        public bool CanCreateNew
        {
            get { return _canCreateNew; }
            set
            {
                if (_canCreateNew != value)
                {
                    _canCreateNew = value;
                    NotifyOfPropertyChange("CanCreateNew");
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
            _model.Delete();

            CanCreateNew = true;
            CanSave = false;
            CanDelete = false;
            CanClose = false;

            TryClose();
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

        private bool _canClose = true;

        public new bool CanClose
        {
            get { return _canClose; }
            set
            {
                if (_canClose != value)
                {
                    _canClose = value;
                    NotifyOfPropertyChange("CanClose");
                }
            }
        }

        #endregion
    }
}