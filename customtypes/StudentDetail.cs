using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seachengine.customtypes
{

    // A separate class to hold the name and birthdate of each student
    public class StudentDetail
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public StudentDetail(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age)) age--; // Adjust if birthday hasn't occurred yet this year
                return age;
            }

        }
    }
}

