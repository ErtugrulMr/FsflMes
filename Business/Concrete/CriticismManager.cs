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
    public class CriticismManager: ICriticismService
    {
        ICriticismDal _criticismDal;

        public CriticismManager(ICriticismDal criticismDal)
        {
            this._criticismDal = criticismDal;
        }

        public IResult Add(Criticism criticism)
        {
            _criticismDal.Add(criticism);
            return new SuccessResult(Messages.CriticismCreatedSuccessfully);
        }

        public IResult Delete(Criticism criticism)
        {
            _criticismDal.Delete(criticism);
            return new SuccessResult(Messages.CriticismDeletedSuccessfully);
        }

        public IResult Update(Criticism criticism)
        {
            _criticismDal.Update(criticism);
            return new SuccessResult(Messages.CriticismUpdatedSuccessfully);
        }

        public IDataResult<List<Criticism>> GetAll()
        {
            var result = _criticismDal.GetAll();
            return new SuccessDataResult<List<Criticism>>(result);
        }

        public IDataResult<Criticism> GetById(int id)
        {
            var result = _criticismDal.Get(s => s.Id == id);
            return new SuccessDataResult<Criticism>(result);
        }
    }
}
