using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete
{
    public class EfUserOperationClaimDal: EfEntityRepositoryBase<UserOperationClaim,FsflMesContext>, IUserOperationClaimDal
    {
    }
}
