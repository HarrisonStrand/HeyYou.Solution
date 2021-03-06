using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientHeyYou.Models
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
        public virtual ICollection<GroupMessage> JoinEntries { get; set; }
        public static List<Group> GetGroups()
        {
            var apiCallTask = GroupsApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());

            return groupList;
        }
        public static Group GetDetails(int id)
        {
            var apiCallTask = GroupsApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Group group = JsonConvert.DeserializeObject<Group>(jsonResponse.ToString());

            return group;
        }
        public static void Post(Group group)
        {
            string jsonGroup = JsonConvert.SerializeObject(group);
            var apiCallTask = GroupsApiHelper.Post(jsonGroup);
        }
        public static void Put(Group group)
        {
            string jsonGroup = JsonConvert.SerializeObject(group);
            var apiCallTask = GroupsApiHelper.Put(group.GroupId, jsonGroup);
        }
        public static void Delete(int id)
        {
            var apiCallTask = GroupsApiHelper.Delete(id);
        }
    }
}