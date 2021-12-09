﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReportManager: IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            this._reportDal = reportDal;
        }

        public IResult Add(Report report)
        {
            _reportDal.Add(report);
            return new SuccessResult(Messages.ReportCreatedSuccessfully);
        }

        public IResult Delete(Report report)
        {
            _reportDal.Delete(report);
            return new SuccessResult(Messages.ReportDeletedSuccessfully);
        }

        public IResult Update(Report report)
        {
            _reportDal.Update(report);
            return new SuccessResult(Messages.ReportUpdatedSuccessfully);
        }

        public IDataResult<List<Report>> GetAll()
        {
            var result = _reportDal.GetAll();
            return new SuccessDataResult<List<Report>>(result);
        }

        public IDataResult<Report> GetById(int id)
        {
            var result = _reportDal.Get(s => s.Id == id);
            return new SuccessDataResult<Report>(result);
        }
    }
}
