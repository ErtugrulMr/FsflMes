using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/management/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public IUserService _userService;

        public StudentsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("delete")]
        public IActionResult Delete(Student student)
        {
            var result = _userService.DeleteStudent(student);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAllStudents();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-by-id")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetStudentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("get-details")]
        public IActionResult GetDetails(int id)
        {
            var result = _userService.GetStudentDetails(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
