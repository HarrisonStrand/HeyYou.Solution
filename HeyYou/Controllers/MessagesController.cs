using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using HeyYou.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HeyYou.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/messages")]
    [ApiController]
    public class MessagesV1Controller : ControllerBase
    {
        private HeyYouContext _db;
        public MessagesV1Controller(HeyYouContext db)
        {
            _db = db;
        }

        //GET api/messages
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string messageTitle)
        {
            var query = _db.Messages.AsQueryable();

            if (messageTitle != null)
            {
                query = query.Where(entry => entry.MessageTitle == messageTitle);
            }

            return query.ToList();
        }
    }

    [ApiVersion("2.0")]
    [Route("api/messages")]
    [ApiController]
    public class MessagesV2Controller : ControllerBase
    {
        private HeyYouContext _db;
        public MessagesV2Controller(HeyYouContext db)
        {
            _db = db;
        }

        //GET api/messages
        [HttpGet]
        public ActionResult<IEnumerable<Message>> Get(string messageTitle)
        {
            return _db.Messages.ToList();
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