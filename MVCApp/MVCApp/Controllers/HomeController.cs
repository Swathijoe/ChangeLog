using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            IEnumerable<ChangeLogViewMdoel> logs = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44332/api/");
                //HTTP GET
                var responseTask = client.GetAsync("changelog");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ChangeLogViewMdoel>>();
                    readTask.Wait();

                    logs = readTask.Result.OrderByDescending(c=>c.ChangeLogTime);
                }
                else 
                {

                    logs = Enumerable.Empty<ChangeLogViewMdoel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(logs);
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
