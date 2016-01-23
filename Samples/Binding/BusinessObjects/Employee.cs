namespace BusinessObjects
{
    public class Employee : BusinessObject
    {
        private static int _lastID;

        private int _employeeID = System.Threading.Interlocked.Increment(ref _lastID); 
        private string _employeeName;

        public int EmployeeID
        {
            get { return _employeeID; }
            set
            {
                if (_employeeID != value)
                {
                    _employeeID = value;
                    OnPropertyChanged("EmployeeID");
                }
            }
        }

        public string EmployeeName
        {
            get { return _employeeName; }
            set
            {
                if (_employeeName != value)
                {
                    if (value == "aaa")
                        _employeeName = "bbb";
                    else
                        _employeeName = value;
                    OnPropertyChanged("EmployeeName");
                }
            }
        }
    }
}
