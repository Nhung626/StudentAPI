using StudentAPI.DbContexts;
using StudentAPI.Dtos.Classroom;
using StudentAPI.Dtos.StudentClassroom;
using StudentAPI.Dtos.Student;
using StudentAPI.Entities;
using StudentAPI.Exceptions;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Services.Implements
{
    public class ClassroomStudentService : IClassroomService
    {
        private readonly ApplicationDbContext _context;
        public ClassroomStudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateClassroom(CreateClassroomDto input)
        {
            _context.Classrooms.Add(new Classroom
            {
                Id = ++_context.ClassroomId,
                Name = input.Name,
                ClassCode = input.ClassCode,
                MaxStudent = input.MaxStudent
            });
        }
        public void CreateStudentClassroom(CreateStuClassDto input)
        {
            _context.StudentClassroom.Add(new StudentClassroom
            {
                Id = ++_context.StuClassId,
                StudentId = input.StudentId,
                ClassroomId = input.ClassroomId
            });
        }
        public void AddStudentToClass(List<int> studentIds, int classroomId)
        {
            var classroom = _context.Classrooms.FirstOrDefault(s => s.Id == classroomId);

            if (classroom != null)
            {
                foreach (var studentId in studentIds)
                {
                    var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
                    if (student != null)
                    {

                        var stuClass = new CreateStuClassDto
                        {
                            StudentId = studentId,
                            ClassroomId = classroomId
                        };
                        CreateStudentClassroom(stuClass);
                    }
                    else
                    {
                        throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {studentId}");
                    }
                }
            }
            else
            {
                throw new UserFriendlyException($"Không tìm thấy lớp môn học có id = {classroomId}");
            }
        }
        public List<ClassroomDto> GetAllClassroom()
        {
            var results = new List<ClassroomDto>();
            foreach (var classroom in _context.Classrooms)
            {
                results.Add(new ClassroomDto
                {
                    Id = classroom.Id,
                    Name = classroom.Name,
                    ClassCode = classroom.ClassCode,
                    MaxStudent = classroom.MaxStudent
                });
            }
            return results;
        }

        public List<StudentDto> GetAllStudent(int classroomId)
        {
            var query = from studentClassroom in _context.StudentClassroom
                        join student in _context.Students on studentClassroom.StudentId equals student.Id
                        where studentClassroom.ClassroomId == classroomId
                        orderby student.Name descending, student.Id descending
                        select new StudentDto
                        {
                            Id = student.Id,
                            Name = student.Name,
                            Mssv = student.Mssv,
                            DateOfBirth = student.DateOfBirth
                        };
            return query.ToList();

        }

        public ClassroomDto GetClassroom(int input)
        {
            var classroom = _context.Classrooms.FirstOrDefault(s => s.Id == input);
            if (classroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input}");
            }
            var result = new ClassroomDto
            {
                Id = classroom.Id,
                Name = classroom.Name,
                ClassCode = classroom.ClassCode,
                MaxStudent = classroom.MaxStudent
            };
            return result;
        }

        public void UpdateClassroom(UpdateClassroomDto input)
        {
            var classroom = _context.Classrooms.FirstOrDefault(s => s.Id == input.Id);
            if (classroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp môn học có id = {input}");
            }

            classroom.Id = input.Id;
            classroom.Name = input.Name;
            classroom.ClassCode = input.ClassCode;
            classroom.MaxStudent = input.MaxStudent;
        }
        public void DeleteClass(int input)
        {
            var classroom = _context.Classrooms.FirstOrDefault(s => s.Id == input);
            if (classroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có id = {input}");
            }
            var studentClassrooms = _context.StudentClassroom.FindAll(s => s.Id == input);
            foreach (var studentClassroom in studentClassrooms)
            {
                _context.StudentClassroom.Remove(studentClassroom);
            }

            _context.Classrooms.Remove(classroom);
        }
    }
}
