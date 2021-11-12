using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISchoolService
    {
        IResult Add(School school); 
        IResult Delete(School school);
        IResult Update(School school);
        IDataResult<List<School>> GetAll();
        IDataResult<School> GetById(int id);
    }
}
