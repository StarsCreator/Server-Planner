using System;
using System.Runtime.Serialization;

namespace CServer.Chat
{
    [DataContract]
    public class ChatMessage
    {
        public ChatMessage(string n, DateTime ts, string m)
        {
            TimeStamp = ts;
            Name = n;
            Message = m;
        }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public string Message { get; set; }

    }
}
