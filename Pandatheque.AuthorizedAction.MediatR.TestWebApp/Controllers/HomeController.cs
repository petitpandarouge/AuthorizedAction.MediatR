using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Models;
using Pandatheque.AuthorizedAction.MediatR.TestWebApp.Requests;
using System.Collections.Generic;
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

        public async Task<IActionResult> CanCloturerEnquete(int id)
        {
            CanCloturerEnqueteRequest request = new CanCloturerEnqueteRequest { EnqueteId = id };
            bool result = await this.mediator.Send(request).ConfigureAwait(false);
            return this.View(result);
        }

        public async Task<IActionResult> CloturerEnquete(int id)
        {
            CloturerEnqueteRequest request = new CloturerEnqueteRequest { EnqueteId = id };
            (bool, Enquete) result = await this.mediator.Send(request).ConfigureAwait(false);
            if (result.Item1)
            {
                return this.View(result.Item2);
            }

            return this.View("Unauthorized");
        }

        public async Task<IActionResult> ListerEnquetes()
        {
            ListerEnquetesRequest request = new ListerEnquetesRequest();
            (bool, ICollection<Enquete>) result = await this.mediator.Send(request).ConfigureAwait(false);
            if (result.Item1)
            {
                return this.View(result.Item2);
            }

            return this.View("Unauthorized");
        }
    }
}
