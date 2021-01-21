using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ClientHeyYou.Models;

namespace ClientHeyYou.Controllers
{
    public class MessagesController : Controller
    {
        public IActionResult Index()
        {
            var allMessages = Message.GetMessages();
            return View(allMessages);
        }
    }
}