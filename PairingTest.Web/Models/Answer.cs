using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string AnswerText { get; set; }
    }
}