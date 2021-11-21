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

        [HttpPost("schAdminLogin")]
        public ActionResult LoginSchAdmin(SchAdminLoginDto schAdminLoginDto)
        {
            var schAdminToLogin = _authService.LoginSchAdmin(schAdminLoginDto);
            if (!schAdminToLogin.Success)
            {
                return BadRequest(schAdminToLogin.Message);
            }

            var result = _authService.CreateAccessTokenForSchAdmin(schAdminToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("schAdminRegister")]
        public ActionResult RegisterSchAdmin(SchAdminRegisterDto schAdminRegisterDto)
        {
            var isSchAdminExists = _authService.IsSchAdminExists(schAdminRegisterDto.UserName);
            if (isSchAdminExists.Success)
            {
                return BadRequest(isSchAdminExists.Message);
            }

            var registerResult = _authService.RegisterSchAdmin(schAdminRegisterDto);
            var result = _authService.CreateAccessTokenForSchAdmin(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
