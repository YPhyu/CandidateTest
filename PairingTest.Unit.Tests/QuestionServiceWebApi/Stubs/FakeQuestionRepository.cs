using QuestionServiceWebApi;
using QuestionServiceWebApi.Interfaces;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }
        public Questionnaire GetQuestionnaire()
        {
            return ExpectedQuestions;
        }

        public Question AddQuestion(Question question)
        {
            question.Id = ExpectedQuestions.Questions.Count + 1;
            ExpectedQuestions.Questions.Add(question);

            return question;
        }
    }
}