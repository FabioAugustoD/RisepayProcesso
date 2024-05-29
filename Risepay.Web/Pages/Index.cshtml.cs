using Microsoft.AspNetCore.Mvc.RazorPages;
using Risepay.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Risepay.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Colaborador> Colaboradores { get; set; }
        public string SearchString { get; set; }

        public async Task OnGetAsync(string searchString)
        {
            SearchString = searchString;

            string apiUrl = "https://localhost:7107/api/colaboradores"; // Corrija a URL se necessário

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                Colaboradores = JsonConvert.DeserializeObject<List<Colaborador>>(responseString);
            }
            catch (HttpRequestException ex)
            {
                Colaboradores = new List<Colaborador>();
                throw;
            }
        }
    }
}
