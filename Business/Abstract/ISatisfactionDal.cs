using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISatisfactionService
    {
        IResult Add(Satisfaction satisfaction);
        IResult Delete(Satisfaction satisfaction);
        IResult Update(Satisfaction satisfaction);
        IDataResult<List<Satisfaction>> GetAll();
        IDataResult<Satisfaction> GetById(int id);
    }
}
