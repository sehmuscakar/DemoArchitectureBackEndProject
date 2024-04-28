﻿using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Enitities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
       IResult Register(RegisterAuthDto registerDto); 
        string Login(LoginAuthDto loginDto);
    }
}
