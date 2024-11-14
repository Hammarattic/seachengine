using System;
using System.Collections.Generic;
using seachengine.customtypes;
using searchengine.customtypes;  // Ensure correct namespace

namespace SearchEngine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentcount=0;
            bool running = true;

            Console.WriteLine("Welcome to the search engine for tech");

            Console.Clear();

            var students = new List<Student>
            {
            new Student("Sebastian Tølbøl Nielsen", new DateTime(2003, 5, 10)),
            new Student("Andreas Lorenzen", new DateTime(2020, 3, 12)),
            new Student("Casper Clemmensen", new DateTime(2001, 7, 15)),
            new Student("Daniel Bjerre Jensen", new DateTime(2000, 11, 22)),
            new Student("Hjalte Moesgaard Leth", new DateTime(1999, 8, 30)),
            new Student("Johan Milter Jakobsen", new DateTime(2001, 9, 3)),
            new Student("Louis Thomas Dao Pedersen", new DateTime(2002, 6, 25)),
            new Student("Lukas Haugstad Frederiksen", new DateTime(2000, 4, 7)),
            new Student("Marcus Wahlstrøm", new DateTime(2001, 12, 13)),
            new Student("Marcus Slot Rohr", new DateTime(2000, 10, 18)),
            new Student("Mathias Altenburg", new DateTime(2002, 2, 20)),
            new Student("Patrick Gutierrez Fogelstrøm", new DateTime(2003, 1, 5)),
            new Student("Ramtin Akbari", new DateTime(2002, 12, 11)),
            new Student("Simon Heilbuth", new DateTime(2001, 7, 18)),
            new Student("Thobias Svarter Hammarkvist", new DateTime(2001, 5, 14)),
            new Student("Yosef Kasas", new DateTime(2000, 9, 27))
            };

            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "objprog",
                    Teacher = "niels",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "grundprog",
                    Teacher = "henrik",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "computertecnologi",
                    Teacher = "micael",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "server og sikkerhed",
                    Teacher = "micael",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "databaseprog",
                    Teacher = "micael",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "databasesever",
                    Teacher = "micael",
                    Students = students
                },
                new Subject
                {
                    SubjectName = "clientside",
                    Teacher = "micael",
                    Students = students
                },
            };

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Choose:");
                Console.WriteLine("1) Search on subject");
                Console.WriteLine("2) Search on teacher");
                Console.WriteLine("3) Search on student");
                Console.WriteLine("4) Exit");

                string choice = Console.ReadLine();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter subject name to search for:");
                        string subjectSearch = Console.ReadLine().ToLower();
                        SearchSubject(subjectSearch, subjects);
                        Console.ReadKey();  // Pause to view results
                        break;

                    case "2":
                        Console.WriteLine("Enter the teacher's name to search for:");
                        string teacherSearch = Console.ReadLine().ToLower();
                        SearchTeacher(teacherSearch, subjects);
                        Console.ReadKey();  // Pause to view results
                        break;

                    case "3":
                        Console.WriteLine("Enter the student's name to search for:");
                        string studentSearch = Console.ReadLine().ToLower();
                        SearchStudent(studentSearch, subjects);
                        Console.ReadKey();  // Pause to view results
                        break;

                    case "4":
                        running = false;
                        Console.WriteLine("Exiting the program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        Console.ReadKey();  // Pause to view invalid option message
                        break;
                }
            }
        }

        static void SearchSubject(string subjectSearch, List<Subject> subjects)
        {
            bool found = false;
            foreach (var subject in subjects)
            {
                if (subject.SubjectName.Contains(subjectSearch))
                {
                    Console.WriteLine($"Subject: {subject.SubjectName}, Teacher: {subject.Teacher}");
                    Console.WriteLine("Enrolled Students:");

                    foreach (var student in subject.Students)
                    {
                        // Check if student's age is under 20
                        if (student.Age < 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; // Set text color to red
                            Console.WriteLine($"- {student.Name} (Age: {student.Age})");
                            Console.ResetColor(); // Reset color after the student information
                        }
                        else
                        {
                            // Print other students normally
                            Console.WriteLine($"- {student.Name} (Age: {student.Age})");
                        }
                    }

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No subjects found matching your search.");
            }
        }


        static void SearchTeacher(string teacherSearch, List<Subject> subjects)
        {
            bool found = false;
            // Trim any leading or trailing whitespace from the search string
            teacherSearch = teacherSearch.Trim();

            foreach (var subject in subjects)
            {
                // Perform a case-insensitive search
                if (subject.Teacher.Contains(teacherSearch))
                {

                    Console.WriteLine($"Teacher: {subject.Teacher} teaches the subject: {subject.SubjectName}");
                    // Display the names of the enrolled students
                    Console.WriteLine($"Enrolled Students ({subject.Students.Count}): " + string.Join(", ", subject.Students.Select(s => s.Name)));
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No teachers found matching your search.");
            }
        }


        static void SearchStudent(string studentSearch, List<Subject> subjects)
{
    bool found = false;
    // Trim any leading or trailing whitespace from the search string
    studentSearch = studentSearch.Trim();

    foreach (var subject in subjects)
    {
        foreach (var student in subject.Students)
        {
            // Perform a case-insensitive search
            if (student.Name.Contains(studentSearch))
            {
                        if (student.Age < 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                Console.WriteLine($"Student: {student.Name} (Age: {student.Age}) is enrolled in subject: {subject.SubjectName} with Teacher: {subject.Teacher}");

                        Console.ResetColor();
                        found = true;
            }
        }
    }

    if (!found)
    {
        Console.WriteLine("No students found matching your search.");
    }
}
    }
}
