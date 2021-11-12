using Business.Abstract;
using Business.Constants;
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

        ISysAdminDal _sysAdminDal;

        public SysAdminManager(ISysAdminDal sysAdminDal)
        {
            this._sysAdminDal = sysAdminDal;
        }

        public IResult Add(SysAdmin sysAdmin)
        {
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
            return new SuccessDataResult<SysAdmin>(result);
        }


    }
}
