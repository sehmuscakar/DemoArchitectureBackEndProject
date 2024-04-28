﻿using Business.Abstract;
using DataAccess.Abstract;
using Enitities.Concrete;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        public void Add(UserOperationClaim userOperationClaim)
        {
           _userOperationClaimDal.Add(userOperationClaim);
        }
    }
}
