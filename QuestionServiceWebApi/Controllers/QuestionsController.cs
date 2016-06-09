using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionServiceWebApi.Interfaces;

namespace QuestionServiceWebApi.Controllers
{
    public class QuestionsController : ApiController
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public QuestionsController() : this(new QuestionRepository())
        {
        }

        // GET api/questions
        public Questionnaire Get()
        {
            return _questionRepository.GetQuestionnaire();
        }

        // GET api/questions/5
        public Question Get(int id)
        {
            var questionnaire = _questionRepository.GetQuestionnaire();
            return questionnaire?.Questions.SingleOrDefault(x => x.Id == id);
        }

        // POST api/questions
        public HttpResponseMessage Post([FromBody]Question question)
        {
            if(!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

            question = _questionRepository.AddQuestion(question);

            var response = Request.CreateResponse(HttpStatusCode.Created, question);

            var uriString = Url.Link("DefaultApi", new { id = question.Id }) ?? string.Empty;
            response.Headers.Location = new Uri(uriString);

            return response;
        }


        // PUT api/questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/questions/5
        public void Delete(int id)
        {
        }
    }
}
