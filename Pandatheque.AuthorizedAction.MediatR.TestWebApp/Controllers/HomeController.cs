﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Pandatheque.AuthorizedAction.MediatR.TestWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
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

        public async Task<IActionResult> CloturerEnquete(int id)
        {
            CloturerEnqueteRequest request = new CloturerEnqueteRequest { EnqueteId = id };
            (bool, Enquete) result = await this.mediator.Send(request);
            if (result.Item1)
            {
                return this.View(result.Item2);
            }

            return this.View("Unauthorized");
        }
    }
}
