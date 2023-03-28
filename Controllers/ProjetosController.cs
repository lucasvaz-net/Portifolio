using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Models;
using static Portifolio.Models.ProjetosModel;

namespace Portifolio.Controllers
{
    public class ProjetosController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProjetosController()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var apiUri = "https://api.github.com/repos/lucasvaz-net/PythonAPI/projects";

            var response = _httpClient.GetAsync(apiUri).Result;
            if (response.IsSuccessStatusCode)
            {
                var gitHubProjectApiModel = response.Content.ReadAsAsync<GitHubProjectApiModel>().Result;
                var projetosModel = new ProjetosModel
                {
                    Nome = gitHubProjectApiModel.Name,
                    Descricao = gitHubProjectApiModel.Description,
                    Url = gitHubProjectApiModel.Url
                };

                var projects = new List<ProjetosModel> { projetosModel };
                return Json(projects);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return StatusCode((int)response.StatusCode, content);
            }
        }
    }
}
