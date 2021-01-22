using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientHeyYou.Models
{
    public class Message
    {
        public Message()
        {
            this.JoinEntries = new HashSet<GroupMessage>();
        }
        public int MessageId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public string MessageAuthor { get; set; }
        public DateTime MessageDate { get; set; }
        public virtual ICollection<GroupMessage> JoinEntries { get; set; }

        public static List<Message> GetMessages()
        {
            var apiCallTask = MessagesApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

            return messageList;
        }

        public static Message GetDetails(int id)
        {
            var apiCallTask = MessagesApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

            return message;
        }
        public static void Post(Message message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            var apiCallTask = MessagesApiHelper.Post(jsonMessage);
        }
        public static void Put(Message message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            var apiCallTask = MessagesApiHelper.Put(message.MessageId, jsonMessage);
        }
        public static void Delete(int id)
        {
            var apiCallTask = MessagesApiHelper.Delete(id);
        }
    }
}
