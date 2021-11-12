using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISchAdminService
    {
        IResult Add(SchAdmin schAdmin);
        IResult Delete(SchAdmin schAdmin);
        IResult Update(SchAdmin schAdmin);
        IDataResult<List<SchAdmin>> GetAll();
        IDataResult<SchAdmin> GetById(int id);
    }
}
