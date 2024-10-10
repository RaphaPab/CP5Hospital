using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CP5Hospital.Models;

namespace CP5Hospital.Controllers
{
    public class PlanosSaudeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PlanosSaudeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync("api/PlanosSaude");

            if (response.IsSuccessStatusCode)
            {
                var planos = await response.Content.ReadFromJsonAsync<List<PlanoSaude>>();
                return View(planos);
            }

            return View(new List<PlanoSaude>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanoSaude plano)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                var response = await client.PostAsJsonAsync("api/PlanosSaude", plano);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Erro ao criar o plano de saúde.");
            }

            return View(plano);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/PlanosSaude/{id}");

            if (response.IsSuccessStatusCode)
            {
                var plano = await response.Content.ReadFromJsonAsync<PlanoSaude>();
                return View(plano);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlanoSaude plano)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                var response = await client.PutAsJsonAsync($"api/PlanosSaude/{id}", plano);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Erro ao atualizar o plano de saúde.");
            }

            return View(plano);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/PlanosSaude/{id}");

            if (response.IsSuccessStatusCode)
            {
                var plano = await response.Content.ReadFromJsonAsync<PlanoSaude>();
                return View(plano);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.DeleteAsync($"api/PlanosSaude/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/PlanosSaude/{id}");

            if (response.IsSuccessStatusCode)
            {
                var plano = await response.Content.ReadFromJsonAsync<PlanoSaude>();
                return View(plano);
            }

            return NotFound();
        }
    }
}
