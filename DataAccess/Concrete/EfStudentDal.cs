using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfStudentDal: EfEntityRepositoryBase<Student, FsflMesContext>, IStudentDal
    {
        public List<OperationClaim> GetClaims(Student student)
        {
            using (var context = new FsflMesContext())
            {
                var result = (from operationClaim in context.OperationClaims
                              join userOperationClaim in context.UserOperationClaims
                                  on operationClaim.Id equals userOperationClaim.OperationClaimId
                              where userOperationClaim.UserId == student.Id
                              select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }).ToList();
                if (result.Count > 0)
                {
                    return result;
                }

                throw new DatabaseException("An error occured while getting claims.");
            }
        }
    }
}
