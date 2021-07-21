using EmergentCodeChallenge.Models;
using EmergentCodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace EmergentCodeChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SearchViewModel searchModel)
        {
            if (searchModel == null || string.IsNullOrWhiteSpace(searchModel?.SoftwareVersion))
            {
                //Didn't provide anything to search on
                return View(new SearchViewModel() { Message = "Please provide a version to see all software in use with a greater version." });
            }

            var softwareModel = new SoftwareViewModel(string.Empty, searchModel.SoftwareVersion);
            if(softwareModel.MajorVersion == softwareModel.MinorVersion && softwareModel.MajorVersion == softwareModel.PatchVersion && softwareModel.MajorVersion == SoftwareViewModel.DefaultVersionPartValue)
            {
                //Couldn't parse the text as any part of a semantic version
                return View(new SearchViewModel() { Message = "Please provide a version in the semantic versioning format.  eg: 2 or 2.0 or 2.0.0" });
            }
            
            //Get the data, filter it, and return the result
            var returnList = SoftwareManager.GetAllSoftware()
                                .Select(software => new SoftwareViewModel(software.Name, software.Version))
                                .Where(software => software.GreaterThan(softwareModel));

            var resultModel = new SearchViewModel(searchModel.SoftwareVersion, returnList);
            return View(resultModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
