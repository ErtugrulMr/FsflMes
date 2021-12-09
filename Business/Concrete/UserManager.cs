using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Persistance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {

        private ISysAdminDal _sysAdminDal;
        private ISchAdminDal _schAdminDal;
        private IStudentDal _studentDal;

        public UserManager(ISysAdminDal sysAdminDal, ISchAdminDal schAdminDal, IStudentDal studentDal)
        {
            this._sysAdminDal = sysAdminDal;
            this._schAdminDal = schAdminDal;
            this._studentDal = studentDal;
        }


        // SysAdmin Operations

        public IResult AddSysAdmin(SysAdmin sysAdmin)
        {
            if (GetSysAdminById(sysAdmin.Id).Success)
            {
                return new ErrorResult(Messages.SysAdminAlreadyExists);
            }

            int id = 0;
            bool isASuitableIdFound = false;
            while (!isASuitableIdFound)
            {
                id = IdCreator.CreateId();
                if (!(GetStudentById(id).Success || GetSchAdminById(id).Success || GetSysAdminById(id).Success))
                {
                    isASuitableIdFound = true;
                }
            }
            sysAdmin.Id = id;
            _sysAdminDal.Add(sysAdmin);
            return new SuccessResult(Messages.SysAdminCreatedSuccessfully);
        }

        public IResult DeleteSysAdmin(SysAdmin sysAdmin)
        {
            var result = GetSysAdminById(sysAdmin.Id);
            if (result.Success)
            {
                _sysAdminDal.Delete(sysAdmin);
                return new SuccessResult(Messages.SysAdminDeletedSuccessfully);
            }

            return new ErrorResult(Messages.SysAdminNotFound);
        }

        public IResult UpdateSysAdmin(SysAdmin sysAdmin)
        {
            var result = GetSysAdminById(sysAdmin.Id);
            if (result.Success)
            {
                _sysAdminDal.Update(sysAdmin);
                return new SuccessResult(Messages.SysAdminUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.SysAdminNotFound);
        }

        public IDataResult<List<SysAdmin>> GetAllSysAdmins()
        {
            var result = _sysAdminDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<SysAdmin>>(result);
            }

            return new ErrorDataResult<List<SysAdmin>>(Messages.NoSysAdminDataInDatabase);
        }

        public IDataResult<SysAdmin> GetSysAdminById(int id)
        {
            var result = _sysAdminDal.Get(sys => sys.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<SysAdmin>(result);
            }

            return new ErrorDataResult<SysAdmin>(Messages.SysAdminNotFound);
        }

        public IDataResult<SysAdmin> GetSysAdminByUserName(string userName)
        {
            var result = _sysAdminDal.Get(sys => sys.UserName == userName);
            if (result != null)
            {
                return new SuccessDataResult<SysAdmin>(result);
            }

            return new ErrorDataResult<SysAdmin>(Messages.SysAdminNotFound);
        }

        public List<OperationClaim> GetClaimsOfSysAdmin(SysAdmin sysAdmin)
        {
            return _sysAdminDal.GetClaims(sysAdmin);
        }


        // SchAdmin Operations

        public IResult AddSchAdmin(SchAdmin schAdmin)
        {
            if (GetSchAdminById(schAdmin.Id).Success)
            {
                return new ErrorResult(Messages.SchAdminAlreadyExists);
            }

            int id = 0;
            bool isASuitableIdFound = false;
            while (!isASuitableIdFound)
            {
                id = IdCreator.CreateId();
                if (!(GetStudentById(id).Success || GetSchAdminById(id).Success || GetSysAdminById(id).Success))
                {
                    isASuitableIdFound = true;
                }
            }
            schAdmin.Id = id;
            _schAdminDal.Add(schAdmin);
            return new SuccessResult(Messages.SchAdminCreatedSuccessfully);
        }

        public IResult DeleteSchAdmin(SchAdmin schAdmin)
        {
            var result = GetSchAdminById(schAdmin.Id);
            if (result.Success)
            {
                _schAdminDal.Delete(schAdmin);
                return new SuccessResult(Messages.SchAdminDeletedSuccessfully);
            }

            return new ErrorResult(Messages.SchAdminNotFound);
        }

        public IResult UpdateSchAdmin(SchAdmin schAdmin)
        {
            var result = GetSchAdminById(schAdmin.Id);
            if (result.Success)
            {
                _schAdminDal.Update(schAdmin);
                return new SuccessResult(Messages.SchAdminUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.SchAdminNotFound);
        }

        public IDataResult<List<SchAdmin>> GetAllSchAdmins()
        {
            var result = _schAdminDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<SchAdmin>>(result);
            }

            return new ErrorDataResult<List<SchAdmin>>(Messages.NoSchAdminDataInDatabase);
        }

        public IDataResult<SchAdmin> GetSchAdminById(int id)
        {
            var result = _schAdminDal.Get(st => st.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<SchAdmin>(result);
            }

            return new ErrorDataResult<SchAdmin>(Messages.SchAdminNotFound);
        }

        public IDataResult<SchAdmin> GetSchAdminByUserName(string userName)
        {
            var result = _schAdminDal.Get(st => st.UserName == userName);
            if (result != null)
            {
                return new SuccessDataResult<SchAdmin>(result);
            }

            return new ErrorDataResult<SchAdmin>(Messages.SchAdminNotFound);
        }

        public List<OperationClaim> GetClaimsOfSchAdmin(SchAdmin schAdmin)
        {
            return _schAdminDal.GetClaims(schAdmin);
        }


        // Student Operations

        public IResult AddStudent(Student student)
        {
            if (GetStudentById(student.Id).Success)
            {
                return new ErrorResult(Messages.StudentAlreadyExists);
            }

            int id = 0;
            bool isASuitableIdFound = false;
            while (!isASuitableIdFound)
            {
                id = IdCreator.CreateId();
                if (!(GetStudentById(id).Success || GetSchAdminById(id).Success || GetSysAdminById(id).Success))
                {
                    isASuitableIdFound = true;
                }
            }
            student.Id = id;
            _studentDal.Add(student);
            return new SuccessResult(Messages.StudentCreatedSuccessfully);
        }

        public IResult DeleteStudent(Student student)
        {
            var result = GetStudentById(student.Id);
            if (result.Success)
            {
                _studentDal.Delete(student);
                return new SuccessResult(Messages.StudentDeletedSuccessfully);
            }

            return new ErrorResult(Messages.StudentNotFound);
        }

        public IResult UpdateStudent(Student student)
        {
            var result = GetStudentById(student.Id);
            if (result.Success)
            {
                _studentDal.Update(student);
                return new SuccessResult(Messages.StudentUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.StudentNotFound);
        }

        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Student>> GetAllStudents()
        {
            var result = _studentDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Student>>(result);
            }

            return new ErrorDataResult<List<Student>>(Messages.NoStudentDataInDatabase);
        }

        public IDataResult<Student> GetStudentById(int id)
        {
            var result = _studentDal.Get(st => st.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(Messages.StudentNotFound);
        }

        public IDataResult<Student> GetStudentByName(string name)
        {
            var result = _studentDal.Get(st => st.Name == name);
            if (result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(Messages.StudentNotFound);
        }
        
        public IDataResult<Student> GetStudentBySchoolNumber(int schoolNumber)
        {
            var result = _studentDal.Get(st => st.SchoolNumber == schoolNumber);
            if (result != null)
            {
                return new SuccessDataResult<Student>(result);
            }

            return new ErrorDataResult<Student>(Messages.StudentNotFound);
        }

        public IDataResult<StudentDetailsDto> GetStudentDetails(int id)
        {
            var result = _studentDal.GetStudentDetails(id);
            if (result != null)
            {
                return new SuccessDataResult<StudentDetailsDto>(result);
            }

            return new ErrorDataResult<StudentDetailsDto>(result);
        }

        public List<OperationClaim> GetClaimsOfStudent(Student student)
        {
            return _studentDal.GetClaims(student);
        }



        // All Users Operations

        public bool IsExistsForAll(int id)
        {
            if (GetSysAdminById(id).Success)
            {
                return true;
            }
            
            if (GetSchAdminById(id).Success)
            {
                return true;
            }
            
            if (GetStudentById(id).Success)
            {
                return true;
            }

            return false;
        }
    }
}
