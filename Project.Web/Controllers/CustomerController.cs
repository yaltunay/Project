using Microsoft.AspNetCore.Mvc;
using Project.Web.Models;
using System.Diagnostics;
using Project.Web.Core.Application.Services;

namespace Project.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpService _httpService;

        private readonly string _apiUrl;

        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration, IHttpService httpService)
        {
            _logger = logger;
            _configuration = configuration;
            _httpService = httpService;

            _apiUrl = _configuration.GetSection("ApiUrl").Value!;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _httpService.GetAsync<List<CustomerModel>>(_apiUrl, "Customer/customers");
            return View(model);
        }

        public async Task<IActionResult> Customer()
        {
            ViewBag.CustomerTypes = await _httpService.GetAsync<List<CustomerTypeModel>>(_apiUrl, "Customer/customertypes");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerModel customer)
        {
            var result = await _httpService.PostAsync<CustomerModel>(_apiUrl, "Customer/customers", customer);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetCustomerType()
        {
            var result = await _httpService.GetAsync<List<CustomerTypeModel>>(_apiUrl, "Customer/customertypes");
            return View(result);
        }
        public async Task<IActionResult> CustomerType()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerType(CustomerTypeModel customerType)
        {
            var result = await _httpService.PostAsync<CustomerTypeModel>(_apiUrl, "Customer/customertypes", customerType);

            return RedirectToAction("GetCustomerType");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
