using System.Threading.Tasks;
using PairingTest.Web.Models;

namespace PairingTest.Web.Interfaces
{
    public interface IQuestionsService
    {
        Task<QuestionnaireViewModel> GetQuestionsAsync();

        Task<Question> AddQuesitonAsync(Question question);
    }
}