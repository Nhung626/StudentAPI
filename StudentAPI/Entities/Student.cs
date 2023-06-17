namespace StudentAPI.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Mssv { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
