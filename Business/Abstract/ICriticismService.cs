using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICriticismService
    {
        IResult Add(Criticism criticism);
        IResult Delete(Criticism criticism);
        IResult Update(Criticism criticism);
        IDataResult<List<Criticism>> GetAll();
        IDataResult<Criticism> GetById(int id);
    }
}
