using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HeyYou.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyYou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private HeyYouContext _db;
        public GroupsController(HeyYouContext db)
        {
            _db = db;
        }

        //GET api/groups
        [HttpGet]
        public ActionResult<IEnumerable<Group>> Get(string groupName)
        {
            var query = _db.Groups
            .Include(group => group.JoinEntries)
            .ThenInclude(join => join.Message).AsQueryable();
            if (groupName != null)
            {
                query = query.Where(entry => entry.GroupName == groupName);
            }
            return query.ToList();
        }

        // POST api/groups
        [HttpPost]
        public void Post([FromBody] Group group)
        {
            _db.Groups.Add(group);
            _db.SaveChanges();
        }

        //Get api/groups/5
        [HttpGet("{id}")]
        public ActionResult<Group> Get(int id)
        {
            return _db.Groups.FirstOrDefault(entry => entry.GroupId == id);
        }

        // PUT api/groups/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Group group)
        {
            group.GroupId = id;
            _db.Entry(group).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/groups/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var groupToDelete = _db.Groups.FirstOrDefault(entry => entry.GroupId == id);
            _db.Groups.Remove(groupToDelete);
            _db.SaveChanges();
        }
    }
}