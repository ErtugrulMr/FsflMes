using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ISysAdminDal: IEntityRepository<SysAdmin>
    {
        List<OperationClaim> GetClaims(SysAdmin sysAdmin);
    }
}
