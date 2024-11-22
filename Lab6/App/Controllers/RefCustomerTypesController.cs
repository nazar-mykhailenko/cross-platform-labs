using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab6.App.Controllers
{
    public class RefCustomerTypesController : Controller
    {
        private readonly HttpClient _httpClient;

        public RefCustomerTypesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5260/api/RefCustomerTypes");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var customerTypes = JsonConvert.DeserializeObject<List<RefCustomerType>>(json);
                return View(customerTypes);
            }

            return View(new List<RefCustomerType>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"/api/RefCustomerTypes/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var customerType = JsonConvert.DeserializeObject<RefCustomerType>(json);
                return View(customerType);
            }

            return NotFound();
        }
    }
}
