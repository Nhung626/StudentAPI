using StudentAPI.DbContexts;
using StudentAPI.Dtos.Student;
using StudentAPI.Entities;
using StudentAPI.Exceptions;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(CreateStudentDto input)
        {
            // thêm sinh viên vào list
            _context.Students.Add(new Student
            {
                Id = ++_context.StudentId,
                Name = input.Name,
                Mssv = input.Mssv,
                DateOfBirth = input.DateOfBirth
            });
        }

        public void Update(UpdateStudentDto input)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == input.Id);
            if (student == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input.Id}");
            }
            student.Name = input.Name;
            student.Mssv = input.Mssv;
            student.DateOfBirth = input.DateOfBirth;
        }

        public List<StudentDto> GetAll()
        {
            var results = new List<StudentDto>();
            foreach (var student in _context.Students)
            {
                results.Add(new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Mssv = student.Mssv,
                    DateOfBirth = student.DateOfBirth
                });
            }
            return results;
        }

        public StudentDto GetById(int input){
            var student = _context.Students.FirstOrDefault(s => s.Id == input);
            if(student == null){
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input}");
            }
            var result = new StudentDto{
               Id = student.Id,
                    Name = student.Name,
                    Mssv = student.Mssv,
                    DateOfBirth = student.DateOfBirth 
            };
            return result;
        }
        public void Delete(int input){
            var student = _context.Students.FirstOrDefault(s => s.Id == input);
            if(student == null){
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input}");
            }
            _context.Students.Remove(student);
        }
    }
}
