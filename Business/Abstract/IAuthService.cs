using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<SysAdmin> RegisterSysAdmin(SysAdminDto sysAdminDto);
        IDataResult<SysAdmin> LoginSysAdmin(SysAdminDto sysAdminDto);
        IResult IsSysAdminExists(string userName);
        IDataResult<AccessToken> CreateAccessTokenForSysAdmin(SysAdmin sysAdmin);
        IDataResult<SchAdmin> RegisterSchAdmin(SchAdminRegisterDto schAdminDto);
        IDataResult<SchAdmin> LoginSchAdmin(SchAdminLoginDto schAdminDto);
        IResult IsSchAdminExists(string userName);
        IDataResult<AccessToken> CreateAccessTokenForSchAdmin(SchAdmin schAdmin);
    }
}
