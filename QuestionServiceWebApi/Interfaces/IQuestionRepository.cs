namespace QuestionServiceWebApi.Interfaces
{
    public interface IQuestionRepository
    {
        Questionnaire GetQuestionnaire();
        Question AddQuestion(Question question);
    }
}