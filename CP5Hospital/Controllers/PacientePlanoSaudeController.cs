using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CP5Hospital.Models;

namespace CP5Hospital.Controllers
{
    public class PacientePlanoSaudeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PacientePlanoSaudeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IActionResult Associate() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Associate(PacientePlanoSaude associacao)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                var response = await client.PostAsJsonAsync("api/PacientePlanoSaude", associacao);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(ListarPacientes));
                }
                ModelState.AddModelError(string.Empty, "Erro ao associar o paciente ao plano de saúde.");
            }

            return View(associacao);
        }

        public async Task<IActionResult> ListarPacientes()
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync("api/PacientePlanoSaude");

            if (response.IsSuccessStatusCode)
            {
                var pacientes = await response.Content.ReadFromJsonAsync<List<Paciente>>();
                return View(pacientes);
            }

            return View(new List<Paciente>());
        }

        public async Task<IActionResult> ListarPlanos()
        {
            var client = _clientFactory.CreateClient("APIClient");
            var response = await client.GetAsync("api/PacientePlanoSaude");

            if (response.IsSuccessStatusCode)
            {
                var planos = await response.Content.ReadFromJsonAsync<List<PlanoSaude>>();
                return View(planos);
            }

            return View(new List<PlanoSaude>());
        }
    }
}
