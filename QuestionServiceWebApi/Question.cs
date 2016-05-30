using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string QuestionText { get; set; }
    }
}