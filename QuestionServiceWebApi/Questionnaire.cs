using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Questionnaire
    {
        [DataMember]
        public string QuestionnaireTitle { get; set; }
        [DataMember]
        public IList<Question> Questions { get; set; }
    }
}