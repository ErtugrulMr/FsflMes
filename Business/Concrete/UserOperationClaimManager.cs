using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserOperationClaimManager: IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;
        private IUserService _userService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, IUserService userService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _userService = userService;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            var result = GetById(userOperationClaim.Id);
            if (!result.Success)
            {
                _userOperationClaimDal.Add(userOperationClaim);
                return new SuccessResult(Messages.UserOperationClaimAdded);
            }

            return new ErrorResult(Messages.UserOperationClaimAlreadyExists);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = GetById(userOperationClaim.Id);
            if (result.Success)
            {
                _userOperationClaimDal.Delete(userOperationClaim);
                return new SuccessResult(Messages.UserOperationClaimDeleted);
            }

            return new ErrorResult(Messages.UserOperationClaimNotFound);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var result = GetById(userOperationClaim.Id);
            if (result.Success)
            {
                _userOperationClaimDal.Update(userOperationClaim);
                return new SuccessResult(Messages.UserOperationClaimUpdated);
            }

            return new ErrorResult(Messages.UserOperationClaimNotFound);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            var result = _userOperationClaimDal.GetAll();
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<UserOperationClaim>>(result);
            }

            return new ErrorDataResult<List<UserOperationClaim>>(result);
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            var result = _userOperationClaimDal.Get(uoc=>uoc.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<UserOperationClaim>(result);
            }

            return new ErrorDataResult<UserOperationClaim>(result);
        }

        public IDataResult<UserOperationClaim> GetByUserId(int id)
        {
            var result = _userOperationClaimDal.Get(uoc => uoc.UserId == id);
            if (result != null)
            {
                return new SuccessDataResult<UserOperationClaim>(result);
            }

            return new ErrorDataResult<UserOperationClaim>(result);
        }

        public IDataResult<UserOperationClaim> GetByOperationClaimId(int id)
        {
            var result = _userOperationClaimDal.Get(uoc => uoc.OperationClaimId == id);
            if (result != null)
            {
                return new SuccessDataResult<UserOperationClaim>(result);
            }

            return new ErrorDataResult<UserOperationClaim>(result);
        }
    }
}
