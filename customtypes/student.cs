namespace searchengine.customtypes
{
    public class Student
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        // Constructor to initialize name and birthdate
        public Student(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        // Calculate Age based on BirthDate
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                int age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--; // Adjust if birthday hasn't occurred yet this year
                return age;
            }
        }
    }
}
