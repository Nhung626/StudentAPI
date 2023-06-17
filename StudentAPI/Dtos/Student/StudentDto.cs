namespace StudentAPI.Dtos.Student
{
    public class StudentDto
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Mssv { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
