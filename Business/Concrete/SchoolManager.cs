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
    public class SchoolManager : ISchoolService
    {

        ISchoolDal _schoolDal;

        public SchoolManager(ISchoolDal schoolDal)
        {
            _schoolDal = schoolDal;
        }

        public IResult Add(School school)
        {
            _schoolDal.Add(school);
            return new SuccessResult(Messages.SchoolCreatedSuccessfully);
        }

        public IResult Delete(School school)
        {
            _schoolDal.Delete(school);
            return new SuccessResult(Messages.SchoolDeletedSuccessfully);
        }

        public IResult Update(School school)
        {
            _schoolDal.Update(school);
            return new SuccessResult(Messages.SchoolUpdatedSuccessfully);
        }

        public IDataResult<List<School>> GetAll()
        {
            return new SuccessDataResult<List<School>>(_schoolDal.GetAll());
        }

        public IDataResult<School> GetById(int id)
        {
            return new SuccessDataResult<School>(_schoolDal.Get(s => s.Id == id));
        }
    }
}
