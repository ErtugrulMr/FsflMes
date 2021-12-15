using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/management/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login/sys-admin")]
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

        [HttpPost("register/sys-admin")]
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

        [HttpPost("login/sch-admin")]
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

        [HttpPost("register/sch-admin")]
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

        [HttpPost("login/student")]
        public ActionResult LoginStudent(StudentLoginDto studentLoginDto)
        {
            var studentToLogin = _authService.LoginStudent(studentLoginDto);
            if (!studentToLogin.Success)
            {
                return BadRequest(studentToLogin.Message);
            }

            var result = _authService.CreateAccessTokenForStudent(studentToLogin.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register/student")]
        public ActionResult RegisterStudent(StudentRegisterDto studentRegisterDto)
        {
            var isStudentExists = _authService.IsStudentExists(studentRegisterDto.FirstName + " " + studentRegisterDto.LastName);
            if (isStudentExists.Success)
            {
                return BadRequest(isStudentExists.Message);
            }

            var registerResult = _authService.RegisterStudent(studentRegisterDto);
            var result = _authService.CreateAccessTokenForStudent(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
