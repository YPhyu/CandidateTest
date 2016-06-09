using System.Collections.Generic;
using System.Linq;
using QuestionServiceWebApi.Interfaces;

namespace QuestionServiceWebApi
{
    public class QuestionRepository : IQuestionRepository
    {
        private Questionnaire _questionnaire;

        public QuestionRepository()
        {
            _questionnaire =  new Questionnaire
            {
                QuestionnaireTitle = "Geography Questions",
                Questions = new List<Question>
                {
                    new Question
                    {
                        Id = 1,
                        QuestionText = "What is the capital of Cuba?"
                    },
                    new Question
                    {
                        Id = 2,
                        QuestionText = "What is the capital of France?"
                    },
                    new Question
                    {
                        Id = 3,
                        QuestionText = "What is the capital of Poland?"
                    },
                    new Question
                    {
                        Id = 4,
                        QuestionText = "What is the capital of Germany?"
                    },
                }
            };
        }
        public Questionnaire GetQuestionnaire()
        {
            return _questionnaire;
        }

        public Question AddQuestion(Question question)
        {
            if (question != null)
            {
                //TODO assign better Id
                question.Id = _questionnaire.Questions.Last().Id + 1;
                _questionnaire.Questions.Add(question);

                return question;
            }

            return new Question();
        }
    }
}