using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.Classroom
{
    public class CreateClassroomDto
    {
        [StringLength(50, ErrorMessage = "Tên lớp không được vượt quá 50 ký tự.")]
        public string Name { get; set; }
        public string ClassCode{get; set;}
        [Range(1, int.MaxValue, ErrorMessage = "Số sinh viên tối đa phải lớn hơn 0")]
        public int MaxStudent{get; set;}
    }
}
