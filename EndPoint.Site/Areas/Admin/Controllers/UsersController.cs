using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hooshAuto.Application.Services.Users.Commands.RegisterUser;

using hooshAuto.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IRegisterUserService _registerUserService;
       
        public UsersController(IGetUsersService getUsersService
            , IRegisterUserService registerUserService)
        {
            _getUsersService = getUsersService;
            _registerUserService = registerUserService;
           
        }


    public IActionResult Index()
        {
            return View(_getUsersService.Execute());
        }





        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                RoleId = RoleId,
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        

    }
}
