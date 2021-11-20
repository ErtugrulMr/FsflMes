using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/management/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("sysAdminLogin")]
        public ActionResult LoginSysAdmin(SysAdminDto sysAdminDto)
        {
            var sysAdminToLogin = _authService.LoginSysAdmin(sysAdminDto);
            if (!sysAdminToLogin.Success)
            {
                return BadRequest(sysAdminToLogin.Message);
            }

            var result = _authService.CreateAccessTokenForSysAdmin(sysAdminToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("sysAdminRegister")]
        public ActionResult RegisterSysAdmin(SysAdminDto sysAdminDto)
        {
            var isSysAdminExists = _authService.IsSysAdminExists(sysAdminDto.UserName);
            if (isSysAdminExists.Success)
            {
                return BadRequest(isSysAdminExists.Message);
            }

            var registerResult = _authService.RegisterSysAdmin(sysAdminDto);
            var result = _authService.CreateAccessTokenForSysAdmin(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
