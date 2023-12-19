using Microsoft.AspNetCore.Mvc;
using Project.Web.Core.Application.Services;
using Project.Web.Models;
using System.Diagnostics;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        private readonly string _apiUrl;
        //var result = await _httpService.GetAsync<List<CustomerTypeModel>>(_apiUrl, "Customer/customertypes");
        //var result = await _httpService.GetAsync<CustomerTypeModel>(_apiUrl, $"Customer/customertypes/{typeId}");

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IHttpService httpService)
        {
            _logger = logger;
            _configuration = configuration;
            _httpService = httpService;

            _apiUrl = _configuration.GetSection("ApiUrl").Value!;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpService.GetAsync<List<WorkplaceModel>>(_apiUrl, "Workplace/workplaces");

            return View(result);
        }

        public async Task<IActionResult> Workplace()
        {
            var list = await _httpService.GetAsync<List<WorkplaceModel>>(_apiUrl, "Workplace/workplaces");
            var model = list != null && list.Any() ? list.FirstOrDefault() : null;
            return View(model);
        }

        public async Task<IActionResult> AddWorkplace(WorkplaceModel workplaceModel)
        {
            await _httpService.PostAsync<WorkplaceModel>(_apiUrl, "Workplace/workplaces", workplaceModel);

            return RedirectToAction("Workplace");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
