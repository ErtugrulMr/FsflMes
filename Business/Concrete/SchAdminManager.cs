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
    public class SchAdminManager: ISchAdminService
    {
        ISchAdminDal _schAdminDal;

        public SchAdminManager(ISchAdminDal schAdminDal)
        {
            this._schAdminDal = schAdminDal;
        }

        public IResult Add(SchAdmin schAdmin)
        {
            _schAdminDal.Add(schAdmin);
            return new SuccessResult(Messages.SchAdminCreatedSuccessfully);
        }

        public IResult Delete(SchAdmin schAdmin)
        {
            _schAdminDal.Delete(schAdmin);
            return new SuccessResult(Messages.SchAdminDeletedSuccessfully);
        }

        public IResult Update(SchAdmin schAdmin)
        {
            _schAdminDal.Update(schAdmin);
            return new SuccessResult(Messages.SchAdminUpdatedSuccessfully);
        }

        public IDataResult<List<SchAdmin>> GetAll()
        {
            var result = _schAdminDal.GetAll();
            return new SuccessDataResult<List<SchAdmin>>(result);
        }

        public IDataResult<SchAdmin> GetById(int id)
        {
            var result = _schAdminDal.Get(s => s.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<SchAdmin>(result);
            }
            
            return new ErrorDataResult<SchAdmin>(Messages.SchAdminNotFound);
        }

    }
}
