//using Business.Abstract;
//using Entities.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Controllers
//{
//    [Route("api/management/[controller]")]
//    [ApiController]
//    public class SchAdminsController : ControllerBase
//    {
//        ISchAdminService _schAdminService;

//        public SchAdminsController(ISchAdminService schAdminService)
//        {
//            _schAdminService = schAdminService;
//        }

//        [HttpPost("add")]
//        public IActionResult Add(SchAdmin schAdmin)
//        {
//            var result = _schAdminService.Add(schAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpPost("delete")]
//        public IActionResult Delete(SchAdmin schAdmin)
//        {
//            var result = _schAdminService.Delete(schAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpPost("update")]
//        public IActionResult Update(SchAdmin schAdmin)
//        {
//            var result = _schAdminService.Update(schAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("getAll")]
//        public IActionResult GetAll()
//        {
//            var result = _schAdminService.GetAll();
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("getById")]
//        public IActionResult GetById(int id)
//        {
//            var result = _schAdminService.GetById(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
//    }
//}
