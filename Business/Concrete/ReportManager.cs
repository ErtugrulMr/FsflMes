using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class ReportManager: IReportService
    {
        IReportDal _reportDal;

        public ReportManager(IReportDal reportDal)
        {
            this._reportDal = reportDal;
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReportService.Get")]
        [ValidationAspect(typeof(ReportValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Add(Report report)
        {
            _reportDal.Add(report);
            return new SuccessResult(Messages.ReportCreatedSuccessfully);
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReportService.Get")]
        [ValidationAspect(typeof(ReportValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Delete(Report report)
        {
            var result = GetById(report.Id);
            if (result.Success)
            {
                _reportDal.Delete(report);
                return new SuccessResult(Messages.ReportDeletedSuccessfully);
            }
            
            return new ErrorResult(Messages.ReportNotFound);
        }

        [PerformanceAspect(5)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IReportService.Get")]
        [ValidationAspect(typeof(ReportValidator))]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IResult Update(Report report)
        {
            var result = GetById(report.Id);
            if (result.Success)
            {
                _reportDal.Update(report);
                return new SuccessResult(Messages.ReportUpdatedSuccessfully);
            }

            return new ErrorResult(Messages.ReportNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<List<Report>> GetAll()
        {
            var result = _reportDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<Report>>(result);
            }
            
            return new ErrorDataResult<List<Report>>(result, Messages.NoReportDataInDatabase);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<Report> GetById(int id)
        {
            var result = _reportDal.Get(s => s.Id == id);
            if (result!=null)
            {
                return new SuccessDataResult<Report>(result);
            }
            
            return new ErrorDataResult<Report>(result, Messages.ReportNotFound);
        }

        [PerformanceAspect(5)]
        [CacheAspect(30)]
        [SecuredOperation("sysAdmin,schAdmin,student")]
        public IDataResult<Report> GetByPostId(int id)
        {
            var result = _reportDal.Get(s => s.PostId == id);
            if (result!=null)
            {
                return new SuccessDataResult<Report>(result);
            }

            return new ErrorDataResult<Report>(result, Messages.ReportNotFound);
        }
    }
}
