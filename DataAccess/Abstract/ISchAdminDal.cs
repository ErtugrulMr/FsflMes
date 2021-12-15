using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ISchAdminDal: IEntityRepository<SchAdmin>
    {
        List<OperationClaim> GetClaims(SchAdmin schAdmin);
    }
}
