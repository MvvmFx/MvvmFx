namespace StudentsBusiness
{
    internal static class StudentInfoListLoader
    {
        internal static StudentInfoList Load(this StudentInfoList studentInfoList)
        {
            foreach (var student in Student.GetStudentList())
            {
                studentInfoList.Add(StudentInfo.NewStudentInfo(student.StudentId, student.FullName));
            }

            return studentInfoList;
        }
    }
}