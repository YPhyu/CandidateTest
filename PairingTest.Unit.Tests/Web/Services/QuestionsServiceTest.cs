using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using PairingTest.Helpers;
using PairingTest.Unit.Tests.Web.Stubs;
using PairingTest.Web.Interfaces;
using PairingTest.Web.Services;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web.Services
{
    [TestFixture]
    class QuestionsServiceTest
    {
        private IQuestionsService _service;
        private HttpClient _httpClient;
        private QuestionnaireViewModel _expectedQuestionnaire;

        [TestFixtureSetUp]
        public void Setup()
        {
            var expectedTitle = "My expected questions";
            _expectedQuestionnaire = new QuestionnaireViewModel() { QuestionnaireTitle = expectedTitle };

            var fakeUri = "http://www.getting.nowhere/";
            _httpClient = new HttpClient(new FakeHttpMessageHandler(fakeUri, _expectedQuestionnaire.ToJson()));
            _service = new QuestionsService(_httpClient, fakeUri);
        }

        [Test]
        public async Task ShouldGetQuestions()
        {
            // Arrange

            // Act
            var result = await _service.GetQuestionsAsync();

            // Assert
            Assert.AreEqual(result.QuestionnaireTitle, _expectedQuestionnaire.QuestionnaireTitle);
        }
    }
}
