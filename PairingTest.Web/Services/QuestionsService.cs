using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using PairingTest.Web.Models;
using PairingTest.Web.Interfaces;

namespace PairingTest.Web.Services
{
    public class QuestionsService : IQuestionsService
    {
        private readonly string _uri;
        private readonly HttpClient _httpClient;

        public QuestionsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _uri = ConfigurationManager.AppSettings["QuestionnaireServiceUri"] ?? "";
        }

        public QuestionsService(HttpClient httpClient, string uri)
        {
            _httpClient = httpClient;
            _uri = uri;
        }

        public QuestionsService() : this(new HttpClient())
        {

        }

        public async Task<QuestionnaireViewModel> GetQuestionsAsync()
        {
            var result = await _httpClient.GetStringAsync(_uri);

            return JsonConvert.DeserializeObject<QuestionnaireViewModel>(result);
        }

        public async Task<Question> AddQuesitonAsync(Question question)
        {
            var response = await _httpClient.PostAsJsonAsync<Question>("uri", question);

            question = response.Content.ReadAsAsync<Question>().Result;

            return question;
        }
    }
}