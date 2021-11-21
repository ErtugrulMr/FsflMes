using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserOperationClaimManager: IUserOperationClaimService
    {
        private IUserOperationClaimDal _userOperationClaimDal;
        private ISysAdminService _sysAdminService;
        private ISchAdminService _schAdminService;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal, ISysAdminService sysAdminService, ISchAdminService schAdminService)
        {
            _userOperationClaimDal = userOperationClaimDal;
            _sysAdminService = sysAdminService;
            _schAdminService = schAdminService;
        }

        public IResult Add(UserOperationClaim userOperationClaim)
        {
            if ((!_sysAdminService.GetById(userOperationClaim.UserId).Success) &&(_schAdminService.GetById(userOperationClaim.UserId).Success))
            {
                _userOperationClaimDal.Add(userOperationClaim);
                return new SuccessResult(Messages.UserOperationClaimAdded);
            }

            return new ErrorResult(Messages.UserOperationClaimAlreadyExists);
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<UserOperationClaim> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            throw new NotImplementedException();
        }
    }
}
