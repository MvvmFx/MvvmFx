using System;
using System.ComponentModel;

namespace StudentsBusiness
{
    public class StudentInfoList : BindingList<StudentInfo>
    {
        #region Constuctor

        internal StudentInfoList()
        {
            // use factory methods
            AllowNew = true;
            this.Load();
        }

        #endregion

        #region Update and Remove methods

        internal void Update(int studentId, string fullName)
        {
            int affectedIndex;
            StudentInfo studentInfo;
            FindByStudentId(studentId, out affectedIndex, out studentInfo);

            studentInfo.FullName = fullName;
            var listChangedEventArgs = new ListChangedEventArgs(ListChangedType.ItemChanged, affectedIndex);
            OnListChanged(listChangedEventArgs);
        }

        internal void Remove(int studentId)
        {
            int affectedIndex;
            StudentInfo studentInfo;
            FindByStudentId(studentId, out affectedIndex, out studentInfo);

            RemoveItem(affectedIndex);
        }

        private void FindByStudentId(int studentId, out int affectedIndex, out StudentInfo studentInfo)
        {
            affectedIndex = -1;
            studentInfo = new StudentInfo();
            for (var index = 0; index < this.Count; index++)
            {
                if (this[index].StudentId == studentId)
                {
                    studentInfo = this[index];
                    affectedIndex = index;
                    break;
                }
            }

            if (affectedIndex == -1)
                throw new ArgumentOutOfRangeException("studentId");
        }

        #endregion
    }
}