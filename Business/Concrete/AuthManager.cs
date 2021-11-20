using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private ISysAdminService _sysAdminService;
        private ITokenHelper _tokenHelper;

        public AuthManager(ISysAdminService sysAdminService, ITokenHelper tokenHelper)
        {
            _sysAdminService = sysAdminService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<SysAdmin> RegisterSysAdmin(SysAdminDto sysAdminDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(sysAdminDto.Password, out passwordHash, out passwordSalt);
            var sysAdmin = new SysAdmin
            {
                UserName = sysAdminDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _sysAdminService.Add(sysAdmin);
            return new SuccessDataResult<SysAdmin>(sysAdmin, Messages.SysAdminCreatedSuccessfully);
        }

        public IDataResult<SysAdmin> LoginSysAdmin(SysAdminDto sysAdminDto)
        {
            var sysAdminToCheck = _sysAdminService.GetByUserName(sysAdminDto.UserName).Data;
            if (sysAdminToCheck == null)
            {
                return new ErrorDataResult<SysAdmin>(Messages.SysAdminNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(sysAdminDto.Password, sysAdminToCheck.PasswordHash, sysAdminToCheck.PasswordSalt))
            {
                return new ErrorDataResult<SysAdmin>(Messages.PasswordError);
            }

            return new SuccessDataResult<SysAdmin>(sysAdminToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<AccessToken> CreateAccessTokenForSysAdmin(SysAdmin sysAdmin)
        {
            var claims = _sysAdminService.GetClaims(sysAdmin);
            var accessToken = _tokenHelper.CreateToken(sysAdmin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        public IResult IsSysAdminExists(string userName)
        {
            var result = _sysAdminService.GetByUserName(userName).Data;
            if (result != null)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.SysAdminNotFound);
        }
    }
}
