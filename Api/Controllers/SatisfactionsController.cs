using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisfactionsController : ControllerBase
    {
        ISatisfactionService _satisfactionService;

        public SatisfactionsController(ISatisfactionService satisfactionService)
        {
            _satisfactionService = satisfactionService;
        }

        [HttpPost("add")]
        public IActionResult Add(Satisfaction satisfaction)
        {
            var result = _satisfactionService.Add(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Satisfaction satisfaction)
        {
            var result = _satisfactionService.Delete(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Satisfaction satisfaction)
        {
            var result = _satisfactionService.Update(satisfaction);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _satisfactionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _satisfactionService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
