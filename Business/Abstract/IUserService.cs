﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult AddSysAdmin(SysAdmin sysAdmin);
        IResult DeleteSysAdmin(SysAdmin sysAdmin);
        IResult UpdateSysAdmin(SysAdmin sysAdmin);
        IDataResult<List<SysAdmin>> GetAllSysAdmins();
        IDataResult<SysAdmin> GetSysAdminById(int id);
        IDataResult<SysAdmin> GetSysAdminByUserName(string userName);
        List<OperationClaim> GetClaimsOfSysAdmin(SysAdmin sysAdmin);
        IResult AddSchAdmin(SchAdmin schAdmin);
        IResult DeleteSchAdmin(SchAdmin schAdmin);
        IResult UpdateSchAdmin(SchAdmin schAdmin);
        IDataResult<List<SchAdmin>> GetAllSchAdmins();
        IDataResult<SchAdmin> GetSchAdminById(int id);
        IDataResult<SchAdmin> GetSchAdminByUserName(string userName);
        List<OperationClaim> GetClaimsOfSchAdmin(SchAdmin schAdmin);
    }
}