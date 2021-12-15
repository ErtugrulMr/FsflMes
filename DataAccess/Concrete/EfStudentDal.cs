using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

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

        public StudentDetailsDto GetStudentDetails(int studentId)
        {
            using (var context = new FsflMesContext())
            {
                var result = from student in context.Students
                             join schoolClass in context.SchoolClasses
                             on student.ClassId equals schoolClass.Id
                             where student.Id == studentId
                             select new StudentDetailsDto
                             {
                                 Id = student.Id,
                                 SchoolNumber = student.SchoolNumber,
                                 StudentFirstName = student.FirstName,
                                 StudentLastName = student.LastName,
                                 ClassName = schoolClass.Name,
                                 NationalIdentityNumber = student.NationalIdentityNumber,
                                 Status = student.Status,
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
