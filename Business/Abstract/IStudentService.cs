using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStudentService
    {
        IResult Add(Student student);
        IResult Delete(Student student);
        IResult Update(Student student);
        IDataResult<List<Student>> GetAll();
        IDataResult<Student> GetById(int id);
    }
}
