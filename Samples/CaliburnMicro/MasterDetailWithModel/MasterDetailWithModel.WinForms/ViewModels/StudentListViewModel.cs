using MvvmFx.CaliburnMicro;
using StudentsBusiness;
using Screen = MvvmFx.CaliburnMicro.Screen;

namespace MasterDetailWithModel.ViewModels
{
    public class StudentListViewModel : Conductor<Screen>, IHaveModel
    {
        #region Fields and properties

        private StudentInfoList _model;

        public object Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = (StudentInfoList) value;
                    NotifyOfPropertyChange("Model");
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
                    ActivateItem(new StudentEditViewModel(_listItemId));
                    NotifyOfPropertyChange("ListItemId");
                }
            }
        }

        #endregion

        #region Initializers

        public StudentListViewModel()
        {
            DisplayName = "Student List (method 1) - There are issues when running under Windows.Forms and Wisej but runs nicely under WebGUI.";
            Model = StudentInfo.GetStudentInfoList();
        }

        #endregion
    }
}