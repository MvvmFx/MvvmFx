using System.Collections.Generic;
using System.ComponentModel;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using MasterDetailWithModel.Framework;
using MvvmFx.CaliburnMicro;
using MvvmFx.Windows.Data;
using StudentsBusiness;
using Binding = MvvmFx.Windows.Data.Binding;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace MasterDetailWithModel.ViewModels
{
    public class StudentMasterDetailViewModel : Screen, IStudentEdit, IHaveViewNamedElements
    {
        #region Fields and properties

        private static readonly BindingManager BindingManager = new BindingManager();

        private MainFormViewModel _menuObject;

        private StudentEditMasterDetail _model;

        public List<Control> ViewNamedElements { get; set; }

        public object Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = (StudentEditMasterDetail) value;
                    NotifyOfPropertyChange("Model");
                }
            }
        }

        private bool _studentOpen;

        public bool StudentOpen
        {
            get { return _studentOpen; }
            set
            {
                if (_studentOpen != value)
                {
                    _studentOpen = value;
                    NotifyOfPropertyChange("StudentOpen");
                }
            }
        }

        private int _listItemId;

        public int ListItemId
        {
            get { return _listItemId; }
            set
            {
                if (_listItemId != value)
                {
                    _listItemId = value;
                    UpdateItem();
                    NotifyOfPropertyChange("ListItemId");
                }
            }
        }

        #endregion

        #region Initializers

        public StudentMasterDetailViewModel()
        {
            DisplayName = "Student List (method 2) - It runs nicely under Windows.Forms and WebGUI.";
            Model = StudentEditMasterDetail.NewStudentMasterDetail();
            if (_model.Students.Count == 0)
                ListItemId = -1;
            else
                ListItemId = _model.StudentEdit.StudentId;
            PropertyChanged += OnStudentEditViewModelPropertyChanged;
        }

        private void OnStudentEditViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Parent")
            {
                PropertyChanged -= OnStudentEditViewModelPropertyChanged;
                _menuObject = Parent as MainFormViewModel;
                BindStudentEdit();
            }
        }

        #endregion

        #region Manage embedded sub-viewmodel

        private void UpdateItem()
        {
            ((StudentEditMasterDetail) _model).StudentEdit = Student.GetStudentById(_listItemId);
            if (_model.StudentEdit == null)
                _listItemId = -1;
            else
                _listItemId = _model.StudentEdit.StudentId;
            StudentOpen = _listItemId > -1;
            if (_menuObject != null)
                BindStudentEdit();
        }

        #endregion

        #region Binders

        private void BindStudentEdit()
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

            if (_model != null && _model.StudentEdit != null)
            {
                // set new bindings for this object
                BindingManager.Bindings.Add(new Binding(this, "CanCreateNew", _model.StudentEdit, "IsDirty")
                {
                    Converter = new InverseBooleanConverter(),
                    Mode = BindingMode.OneWayToTarget
                });

                BindingManager.Bindings.Add(new Binding(this, "CanSave", _model.StudentEdit, "IsSavable")
                {
                    Mode = BindingMode.OneWayToTarget
                });

                CanDelete = true;
                CanClose = true;

                // we need to rebind just because of FullName
                if (ViewNamedElements != null)
                    ViewModelBinder.RebindProperties(this);
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
            ListItemId = student.StudentId;
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
            var currentStudent = _model.StudentEdit;
            if (currentStudent != null)
                _model.StudentEdit.Save();
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
            var currentStudent = _model.StudentEdit;
            if (currentStudent != null)
            {
                ListItemId = GetNewCurrentStudent(currentStudent);
                currentStudent.Delete();
            }
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
            ListItemId = -1;
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

        private int GetNewCurrentStudent(Student student)
        {
            var nextId = -1;
            if (_model.Students.Count > 1)
            {
                var studentInfo = StudentInfo.GetStudentById(student.StudentId);
                var currentIndex = _model.Students.IndexOf(studentInfo);

                if (currentIndex < _model.Students.Count - 1)
                    nextId = _model.Students[currentIndex + 1].StudentId;
                else
                    nextId = _model.Students[currentIndex - 1].StudentId;
            }

            return nextId;
        }

        #endregion
    }
}