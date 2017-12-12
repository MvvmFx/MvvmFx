using System.Collections.Generic;
using MasterDetailWithModel.ViewModels;
using MvvmFx.CaliburnMicro;
#if WISEJ
using Wisej.Web;
#else
using System.Windows.Forms;
#endif
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace MasterDetailWithModel
{
    public interface IMainFormViewModel : IScreen, IHaveViewNamedElements
    {
    }

    public class MainFormViewModel : Conductor<Screen>, IMainFormViewModel
    {
        #region Fields and properties

        public List<Control> ViewNamedElements { get; set; }

        #endregion

        #region Initializers

        protected override void OnInitialize()
        {
            DisplayName = "Master/Detail w/Model";
            BindMenuItems();
        }

        private void BindMenuItems()
        {
            var mainForm = GetView() as MainForm;
            if (mainForm != null)
                mainForm.BindMenuItems(ViewNamedElements);
        }

        #endregion

        #region File menu guard visibility properties

        private bool _openStudentList1Visible = true;

        public bool OpenStudentList1Visible
        {
            get { return _openStudentList1Visible; }
            set
            {
                if (_openStudentList1Visible != value)
                {
                    _openStudentList1Visible = value;
                    NotifyOfPropertyChange("OpenStudentList1Visible");
                }
            }
        }

        private bool _openStudentList2Visible = true;

        public bool OpenStudentList2Visible
        {
            get { return _openStudentList2Visible; }
            set
            {
                if (_openStudentList2Visible != value)
                {
                    _openStudentList2Visible = value;
                    NotifyOfPropertyChange("OpenStudentList2Visible");
                }
            }
        }

        private bool _closeStudentListVisible;

        public bool CloseStudentListVisible
        {
            get { return _closeStudentListVisible; }
            set
            {
                if (_closeStudentListVisible != value)
                {
                    _closeStudentListVisible = value;
                    NotifyOfPropertyChange("CloseStudentListVisible");
                }
            }
        }

        #endregion

        #region File menu action methods

        public void OpenStudentList1()
        {
            OpenStudentList1Visible = false;
            OpenStudentList2Visible = true;
            CloseStudentListVisible = true;
            StudentMenuVisible = true;

            if (ActiveItem != null)
            {
                if (ActiveItem.GetType() != typeof(StudentListViewModel))
                    ActiveItem.TryClose();
            }
            ActivateItem(new StudentListViewModel());
        }

        public void OpenStudentList2()
        {
            OpenStudentList2Visible = false;
            OpenStudentList1Visible = true;
            CloseStudentListVisible = true;
            StudentMenuVisible = true;

            if (ActiveItem != null)
            {
                if (ActiveItem.GetType() != typeof(StudentMasterDetailViewModel))
                    ActiveItem.TryClose();
            }
            ActivateItem(new StudentMasterDetailViewModel());
        }

        public void CloseStudentList()
        {
            OpenStudentList1Visible = true;
            OpenStudentList2Visible = true;
            CloseStudentListVisible = false;
            StudentMenuVisible = false;

            ActiveItem.TryClose();
            ActivateItem(null);
        }

        public void Exit()
        {
            TryClose();
        }

        #endregion

        #region Student menu guard visibility properties

        private bool _studentMenuVisible;

        public bool StudentMenuVisible
        {
            get { return _studentMenuVisible; }
            set
            {
                if (_studentMenuVisible != value)
                {
                    _studentMenuVisible = value;
                    NotifyOfPropertyChange("StudentMenuVisible");
                }
            }
        }

        #endregion

        #region Student menu action methods and CAN guard properties

        public void CreateStudent()
        {
            if (_canCreateStudent)
                GetStudentEdit().Create();
        }

        private bool _canCreateStudent;

        public bool CanCreateStudent
        {
            get { return _canCreateStudent; }
            set
            {
                if (_canCreateStudent != value)
                {
                    _canCreateStudent = value;
                    NotifyOfPropertyChange("CanCreateStudent");
                }
            }
        }

        public void SaveStudent()
        {
            GetStudentEdit().Save();
        }

        private bool _canSaveStudent;

        public bool CanSaveStudent
        {
            get { return _canSaveStudent; }
            set
            {
                if (_canSaveStudent != value)
                {
                    _canSaveStudent = value;
                    NotifyOfPropertyChange("CanSaveStudent");
                }
            }
        }

        public void DeleteStudent()
        {
            GetStudentEdit().Delete();
        }

        private bool _canDeleteStudent;

        public bool CanDeleteStudent
        {
            get { return _canDeleteStudent; }
            set
            {
                if (_canDeleteStudent != value)
                {
                    _canDeleteStudent = value;
                    NotifyOfPropertyChange("CanDeleteStudent");
                }
            }
        }

        public void CloseStudent()
        {
            GetStudentEdit().Close();
        }

        private IStudentEdit GetStudentEdit()
        {
            foreach (var child in GetChildren())
            {
                if (child is IStudentEdit)
                {
                    return child as IStudentEdit;
                }

                if (child is IParent)
                {
                    var parent = child as IParent;
                    foreach (var grandChild in parent.GetChildren())
                    {
                        if (grandChild == null)
                            return new StudentEditViewModel();

                        if (grandChild is IStudentEdit)
                        {
                            return grandChild as IStudentEdit;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }
}