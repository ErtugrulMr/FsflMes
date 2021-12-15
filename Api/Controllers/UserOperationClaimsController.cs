//using Business.Abstract;
//using Core.Entities.Concrete;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Controllers
//{
//    [Route("api/management/user-operation-claims")]
//    [ApiController]
//    public class UserOperationClaimsController : ControllerBase
//    {
//        public IUserOperationClaimService _userOperationClaimService;

//        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
//        {
//            _userOperationClaimService = userOperationClaimService;
//        }

//        [HttpPost("add")]
//        public IActionResult Add(UserOperationClaim userOperationClaim)
//        {
//            var result = _userOperationClaimService.Add(userOperationClaim);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpPost("delete")]
//        public IActionResult Delete(UserOperationClaim userOperationClaim)
//        {
//            var result = _userOperationClaimService.Delete(userOperationClaim);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpPost("update")]
//        public IActionResult Update(UserOperationClaim userOperationClaim)
//        {
//            var result = _userOperationClaimService.Update(userOperationClaim);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("get-all")]
//        public IActionResult GetAll()
//        {
//            var result = _userOperationClaimService.GetAll();
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("get-by-id")]
//        public IActionResult GetById(int id)
//        {
//            var result = _userOperationClaimService.GetById(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("get-by-user-id")]
//        public IActionResult GetByUserId(int id)
//        {
//            var result = _userOperationClaimService.GetByUserId(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }

//        [HttpGet("get-by-operation-claim-id")]
//        public IActionResult GetByOperationClaimId(int id)
//        {
//            var result = _userOperationClaimService.GetByOperationClaimId(id);
//            if (result.Success)
//            {
//                return Ok(result);
//            }
//            return BadRequest(result);
//        }
//    }
//}
