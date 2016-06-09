using System.Linq;
using NUnit.Framework;
using QuestionServiceWebApi;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        private QuestionRepository _questionRepository;

        [TestFixtureSetUp]
        public void Setup()
        {
            _questionRepository = new QuestionRepository();
        }

        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionnaire = _questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.QuestionnaireTitle, Is.EqualTo("Geography Questions"));
            Assert.That(questionnaire.Questions[0].QuestionText, Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.Questions[1].QuestionText, Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.Questions[2].QuestionText, Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.Questions[3].QuestionText, Is.EqualTo("What is the capital of Germany?"));
        }

        [Test]
        public void ShouldAddQuestion()
        {
            var question = new Question
            {
                QuestionText = "Question 5"
            };

            var orginalCount = _questionRepository.GetQuestionnaire().Questions.Count;

            _questionRepository.AddQuestion(question);

            var result = _questionRepository.GetQuestionnaire().Questions.Count;

            Assert.That(orginalCount + 1, Is.EqualTo(result));
        }

        [Test]
        public void ShouldAssignIdWithMaxIdPlusOne()
        {
            var question = new Question
            {
                QuestionText = "Question 6"
            };

            var orginalCount = _questionRepository.GetQuestionnaire().Questions.Count;

            _questionRepository.AddQuestion(question);

            var result = _questionRepository.GetQuestionnaire().Questions.Last().Id;

            Assert.That(orginalCount + 1, Is.EqualTo(result));
        }
    }
}