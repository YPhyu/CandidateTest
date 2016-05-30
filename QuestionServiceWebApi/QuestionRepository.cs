using System.Collections.Generic;
using QuestionServiceWebApi.Interfaces;

namespace QuestionServiceWebApi
{
    public class QuestionRepository : IQuestionRepository
    {
        public Questionnaire GetQuestionnaire()
        {
            return new Questionnaire
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
    }
}