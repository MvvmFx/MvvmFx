namespace StudentsBusiness
{
    /// <summary>
    /// Helper class to load the data into the <see cref="StudentList" />.
    /// </summary>
    internal static class StudentListLoader
    {
        internal static StudentList Load(this StudentList studentList)
        {
            studentList.Add(Student.NewStudent("Sherlock", "Holmes", "221B, Baker Street", "London", "United Kingdom"));
            studentList.Add(Student.NewStudent("John H.", "Watson", "221B, Baker Street", "London", "United Kingdom"));
            studentList.Add(Student.NewStudent("Sirius", "Black", "12, Grimmauld Place", "London", "United Kingdom"));
            studentList.Add(Student.NewStudent("Homer J.", "Simpson", "742, Evergreen Terrace", "Springfield", "USA"));
            studentList.Add(Student.NewStudent("Marjorie", "Simpson", "742, Evergreen Terrace", "Springfield", "USA"));
            studentList.Add(Student.NewStudent("Bartholomew JoJo", "Simpson", "742, Evergreen Terrace", "Springfield", "USA"));
            studentList.Add(Student.NewStudent("Margaret Evelyn", "Simpson", "742, Evergreen Terrace", "Springfield", "USA"));
            studentList.Add(Student.NewStudent("Lisa Marie", "Simpson", "742, Evergreen Terrace", "Springfield", "USA"));
            studentList.Add(Student.NewStudent("Peter", "Griffin", "31, Spooner Street", "Quahog", "USA"));
            studentList.Add(Student.NewStudent("Lois Patrice", "Griffin", "31, Spooner Street", "Quahog", "USA"));
            studentList.Add(Student.NewStudent("Megan", "Griffin", "31, Spooner Street", "Quahog", "USA"));
            studentList.Add(Student.NewStudent("Christopher Cross", "Griffin", "31, Spooner Street", "Quahog", "USA"));
            studentList.Add(Student.NewStudent("Stewart Gilligan", "Griffin", "31, Spooner Street", "Quahog", "USA"));
            studentList.Add(Student.NewStudent("Hercule", "Poirot", "Apt 56B, Whitehaven Mansions, Sandhurst Sq.", "London", "United Kingdom"));
            studentList.Add(Student.NewStudent("Arthur", "Hastings", "Apt 56B, Whitehaven Mansions, Sandhurst Sq.", "London", "United Kingdom"));
            studentList.Add(Student.NewStudent("Jane", "Marple", "Danemead, High Street", "St. Mary Mead", "United Kingdom"));
            studentList.Add(Student.NewStudent("Arsène", "Lupin", "8, Rue Crevaux", "Paris", "France"));
            studentList.Add(Student.NewStudent("Archibald", "Haddock", "Château de Moulinsart", "Moulinsart", "Belgique"));
            studentList.Add(Student.NewStudent("Tintin", "Le Reporter", "Château de Moulinsart", "Moulinsart", "Belgique"));
            studentList.Add(Student.NewStudent("Milou", "Le Chien-chien", "Château de Moulinsart", "Moulinsart", "Belgique"));
            studentList.Add(Student.NewStudent("Clark", "Kent", "1938, Sulivan Lane", "Metropolis", "USA"));
            studentList.Add(Student.NewStudent("Lois", "Lane", "1938, Sulivan Lane", "Metropolis", "USA"));
            studentList.Add(Student.NewStudent("Donald", "Duck", "1313, Webfoot Walk", "Duckburg", "Calisota"));
            studentList.Add(Student.NewStudent("Huey", "Duck", "1313, Webfoot Walk", "Duckburg", "Calisota"));
            studentList.Add(Student.NewStudent("Dewey", "Duck", "1313, Webfoot Walk", "Duckburg", "Calisota"));
            studentList.Add(Student.NewStudent("Louie", "Duck", "1313, Webfoot Walk", "Duckburg", "Calisota"));
            studentList.Add(Student.NewStudent("Anthony John", "Soprano", "633, Stag Trail Road", "N. Caldwell", "USA"));
            studentList.Add(Student.NewStudent("Carmela", "Soprano", "633, Stag Trail Road", "N. Caldwell", "USA"));
            studentList.Add(Student.NewStudent("Meadow", "Soprano", "633, Stag Trail Road", "N. Caldwell", "USA"));
            studentList.Add(Student.NewStudent("Anthony Jr.", "Soprano", "633, Stag Trail Road", "N. Caldwell", "USA"));
            studentList.Add(Student.NewStudent("Harry", "Potter", "4, Privet Drive", "Little Whinging", "United Kingdom"));
            studentList.Add(Student.NewStudent("Petunia", "Dursley", "4, Privet Drive", "Little Whinging", "United Kingdom"));
            studentList.Add(Student.NewStudent("Vernon", "Dursley", "4, Privet Drive", "Little Whinging", "United Kingdom"));
            studentList.Add(Student.NewStudent("Dudley", "Dursley", "4, Privet Drive", "Little Whinging", "United Kingdom"));

            return studentList;
        }
    }
}