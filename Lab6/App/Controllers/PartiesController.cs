using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab6.App.Controllers
{
    public class PartiesController : Controller
    {
        private readonly HttpClient _httpClient;

        public PartiesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5260/api/Parties");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var parties = JsonConvert.DeserializeObject<List<Party>>(json);
                return View(parties);
            }

            return View(new List<Party>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Parties/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var party = JsonConvert.DeserializeObject<Party>(json);
                return View(party);
            }

            return NotFound();
        }
    }
}
