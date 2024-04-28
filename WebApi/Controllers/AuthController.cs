﻿using Business.Abstract;
using Enitities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterAuthDto authDto)
        {



          var result=  _authService.Register(authDto); 
            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginAuthDto authDto)
        {
           var result= _authService.Login(authDto);
            return Ok(result);
        }
    }
}
