using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
    {
        public string QuestionnaireTitle { get; set; }
        public IList<Question> Questions { get; set; }
    }
}