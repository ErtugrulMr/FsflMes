using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISysAdminService
    {
        IResult Add(SysAdmin sysAdmin);
        IResult Delete(SysAdmin sysAdmin);
        IResult Update(SysAdmin sysAdmin);
        IDataResult<List<SysAdmin>> GetAll();
        IDataResult<SysAdmin> GetById(int id);
    }
}
