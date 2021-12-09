using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IReportService
    {
        IResult Add(Report report);
        IResult Delete(Report report);
        IResult Update(Report report);
        IDataResult<List<Report>> GetAll();
        IDataResult<Report> GetById(int id);
    }
}
