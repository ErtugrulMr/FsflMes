using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfSchAdminDal: EfEntityRepositoryBase<SchAdmin, FsflMesContext>, ISchAdminDal
    {
        public List<OperationClaim> GetClaims(SchAdmin schAdmin)
        {
            using (var context = new FsflMesContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == schAdmin.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result?.ToList();

            }
        }
    }
}
