using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IReportService
    {
        IResult Add(Report report);
        IResult Delete(Report report);
        IResult Update(Report report);
        IDataResult<List<Report>> GetAll();
        IDataResult<Report> GetById(int id);
        IDataResult<Report> GetByPostId(int id);
    }
}
