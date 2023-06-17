using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;
using StudentAPI.Dtos.Student;
// using StudentAPI.Filters;
// using StudentAPI.Services.Implements;
using StudentAPI.Services.Interfaces;

namespace StudentAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost("create")]
        public IActionResult Create(CreateStudentDto input)
        {
            _studentService.Create(input);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(UpdateStudentDto input)
        {
            _studentService.Update(input);
            return Ok();
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            return Ok(_studentService.GetAll());
        }

        [HttpGet("get-by-id/{id}")]
        public IActionResult GetById([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            return Ok(_studentService.GetById(id));
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([Range(1, int.MaxValue, ErrorMessage = "Id phải lớn hơn 0")] int id)
        {
            _studentService.Delete(id);
            return Ok();
        }
    }
}
