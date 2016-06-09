using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.Unit.Tests.Web.Stubs;
using System.Net.Http;

namespace PairingTest.Unit.Tests.Web.Controllers
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        private QuestionnaireViewModel _expectedQuestionnaire;

        [TestFixtureSetUp]
        public void Setup()
        {
            var expectedTitle = "My expected questionnaire";
            _expectedQuestionnaire = new QuestionnaireViewModel()
            {
                QuestionnaireTitle = expectedTitle,
                Questions = new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        QuestionText = "Question 1"
                    },
                    new Question
                    {
                        Id = 2,
                        QuestionText = "Question 2"
                    }
                }
            };
        }

        [Test]
        public async Task ShouldGetQuestions()
        {
            //Arrange
            var fakeQuestionsService = new FakeQuestionsService() { ExpectedQuestions = _expectedQuestionnaire };
            var questionnaireController = new QuestionnaireController(fakeQuestionsService);

            //Act
            var result = await questionnaireController.All();

            //Assert
            Assert.That(result.Data, Is.EqualTo(_expectedQuestionnaire));
        }
    }
}