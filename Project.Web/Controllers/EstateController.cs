using Microsoft.AspNetCore.Mvc;
using Project.Web.Core.Application.Services;
using Project.Web.Models;
using System.Diagnostics;

namespace Project.Web.Controllers
{
    public class EstateController : Controller
    {
        private readonly ILogger<EstateController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        private readonly string _apiUrl;

        public EstateController(ILogger<EstateController> logger, IConfiguration configuration, IHttpService httpService)
        {
            _logger = logger;
            _configuration = configuration;
            _httpService = httpService;


            _apiUrl = _configuration.GetSection("ApiUrl").Value!;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpService.GetAsync<List<EstateModel>>(_apiUrl, "Estate/estates");
            return View(result);
        }
        public async Task<IActionResult> Estate()
        {
            ViewBag.Customers = await _httpService.GetAsync<List<CustomerModel>>(_apiUrl, "Customer/customers");
            ViewBag.EstateTypes = await _httpService.GetAsync<List<EstateTypeModel>>(_apiUrl, "Estate/estatetypes");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEstate(EstateModel estate)
        {
            var result = await _httpService.PostAsync<EstateModel>(_apiUrl, "Estate/estates", estate);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> GetEstateType()
        {
            var result = await _httpService.GetAsync<List<EstateTypeModel>>(_apiUrl, "Estate/estatetypes");

            return View(result);
        }

        public async Task<IActionResult> EstateType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEstateType(EstateTypeModel estateType)
        {
            var result = await _httpService.PostAsync<EstateTypeModel>(_apiUrl, "Estate/estatetypes", estateType);

            return RedirectToAction("GetEstateType");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
