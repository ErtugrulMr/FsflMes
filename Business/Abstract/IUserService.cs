using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {

        // SysAdmin Operations

        IResult AddSysAdmin(SysAdmin sysAdmin);
        IResult DeleteSysAdmin(SysAdmin sysAdmin);
        IResult UpdateSysAdmin(SysAdmin sysAdmin);
        IDataResult<List<SysAdmin>> GetAllSysAdmins();
        IDataResult<SysAdmin> GetSysAdminById(int id);
        IDataResult<SysAdmin> GetSysAdminByUserName(string userName);
        List<OperationClaim> GetClaimsOfSysAdmin(SysAdmin sysAdmin);


        // SchAdmin Operations

        IResult AddSchAdmin(SchAdmin schAdmin);
        IResult DeleteSchAdmin(SchAdmin schAdmin);
        IResult UpdateSchAdmin(SchAdmin schAdmin);
        IDataResult<List<SchAdmin>> GetAllSchAdmins();
        IDataResult<SchAdmin> GetSchAdminById(int id);
        IDataResult<SchAdmin> GetSchAdminByUserName(string userName);
        List<OperationClaim> GetClaimsOfSchAdmin(SchAdmin schAdmin);


        // Student Operations

        IResult AddStudent(Student student);
        IResult DeleteStudent(Student student);
        IDataResult<List<Student>> GetAllStudents();
        IDataResult<Student> GetStudentById(int id);
        IDataResult<Student> GetStudentByName(string name);
        IDataResult<Student> GetStudentBySchoolNumber(int schoolNumber);
        IDataResult<StudentDetailsDto> GetStudentDetails(int id);
        List<OperationClaim> GetClaimsOfStudent(Student student);

        // All Users Operations

        bool IsExistsForAll(int id);
    }
}
