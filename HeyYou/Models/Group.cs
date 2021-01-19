using System.Collections.Generic;

namespace HeyYou.Models
{
    public class Group
    {
        public Group()
        {
            this.JoinEntries = new HashSet<GroupMessage>();
        }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public ICollection<GroupMessage> JoinEntries { get; set; }
    }
}