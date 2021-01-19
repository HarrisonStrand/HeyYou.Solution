using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HeyYou.Models
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
        public ICollection<GroupMessage> JoinEntries { get; set; }
    }
}