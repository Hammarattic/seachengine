namespace searchengine.customtypes
{
    public class Subject
    {
        public string SubjectName { get; set; }
        public string Teacher { get; set; }
        public List<Student> Students { get; set; }  // This is the list of students
    }
}
