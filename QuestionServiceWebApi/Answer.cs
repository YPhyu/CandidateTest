using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Answer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public string AnswerText { get; set; }
    }
}