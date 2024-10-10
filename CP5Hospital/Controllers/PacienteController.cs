using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CP5Hospital.Models;

namespace CP5Hospital.Controllers
{
    public class PacienteController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PacienteController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync("api/Paciente");

            if (response.IsSuccessStatusCode)
            {
                var pacientes = await response.Content.ReadFromJsonAsync<List<Paciente>>();
                return View(pacientes);
            }

            return View(new List<Paciente>());
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                var response = await client.PostAsJsonAsync("api/Paciente", paciente);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Erro ao criar o paciente.");
            }

            return View(paciente);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/Paciente/{id}");

            if (response.IsSuccessStatusCode)
            {
                var paciente = await response.Content.ReadFromJsonAsync<Paciente>();
                return View(paciente);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                var response = await client.PutAsJsonAsync($"api/Paciente/{id}", paciente);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Erro ao atualizar o paciente.");
            }

            return View(paciente);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/Paciente/{id}");

            if (response.IsSuccessStatusCode)
            {
                var paciente = await response.Content.ReadFromJsonAsync<Paciente>();
                return View(paciente);
            }

            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.DeleteAsync($"api/Paciente/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync($"api/Paciente/{id}");

            if (response.IsSuccessStatusCode)
            {
                var paciente = await response.Content.ReadFromJsonAsync<Paciente>();
                return View(paciente);
            }

            return NotFound();
        }
    }
}
