namespace ClientHeyYou.Models
{
    public class GroupMessage
    {
        public int GroupMessageId { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }
}