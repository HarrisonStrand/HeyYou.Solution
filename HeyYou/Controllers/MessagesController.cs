using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HeyYou.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeyYou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private HeyYouContext _db;
        public MessagesController(HeyYouContext db)
        {
            _db = db;
        }

        //GET api/messages
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string messageTitle, string groupName)
        {
            var query = _db.Messages
            .Include(message => message.JoinEntries)
            .ThenInclude(join => join.Group).AsQueryable();
            if (messageTitle != null)
            {
                query = query.Where(entry => entry.MessageTitle == messageTitle);
            }
            if (groupName != null)
            {
                // query = query.Where(entry => entry.JoinEntries.Groups.GroupName == groupName);
                query = query.Where(entry => entry.JoinEntries.Where(join => join.Group.GroupName == groupName).Count() > 0);
            }

            return query.ToList();
        }

        // POST api/messages
        [HttpPost]
        public void Post([FromBody] Message message)
        {
            _db.Messages.Add(message);
            _db.SaveChanges();
        }

        //Get api/messages/5
        [HttpGet("{id}")]
        public ActionResult<Message> Get(int id)
        {
            return _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
        }

        // PUT api/messages/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Message message)
        {
            message.MessageId = id;
            _db.Entry(message).State = EntityState.Modified;
            _db.SaveChanges();
        }

        // DELETE api/messages/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var messageToDelete = _db.Messages.FirstOrDefault(entry => entry.MessageId == id);
            _db.Messages.Remove(messageToDelete);
            _db.SaveChanges();
        }
    }
}