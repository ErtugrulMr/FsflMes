using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Persistance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public UserManager(ISysAdminDal sysAdminDal, ISchAdminDal schAdminDal)
        {
            this._sysAdminDal = sysAdminDal;
            this._schAdminDal = schAdminDal;
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
                bool isExists = GetSchAdminById(id).Success || GetSysAdminById(id).Success;
                if (!isExists)
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
                bool isExists = GetSchAdminById(id).Success || GetSysAdminById(id).Success;
                if (!isExists)
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
            var result = _schAdminDal.Get(sys => sys.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<SchAdmin>(result);
            }

            return new ErrorDataResult<SchAdmin>(Messages.SchAdminNotFound);
        }

        public IDataResult<SchAdmin> GetSchAdminByUserName(string userName)
        {
            var result = _schAdminDal.Get(sys => sys.UserName == userName);
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
    }
}
