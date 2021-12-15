using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;

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
        IDataResult<Student> RegisterStudent(StudentRegisterDto studentDto);
        IDataResult<Student> LoginStudent(StudentLoginDto studentDto);
        IResult IsStudentExists(string userName);
        IDataResult<AccessToken> CreateAccessTokenForStudent(Student student);
    }
}
