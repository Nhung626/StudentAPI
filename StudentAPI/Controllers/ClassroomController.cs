using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Dtos.Classroom;
using StudentAPI.Entities;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [Route("api/classroom")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpGet("get-all-student/{classroomId}")]
        public IActionResult GetAllStudent(int classroomId)
        {
            try
            {
                return Ok(_classroomService.GetAllStudent(classroomId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("create")]
        public IActionResult Create(CreateClassroomDto input)
        {
            _classroomService.CreateClassroom(input);
            return Ok();
        }
        [HttpPost("add-student-to-class")]
        public IActionResult AddStuToClass(List<int> students, int classroomId){
            _classroomService.AddStudentToClass(students, classroomId);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateClassroomDto input)
        {
            _classroomService.UpdateClassroom(input);
            return Ok();
        }
        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            return Ok(_classroomService.GetClassroom(id));
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_classroomService.GetAllClassroom());
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id){
            _classroomService.DeleteClass(id);
            return Ok();
        }
    }
}
