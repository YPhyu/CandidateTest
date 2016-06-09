using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs;
using QuestionServiceWebApi;
using QuestionServiceWebApi.Controllers;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionsControllerTests
    {
        Questionnaire _expectedQuestionnaire;
        FakeQuestionRepository _fakeQuestionRepository;
        QuestionsController _questionsController;
        QuestionsController _questionsPostController;

        [TestFixtureSetUp]
        public void Setup()
        {
            var expectedTitle = "My expected questionnaire";
            _expectedQuestionnaire = new Questionnaire()
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
            _fakeQuestionRepository = new FakeQuestionRepository() { ExpectedQuestions = _expectedQuestionnaire };
            _questionsController = new QuestionsController(_fakeQuestionRepository);


            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            var httpRouteData = new HttpRouteData(httpConfiguration.Routes["DefaultApi"],
                new HttpRouteValueDictionary { { "controller", "Questions" } });
            _questionsPostController = new QuestionsController()
            {
                Request = new HttpRequestMessage(HttpMethod.Post, "http://domain.com/api/questions/")
                {
                    Properties = {
                                        { HttpPropertyKeys.HttpConfigurationKey, httpConfiguration },
                                        { HttpPropertyKeys.HttpRouteDataKey, httpRouteData }
                                 }
                }
            };
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected questionnaire";

            //Act
            var questions = _questionsController.Get();

            //Assert
            Assert.That(questions.QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        public void ShouldGetQuestion()
        {
            //Arrange
            var expectedResult = "Question 1";

            //Act
            var result = _questionsController.Get(1);

            //Assert
            Assert.That(result.QuestionText, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnNull()
        {
            //Arrange

            //Act
            var result = _questionsController.Get(5);

            //Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void ShouldAddQuestion()
        {
            var question = new Question
            {
                QuestionText = "Question 5"
            };

            var response = _questionsPostController.Post(question);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void ShouldAssignIdWithMaxIdPlusOne()
        {
            var question = new Question
            {
                QuestionText = "Question 6"
            };

            var orginalCount = _questionsPostController.Get().Questions.Count;

            var response = _questionsPostController.Post(question) as HttpResponseMessage;

            question = response.Content.ReadAsAsync<Question>().Result;

            Assert.That(orginalCount + 1, Is.EqualTo(question.Id));
        }

    }
}