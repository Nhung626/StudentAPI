using StudentAPI.Dtos.Classroom;
using StudentAPI.Dtos.Student;
using StudentAPI.Dtos.StudentClassroom;
using StudentAPI.Entities;

namespace StudentAPI.Services.Interfaces
{
    public interface IClassroomService
    {
        void CreateClassroom(CreateClassroomDto createClassroomDto);
        void CreateStudentClassroom(CreateStuClassDto input);
        void UpdateClassroom(UpdateClassroomDto updateClassroomDto);
        ClassroomDto GetClassroom(int Id);
        List<ClassroomDto> GetAllClassroom();
        List<StudentDto> GetAllStudent(int classroomId);
        void AddStudentToClass(List<int> studentIds, int ClassroomId);
        void DeleteClass(int input);
    }
}
