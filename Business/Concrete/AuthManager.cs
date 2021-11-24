using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {

        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }

        [SecuredOperation("sysAdmin")]
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

            _userService.AddSysAdmin(sysAdmin);
            var userOperationClaim = new UserOperationClaim
            {
                OperationClaimId = OperationClaimIds.sysAdminId,
                UserId = sysAdmin.Id
            };
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (!result.Success)
            {
                return new ErrorDataResult<SysAdmin>(result.Message);
            }

            return new SuccessDataResult<SysAdmin>(sysAdmin, Messages.SysAdminCreatedSuccessfully);
        }

        public IDataResult<SysAdmin> LoginSysAdmin(SysAdminDto sysAdminDto)
        {
            var sysAdminToCheck = _userService.GetSysAdminByUserName(sysAdminDto.UserName).Data;
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
            var claims = _userService.GetClaimsOfSysAdmin(sysAdmin);
            var accessToken = _tokenHelper.CreateToken(sysAdmin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        [SecuredOperation("sysAdmin")]
        public IResult IsSysAdminExists(string userName)
        {
            var result = _userService.GetSysAdminByUserName(userName).Data;
            if (result != null)
            {
                return new SuccessResult(Messages.SysAdminAlreadyExists);
            }

            return new ErrorResult(Messages.SysAdminNotFound);
        }

        [SecuredOperation("sysAdmin,schAdmin")]
        public IDataResult<SchAdmin> RegisterSchAdmin(SchAdminRegisterDto schAdminRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(schAdminRegisterDto.Password, out passwordHash, out passwordSalt);
            var schAdmin = new SchAdmin
            {
                UserName = schAdminRegisterDto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                FirstName = schAdminRegisterDto.FirstName,
                LastName = schAdminRegisterDto.LastName
            };

            _userService.AddSchAdmin(schAdmin);
            var schAdminId = _userService.GetSchAdminByUserName(schAdmin.UserName).Data.Id;
            var userOperationClaim = new UserOperationClaim
            {
                OperationClaimId = OperationClaimIds.schAdminId,
                UserId = schAdminId
            };
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (!result.Success)
            {
                return new ErrorDataResult<SchAdmin>(result.Message);
            }

            return new SuccessDataResult<SchAdmin>(schAdmin, Messages.SchAdminCreatedSuccessfully);
        }

        public IDataResult<SchAdmin> LoginSchAdmin(SchAdminLoginDto schAdminLoginDto)
        {
            var schAdminToCheck = _userService.GetSchAdminByUserName(schAdminLoginDto.UserName).Data;
            if (schAdminToCheck == null)
            {
                return new ErrorDataResult<SchAdmin>(Messages.SchAdminNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(schAdminLoginDto.Password, schAdminToCheck.PasswordHash, schAdminToCheck.PasswordSalt))
            {
                return new ErrorDataResult<SchAdmin>(Messages.PasswordError);
            }

            return new SuccessDataResult<SchAdmin>(schAdminToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<AccessToken> CreateAccessTokenForSchAdmin(SchAdmin schAdmin)
        {
            var claims = _userService.GetClaimsOfSchAdmin(schAdmin);
            var accessToken = _tokenHelper.CreateToken(schAdmin, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        [SecuredOperation("sysAdmin,schAdmin")]
        public IResult IsSchAdminExists(string userName)
        {
            var result = _userService.GetSchAdminByUserName(userName).Data;
            if (result != null)
            {
                return new SuccessResult(Messages.SchAdminAlreadyExists);
            }

            return new ErrorResult(Messages.SchAdminNotFound);
        }

        [SecuredOperation("sysAdmin,schAdmin")]
        public IDataResult<Student> RegisterStudent(StudentRegisterDto studentRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            string password = studentRegisterDto.NationalIdentityNumber.ToString().Substring(0,5); // Password will be first 6 characters of NationalIdentityNumber.
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var student = new Student
            {
                ClassId = studentRegisterDto.ClassId,
                SchoolNumber = studentRegisterDto.SchoolNumber,
                Name = studentRegisterDto.Name,
                NationalIdentityNumber = studentRegisterDto.NationalIdentityNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.AddStudent(student);
            var userOperationClaim = new UserOperationClaim
            {
                OperationClaimId = OperationClaimIds.studentId,
                UserId = student.Id
            };
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (!result.Success)
            {
                return new ErrorDataResult<Student>(result.Message);
            }

            return new SuccessDataResult<Student>(student, Messages.StudentCreatedSuccessfully);
        }

        public IDataResult<Student> LoginStudent(StudentLoginDto studentLoginDto)
        {
            var isStudentExists = _userService.GetStudentByName(studentLoginDto.Name).Data != null && _userService.GetStudentBySchoolNumber(studentLoginDto.SchoolNumber).Data != null;
            if (!isStudentExists)
            {
                return new ErrorDataResult<Student>(Messages.StudentNotFound);
            }

            var studentToCheck = _userService.GetStudentByName(studentLoginDto.Name).Data;

            if (!HashingHelper.VerifyPasswordHash(studentLoginDto.Password, studentToCheck.PasswordHash, studentToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Student>(Messages.PasswordError);
            }

            return new SuccessDataResult<Student>(studentToCheck, Messages.SuccessfulLogin);
        }

        public IDataResult<AccessToken> CreateAccessTokenForStudent(Student student)
        {
            var claims = _userService.GetClaimsOfStudent(student);
            var accessToken = _tokenHelper.CreateToken(student, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenCreated);
        }

        [SecuredOperation("sysAdmin")]
        public IResult IsStudentExists(string name)
        {
            var result = _userService.GetStudentByName(name).Data;
            if (result != null)
            {
                return new SuccessResult(Messages.StudentAlreadyExists);
            }

            return new ErrorResult(Messages.StudentNotFound);
        }
    }
}
