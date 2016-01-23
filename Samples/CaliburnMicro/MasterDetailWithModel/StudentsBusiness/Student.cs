using System.ComponentModel;
using System.Linq;

namespace StudentsBusiness
{
    public class Student : INotifyPropertyChanged
    {
        #region Static stuff

        private static int _lastId = 1;

        private static StudentList Students;

        #endregion

        #region Business Properties

        public int StudentId { get; private set; }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged("FirstName");
                    NotifyPropertyChanged("FullName");
                    IsDirty = true;
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        private string _familyName;

        public string FamilyName
        {
            get { return _familyName; }
            set
            {
                if (_familyName != value)
                {
                    _familyName = value;
                    NotifyPropertyChanged("FamilyName");
                    NotifyPropertyChanged("FullName");
                    IsDirty = true;
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", _firstName, _familyName); }
        }

        private string _streetAddress;

        public string StreetAddress
        {
            get { return _streetAddress; }
            set
            {
                if (_streetAddress != value)
                {
                    _streetAddress = value;
                    NotifyPropertyChanged("StreetAddress");
                    IsDirty = true;
                }
            }
        }

        private string _townAddress;

        public string TownAddress
        {
            get { return _townAddress; }
            set
            {
                if (_townAddress != value)
                {
                    _townAddress = value;
                    NotifyPropertyChanged("TownAddress");
                    IsDirty = true;
                }
            }
        }

        private string _countryAddress;

        public string CountryAddress
        {
            get { return _countryAddress; }
            set
            {
                if (_countryAddress != value)
                {
                    _countryAddress = value;
                    NotifyPropertyChanged("CountryAddress");
                    IsDirty = true;
                }
            }
        }

        #endregion

        #region State Properties

        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            private set
            {
                if (_isDirty != value)
                {
                    _isDirty = value;
                    NotifyPropertyChanged("IsDirty");
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        public bool IsValid
        {
            get { return !string.IsNullOrWhiteSpace(_firstName) && !string.IsNullOrWhiteSpace(_familyName); }
        }

        public bool IsSavable
        {
            get { return IsDirty && IsValid && !IsDeleted; }
        }

        private bool _isDeleted;

        public bool IsDeleted
        {
            get { return _isDeleted; }
            private set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    NotifyPropertyChanged("IsDeleted");
                    NotifyPropertyChanged("IsSavable");
                }
            }
        }

        #endregion

        #region Constuctor

        private Student()
        {
            // use factory methods
            StudentId = _lastId++;
        }

        #endregion

        #region Factory methods

        public static Student AddNewStudent()
        {
            var student = new Student();
            student.IsDirty = true;
            Students.Add(student);
            StudentInfo.AddNewStudentInfo(student.StudentId, string.Empty);

            return student;
        }

        internal static Student NewStudent(string firstName, string familyName, string streetAddress, string townAddress, string countryAddress)
        {
            var student = new Student
            {
                _firstName = firstName,
                _familyName = familyName,
                _streetAddress = streetAddress,
                _townAddress = townAddress,
                _countryAddress = countryAddress
            };

            return student;
        }

        public static Student GetStudentById(int studentId)
        {
            return GetStudentList().FirstOrDefault(student => student.StudentId == studentId);
        }

        public static Student GetStudentByName(string firstName)
        {
            return GetStudentList().FirstOrDefault(student => student.FirstName == firstName);
        }

        internal static StudentList GetStudentList()
        {
            if (Students == null)
            {
                Students = new StudentList();
                Students.Load();
            }

            return Students;
        }

        #endregion

        #region Save & Delete methods

        public void Save()
        {
            IsDirty = false;
            StudentInfo.Update(StudentId, FullName);
        }

        public void Delete()
        {
            IsDeleted = true;
            Students.Remove(this);
            StudentInfo.Remove(StudentId);
        }

        #endregion

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