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
    public class SysAdminManager : ISysAdminService
    {

        private ISysAdminDal _sysAdminDal;
        private ISchAdminDal _schAdminDal;

        public SysAdminManager(ISysAdminDal sysAdminDal, ISchAdminDal schAdminDal)
        {
            this._sysAdminDal = sysAdminDal;
            this._schAdminDal = schAdminDal;
        }

        public IResult Add(SysAdmin sysAdmin)
        {
            int id = 0;
            bool isASuitableIdFound = false;
            while (!isASuitableIdFound)
            {
                id = IdCreator.CreateId();
                bool isExists = _schAdminDal.Get(sc => sc.Id == id)!=null && GetById(id)!=null;
                if (!isExists)
                {
                    isASuitableIdFound = true;
                }
            }
            sysAdmin.Id = id;
            _sysAdminDal.Add(sysAdmin);
            return new SuccessResult(Messages.SysAdminCreatedSuccessfully);
        }

        public IResult Delete(SysAdmin sysAdmin)
        {
            _sysAdminDal.Delete(sysAdmin);
            return new SuccessResult(Messages.SysAdminDeletedSuccessfully);
        }

        public IResult Update(SysAdmin sysAdmin)
        {
            _sysAdminDal.Update(sysAdmin);
            return new SuccessResult(Messages.SysAdminUpdatedSuccessfully);
        }

        public IDataResult<List<SysAdmin>> GetAll()
        {
            var result = _sysAdminDal.GetAll();
            return new SuccessDataResult<List<SysAdmin>>(result);
        }

        public IDataResult<SysAdmin> GetById(int id)
        {
            var result = _sysAdminDal.Get(s => s.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<SysAdmin>(result);
            }
            
            return new ErrorDataResult<SysAdmin>(Messages.SysAdminNotFound);
        }

        public IDataResult<SysAdmin> GetByUserName(string userName)
        {
            var result = _sysAdminDal.Get(s => s.UserName == userName);
            if (result != null)
            {
                return new SuccessDataResult<SysAdmin>(result);
            }

            return new ErrorDataResult<SysAdmin>(Messages.SysAdminNotFound);
        }

        public List<OperationClaim> GetClaims(SysAdmin sysAdmin)
        {
            return _sysAdminDal.GetClaims(sysAdmin);
        }
    }
}
