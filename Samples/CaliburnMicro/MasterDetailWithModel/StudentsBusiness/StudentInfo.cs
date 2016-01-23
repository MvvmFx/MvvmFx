using System.Linq;

namespace StudentsBusiness
{
    public class StudentInfo
    {
        #region Static stuff

        private static readonly StudentInfoList StudentInfos = new StudentInfoList();

        #endregion

        #region Properties

        public int StudentId { get; internal set; }

        public string FullName { get; internal set; }

        #endregion

        #region Constuctor

        internal StudentInfo()
        {
            // use factory methods
        }

        #endregion

        #region Factory methods

        internal static StudentInfo NewStudentInfo(int studentId, string fullName)
        {
            return new StudentInfo {StudentId = studentId, FullName = fullName};
        }

        internal static void AddNewStudentInfo(int studentId, string fullName)
        {
            StudentInfos.Add(NewStudentInfo(studentId, fullName));
        }

        internal static void Update(int studentId, string fullName)
        {
            StudentInfos.Update(studentId, fullName);
        }

        internal static void Remove(int studentId)
        {
            StudentInfos.Remove(studentId);
        }

        public static StudentInfoList GetStudentInfoList()
        {
            return StudentInfos;
        }

        public static StudentInfo GetStudentById(int studentId)
        {
            return StudentInfos.FirstOrDefault(studentInfo => studentInfo.StudentId == studentId);
        }

        #endregion
    }
}