using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lab6.Api.Controllers
{
    public class AccountsController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5260/api/Accounts");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
                return View(accounts);
            }

            return View(new List<Account>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"/api/Accounts/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var account = JsonConvert.DeserializeObject<Account>(json);
                return View(account);
            }

            return NotFound();
        }

        public async Task<IActionResult> Search(
            decimal? minBalance = null,
            decimal? maxBalance = null,
            DateTime? startDate = null,
            DateTime? endDate = null,
            string nameStart = null!,
            string nameEnd = null!
        )
        {
            var queryParams = new List<string>();

            if (minBalance is not null)
            {
                queryParams.Add($"minBalance={minBalance.Value}");
            }
            if (maxBalance is not null)
            {
                queryParams.Add($"maxBalance={maxBalance.Value}");
            }
            if (startDate is not null)
            {
                queryParams.Add($"startDate={startDate.Value:yyyy-MM-dd}");
            }
            if (endDate is not null)
            {
                queryParams.Add($"endDate={endDate.Value:yyyy-MM-dd}");
            }
            if (!string.IsNullOrEmpty(nameStart))
            {
                queryParams.Add($"nameStart={nameStart}");
            }
            if (!string.IsNullOrEmpty(nameEnd))
            {
                queryParams.Add($"nameEnd={nameEnd}");
            }

            var query = string.Join("&", queryParams);
            var response = await _httpClient.GetAsync($"?{query}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var accounts = JsonConvert.DeserializeObject<List<Account>>(json);
                return View("Index", accounts);
            }

            return View("Index", new List<Account>());
        }
    }
}
