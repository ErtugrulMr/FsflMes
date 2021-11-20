using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        IComplaintService _complaintService;

        public ComplaintsController(IComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost("add")]
        public IActionResult Add(Complaint complaint)
        {
            var result = _complaintService.Add(complaint);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Complaint complaint)
        {
            var result = _complaintService.Delete(complaint);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Complaint complaint)
        {
            var result = _complaintService.Update(complaint);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _complaintService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _complaintService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
