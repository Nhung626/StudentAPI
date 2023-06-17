using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.Classroom
{
    public class ClassroomDto
    {
        public int Id { get; set; }
        public string Name;
        public string ClassCode { get; set; }
        public int MaxStudent { get; set; }
    }
}
