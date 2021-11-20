using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriticismsController : ControllerBase
    {
        ICriticismService _criticismService;

        public CriticismsController(ICriticismService criticismService)
        {
            _criticismService = criticismService;
        }

        [HttpPost("add")]
        public IActionResult Add(Criticism criticism)
        {
            var result = _criticismService.Add(criticism);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Criticism criticism)
        {
            var result = _criticismService.Delete(criticism);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Criticism criticism)
        {
            var result = _criticismService.Update(criticism);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _criticismService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _criticismService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
