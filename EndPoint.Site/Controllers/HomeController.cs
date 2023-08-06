using EndPoint.Site.Models;
using EndPoint.Site.Utilities;
using hooshAuto.Application.Services.Mails.Commands.CreateMail;
using hooshAuto.Application.Services.Mails.Queries;
using hooshAuto.Application.Services.Mails.Queries.ShowMailContent;
using hooshAuto.Application.Services.Users.Commands.RegisterUser;
using hooshAuto.Application.Services.Users.Queries.GetUsers;
using hooshAuto.Domain.Entities.Mails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGetMailsService _getMailsService;
        private readonly ICreateMailService _createMailService;
        private readonly IShowMailContent _showMailContent;

        public HomeController(ILogger<HomeController> logger,
            IGetMailsService getMailsService,
            ICreateMailService createMailService,
            IShowMailContent showMailContent) {

            _getMailsService = getMailsService;
            _createMailService = createMailService;
            _showMailContent = showMailContent;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var userEmail = ClaimUtility.GetUserEmail(User);
           
            return View(_getMailsService.Execute(userEmail));
        }



        [HttpGet]
        public IActionResult CreateMail()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateMail(string Sender, string Reciever, string Title, string content)
        {
            var result = _createMailService.Execute(new RequestCreateMailDto
            {
                Sender = Sender,
                Reciever = Reciever,
                Title = Title,
                content = content,
            });
            return Json(result);
        }


        public IActionResult MailContent(long Id)
        {
            return View(_showMailContent.Execute(Id).Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
