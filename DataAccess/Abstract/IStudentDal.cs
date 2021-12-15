using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IStudentDal: IEntityRepository<Student>
    {
        List<OperationClaim> GetClaims(Student student);
        StudentDetailsDto GetStudentDetails(int studentId);
    }
}
