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
    public class SatisfactionManager: ISatisfactionService
    {
        ISatisfactionDal _satisfactionDal;

        public SatisfactionManager(ISatisfactionDal satisfactionDal)
        {
            this._satisfactionDal = satisfactionDal;
        }

        public IResult Add(Satisfaction satisfaction)
        {
            _satisfactionDal.Add(satisfaction);
            return new SuccessResult(Messages.SatisfactionCreatedSuccessfully);
        }

        public IResult Delete(Satisfaction satisfaction)
        {
            _satisfactionDal.Delete(satisfaction);
            return new SuccessResult(Messages.SatisfactionDeletedSuccessfully);
        }

        public IResult Update(Satisfaction satisfaction)
        {
            _satisfactionDal.Update(satisfaction);
            return new SuccessResult(Messages.SatisfactionUpdatedSuccessfully);
        }

        public IDataResult<List<Satisfaction>> GetAll()
        {
            var result = _satisfactionDal.GetAll();
            return new SuccessDataResult<List<Satisfaction>>(result);
        }

        public IDataResult<Satisfaction> GetById(int id)
        {
            var result = _satisfactionDal.Get(s => s.Id == id);
            return new SuccessDataResult<Satisfaction>(result);
        }
    }
}
