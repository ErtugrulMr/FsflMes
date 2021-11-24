//using Business.Abstract;
//using Entities.Concrete;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Controllers
//{
//    [Route("api/management/[controller]")]
//    [ApiController]
//    public class SysAdminsController : ControllerBase
//    {
//        ISysAdminService _sysAdminService;

//        public SysAdminsController(ISysAdminService sysAdminService)
//        {
//            _sysAdminService = sysAdminService;
//        }

//        [HttpPost("add")]
//        public IActionResult Add(SysAdmin sysAdmin)
//        {
//            var result = _sysAdminService.Add(sysAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
        
//        [HttpPost("delete")]
//        public IActionResult Delete(SysAdmin sysAdmin)
//        {
//            var result = _sysAdminService.Delete(sysAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
        
//        [HttpPost("update")]
//        public IActionResult Update(SysAdmin sysAdmin)
//        {
//            var result = _sysAdminService.Update(sysAdmin);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
        
//        [HttpGet("getAll")]
//        public IActionResult GetAll()
//        {
//            var result = _sysAdminService.GetAll();
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
        
//        [HttpGet("getById")]
//        public IActionResult GetById(int id)
//        {
//            var result = _sysAdminService.GetById(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
//    }
//}
