using System.ComponentModel.DataAnnotations;

namespace StudentAPI.Dtos.Student
{
    public class CreateStudentDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên không được bỏ trống")]
        [StringLength(50, ErrorMessage = "Tên sinh viên không được vượt quá 50 ký tự.")]
        public string Name { get; set; }    
        public string Mssv { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
