using System.Net;
using PairingTest.Unit.Tests.Helpers;
using PairingTest.Web.Models;
using PairingTest.Web.Interfaces;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web.Stubs
{
    internal class FakeQuestionsService : IQuestionsService
    {
        public QuestionnaireViewModel ExpectedQuestions { get; set; }

        public Task<QuestionnaireViewModel> GetQuestionsAsync()
        {
            return TaskHelpers.CreatePseudoTask<QuestionnaireViewModel>(ExpectedQuestions);
        }

        public Task<Question> AddQuesitonAsync(Question question)
        {
            return TaskHelpers.CreatePseudoTask<Question>(question);
        }
    }
}
