using StudentAPI.Dtos.Student;

namespace StudentAPI.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(CreateStudentDto input);
        List<StudentDto> GetAll();
        void Update(UpdateStudentDto input);
        StudentDto GetById(int input);
        void Delete(int input);
    }
}
