using Business.Abstract;
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
    public class ComplaintManager: IComplaintService
    {
        IComplaintDal _complaintDal;

        public ComplaintManager(IComplaintDal complaintDal)
        {
            this._complaintDal = complaintDal;
        }

        public IResult Add(Complaint complaint)
        {
            _complaintDal.Add(complaint);
            return new SuccessResult(Messages.ComplaintCreatedSuccessfully);
        }

        public IResult Delete(Complaint complaint)
        {
            _complaintDal.Delete(complaint);
            return new SuccessResult(Messages.ComplaintDeletedSuccessfully);
        }

        public IResult Update(Complaint complaint)
        {
            _complaintDal.Update(complaint);
            return new SuccessResult(Messages.ComplaintUpdatedSuccessfully);
        }

        public IDataResult<List<Complaint>> GetAll()
        {
            var result = _complaintDal.GetAll();
            return new SuccessDataResult<List<Complaint>>(result);
        }

        public IDataResult<Complaint> GetById(int id)
        {
            var result = _complaintDal.Get(s => s.Id == id);
            return new SuccessDataResult<Complaint>(result);
        }
    }
}
