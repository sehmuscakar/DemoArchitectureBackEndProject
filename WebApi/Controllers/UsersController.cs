﻿using Business.Abstract;
using Core.Utilities.Hashing;
using Enitities.Concrete;
using Enitities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }    

        [HttpGet("getList")]
        public IActionResult GetList()
        {
           
            return Ok(_userService.GetList());
        }
    }
}
