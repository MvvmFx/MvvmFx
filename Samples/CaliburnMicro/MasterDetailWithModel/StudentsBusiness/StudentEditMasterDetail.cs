using System.ComponentModel;

namespace StudentsBusiness
{
    public class StudentEditMasterDetail : INotifyPropertyChanged
    {
        public StudentInfoList Students { get; private set; }

        private Student _stundentEdit;

        public Student StudentEdit
        {
            get { return _stundentEdit; }
            set
            {
                if (_stundentEdit != value)
                {
                    _stundentEdit = value;
                    NotifyPropertyChanged("StudentEdit");
                }
            }
        }

        public static StudentEditMasterDetail NewStudentMasterDetail()
        {
            var studentMasterDetail = new StudentEditMasterDetail();
            studentMasterDetail.Students = StudentInfo.GetStudentInfoList();

            if (studentMasterDetail.Students.Count > 0)
                studentMasterDetail.StudentEdit = Student.GetStudentById(studentMasterDetail.Students[0].StudentId);

            return studentMasterDetail;
        }

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}